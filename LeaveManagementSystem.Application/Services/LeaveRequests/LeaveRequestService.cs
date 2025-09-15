using AutoMapper;
using LeaveManagementSystem.Application.Services.LeaveAllocationService;
using Microsoft.EntityFrameworkCore;
namespace LeaveManagementSystem.Application.Services.LeaveRequests;

using LeaveManagementSystem.Application.Models;
using LeaveManagementSystem.Application.Models.LeaveRequestModels;
using LeaveManagementSystem.Application.Services.Users;
using LeaveManagementSystem.Data;

public partial class LeaveRequestService(IMapper _mapper,IUserService _userService, ApplicationDbContext _context ,ILeaveAllocationService _leaveAllocationService) : ILeaveRequestService
{
    public async Task CancelLeaveRequest(int leaveRequestId)
    {
        var leaveRequest = await _context.leaveRequests.FindAsync(leaveRequestId);
        leaveRequest.LeaveRequestStatusId = (int)LeaveRequestStatusEnum.Cancelled;

        //var numberOfDays = leaveRequest.EndDate.DayNumber - leaveRequest.StartDate.DayNumber;
        //var currentDate = DateTime.Now;
        //var period = await _context.periods.SingleAsync(p => p.EndDate.Year == currentDate.Year);
        //var AllocationToAdd = await _context.leaveAllocations
        //    .FirstOrDefaultAsync(x => x.EmployeeId == leaveRequest.EmployeeId && x.LeaveTypeId == leaveRequest.leaveTypeId
        //&&    x.PeriodId == period.Id
        //    );

        //AllocationToAdd.NumberOfDays += numberOfDays;
        await updateAllocationDays(leaveRequest, false);
        await _context.SaveChangesAsync();
    }

    public async Task CreateLeaveRequest(LeaveRequestCreateVM model)
    {
        var leaveRequest = _mapper.Map<LeaveRequest>(model);
        var user = await _userService.GetLoggedUser();
        if (user != null)
        {
            leaveRequest.EmployeeId = user.Id;
        }
        leaveRequest.LeaveRequestStatusId = (int)LeaveRequestStatusEnum.Pending;
        await _context.leaveRequests.AddAsync(leaveRequest);
       
        await updateAllocationDays(leaveRequest, true);
        await _context.SaveChangesAsync();

    }

    public async Task<EmployeeLeaveRequestLisVM> AdminGetAllLeaveRequests()
    {
        var leaveRequests = await _context.leaveRequests.Include(l=>l.leaveType)
                                                  .ToListAsync();
        var model = new EmployeeLeaveRequestLisVM()
        {
            ApprovedRequests = leaveRequests.Count(x => x.LeaveRequestStatusId == (int)LeaveRequestStatusEnum.Approved),
            PendingRequests = leaveRequests.Count(x => x.LeaveRequestStatusId == (int)LeaveRequestStatusEnum.Pending),
            RejectedRequests = leaveRequests.Count(x => x.LeaveRequestStatusId == (int)LeaveRequestStatusEnum.Declined),
            TotalRequests = leaveRequests.Count,

            LeaveRequests = leaveRequests.Select(x => new LeaveRequestListVM
            {
                
                EndDate = x.EndDate,
                StartDate = x.StartDate,
                LeaveTypeName = x.leaveType?.Name,
                NumberOfDays = x.EndDate.DayNumber - x.StartDate.DayNumber,
                Status = (LeaveRequestStatusEnum)x.LeaveRequestStatusId,
                Id = x.Id
            }).ToList()

        };
        return model;

    }

    public async Task<List<LeaveRequestListVM>> GetEmployeeLeaveRequests()
    {
        var user = await _userService.GetLoggedUser();
        var leaveRequests = await _context.leaveRequests
                                 .Include(x => x.leaveType)
                                 .Where(x => x.EmployeeId == user.Id).ToListAsync();
        var model = leaveRequests.Select(x => new LeaveRequestListVM
        {
            EndDate = x.EndDate,
            StartDate = x.StartDate,
            LeaveTypeName = x.leaveType?.Name,
            NumberOfDays = x.EndDate.DayNumber - x.StartDate.DayNumber,
            Status = (LeaveRequestStatusEnum)x.LeaveRequestStatusId,
            Id = x.Id
        }).ToList();

        return model;

    }


    public async Task ReviewLeaveRequest(int leaveRequestId, bool approved)
    {
        var User = await _userService.GetLoggedUser() ;
        var leaveRequest = await _context.leaveRequests.FindAsync(leaveRequestId);
        leaveRequest.LeaveRequestStatusId = approved
            ? (int)LeaveRequestStatusEnum.Approved
            : (int)LeaveRequestStatusEnum.Declined;
        leaveRequest.ReviewerId = ( User)?.Id;
        var currentDate = DateTime.Now;
        var period = await _context.periods.SingleAsync(p => p.EndDate.Year == currentDate.Year );

        if (!approved)
        {
           await updateAllocationDays(leaveRequest, false);
            
        }
            await _context.SaveChangesAsync();

    }
    public async Task<bool> RequestDatesExceedAllocation(LeaveRequestCreateVM model)
    {
        var user = await _userService.GetLoggedUser();
        var currentDate = DateTime.Now;
        var period = await _context.periods.SingleAsync(p => p.EndDate.Year == currentDate.Year);

        var numberOfDays = model.EndDate.DayNumber - model.StartDate.DayNumber;
        var allocation = await _context.leaveAllocations
            .FirstOrDefaultAsync(x => x.EmployeeId == user.Id && x.LeaveTypeId == model.leaveTypeId && x.PeriodId == period.Id);
        if (allocation != null)
            return allocation.NumberOfDays < numberOfDays;

        return true;
    }

    public async Task <ReviewLeaveRequestVM> GetLeaveRequestForReview(int leaveRequestId)
    {
        var leaveRequest = await _context.leaveRequests
            .Include(x => x.leaveType)
            .FirstOrDefaultAsync(x => x.Id == leaveRequestId);
        
            var User = await _userService.GetUserById(leaveRequest.EmployeeId);

        var model = new ReviewLeaveRequestVM
        {
            StartDate = leaveRequest.StartDate,
            EndDate = leaveRequest.EndDate,
            Id = leaveRequest.Id,
            LeaveTypeName = leaveRequest.leaveType.Name,
            NumberOfDays = leaveRequest.EndDate.DayNumber - leaveRequest.StartDate.DayNumber,
            RequestComment = leaveRequest.RequestComments,
            Status = (LeaveRequestStatusEnum)leaveRequest.LeaveRequestStatusId,
            EmployeeListVM = new EmployeeListVM
            {
                Id = User.Id,
                FirstName = User.FirstName,
                LastName = User.LastName,
                Email = User.Email

            }

        };

        return model;
    }


    private int  calculateDays(DateOnly start, DateOnly end)
    {
        return (end.DayNumber - start.DayNumber); // Inclusive of start day
    }
    private async Task updateAllocationDays (LeaveRequest leaveRequest ,bool deductDays)
    {
        var allocation = await _leaveAllocationService.GetCurrentAllocation(leaveRequest.leaveTypeId, leaveRequest.EmployeeId);
        var numberOfDays = calculateDays(leaveRequest.StartDate, leaveRequest.EndDate);
        if (deductDays)
            allocation.NumberOfDays -= numberOfDays;
        else
            allocation.NumberOfDays += numberOfDays;
        _context.Entry(allocation).State = EntityState.Modified;
    }

    #region Improved Version
    //public async Task<bool> RequestDatesExceedAllocation(int leaveTypeId, DateOnly startDate, DateOnly endDate)
    //{
    //    var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

    //    var numberOfDays = (endDate.DayNumber - startDate.DayNumber) + 1; // Inclusive of start day

    //    var allocation = await _context.leaveAllocations
    //        .FirstOrDefaultAsync(x => x.EmployeeId == user.Id && x.LeaveTypeId == leaveTypeId);

    //    if (allocation == null)
    //        return true; // No allocation means request exceeds allocation

    //    return numberOfDays > allocation.NumberOfDays;
    //}

    #endregion
}
