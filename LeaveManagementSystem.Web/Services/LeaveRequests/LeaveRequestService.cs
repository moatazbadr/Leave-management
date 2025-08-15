using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace LeaveManagementSystem.Web.Services.LeaveRequests;

public partial class LeaveRequestService(IMapper _mapper, UserManager<ApplicationUser> _userManager
    , IHttpContextAccessor _httpContextAccessor, ApplicationDbContext _context) : ILeaveRequestService
{
    public async Task CancelLeaveRequest(int leaveRequestId)
    {
        var leaveRequest = await _context.leaveRequests.FindAsync(leaveRequestId);
        leaveRequest.LeaveRequestStatusId = (int)LeaveRequestStatusEnum.Cancelled;

        var numberOfDays = leaveRequest.EndDate.DayNumber - leaveRequest.StartDate.DayNumber;
        var AllocationToAdd = await _context.leaveAllocations
            .FirstOrDefaultAsync(x => x.EmployeeId == leaveRequest.EmployeeId && x.LeaveTypeId == leaveRequest.leaveTypeId);
        AllocationToAdd.NumberOfDays += numberOfDays;

        await _context.SaveChangesAsync();
    }

    public async Task CreateLeaveRequest(LeaveRequestCreateVM model)
    {
        var leaveRequest = _mapper.Map<LeaveRequest>(model);
        var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
        if (user != null)
        {
            leaveRequest.EmployeeId = user.Id;
        }
        leaveRequest.LeaveRequestStatusId = (int)LeaveRequestStatusEnum.Pending;
        await _context.leaveRequests.AddAsync(leaveRequest);

        var numberOfDays = model.StartDate.DayNumber - model.EndDate.DayNumber;
        var AllocationToDeduct = await _context.leaveAllocations
            .FirstOrDefaultAsync(x => x.EmployeeId == user.Id && x.LeaveTypeId == model.leaveTypeId);
        if (AllocationToDeduct != null)
        {
            AllocationToDeduct.NumberOfDays -= numberOfDays;
            _context.leaveAllocations.Update(AllocationToDeduct);
        }
        await _context.SaveChangesAsync();

    }

    public Task<EmployeeLeaveRequestLisVM> AdminGetAllLeaveRequests()
    {
        throw new NotImplementedException();
    }

    public async Task<List<LeaveRequestListVM>> GetEmployeeLeaveRequests()
    {
        var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
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


    public Task ReviewLeaveRequest(ReviewLeaveRequestVM model)
    {
        throw new NotImplementedException();
    }
    public async Task<bool> RequestDatesExceedAllocation(LeaveRequestCreateVM model)
    {
        var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

        var numberOfDays = model.EndDate.DayNumber - model.StartDate.DayNumber;
        var allocation = await _context.leaveAllocations
            .FirstOrDefaultAsync(x => x.EmployeeId == user.Id && x.LeaveTypeId == model.leaveTypeId);
        if (allocation != null)
            return allocation.NumberOfDays < numberOfDays;

        return true;
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
