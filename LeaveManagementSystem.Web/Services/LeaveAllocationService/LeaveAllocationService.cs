
using AutoMapper;
using LeaveManagementSystem.Web.Models.LeaveAllocation;
using LeaveManagementSystem.Web.Services.PeriodService;
using LeaveManagementSystem.Web.Services.Users;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Services.LeaveAllocationService
{
    public class LeaveAllocationService : ILeaveAllocationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _UserService;
        private readonly IMapper _mapper;
        private readonly IPeriodService _periodService;
        public LeaveAllocationService(
            ApplicationDbContext context,
            IMapper mapper,
            IHttpContextAccessor httpContext,
            UserManager<ApplicationUser> userManager,
            IPeriodService periodService,
            IUserService userService
            )
        {
            _context = context;
            _UserService = userService;
            _mapper = mapper;
            _periodService = periodService;
        }


        public async Task AllocateLeave(string EmployeeId)
        {
            var leavesTypes = await _context.leaveTypes
                .Where(q => !q.LeaveAllocations.Any(x => x.EmployeeId == EmployeeId))
                .ToListAsync();
            var currentDate = DateTime.Now;
            var period = await _periodService.GetCurrentPeriod();
            var monthRemaining = period.EndDate.Month - currentDate.Month;



            foreach (var leaveType in leavesTypes)
            {
                var Rate = decimal.Divide(leaveType.Days, 12);
                var leaveAllocation = new LeaveAllocation()
                {
                    EmployeeId = EmployeeId,
                    LeaveTypeId = leaveType.Id,
                    PeriodId = period.Id,
                    // يا غبي كام يوم غياب
                    NumberOfDays = (int)Math.Ceiling(Rate * monthRemaining)
                };
                _context.Add(leaveAllocation);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<LeaveAllocation>> GetAllocations(string? UserId)
        {


            var period = await _periodService.GetCurrentPeriod();
            var allocations = await _context.leaveAllocations
                .Include(l => l.LeaveType)
                .Include(l => l.Period)
                .Where(l => l.EmployeeId == UserId && l.PeriodId == period.Id)
                .ToListAsync();
            if (allocations == null || allocations.Count == 0)
                return allocations;
            return allocations;

        }

        public async Task<EmployeeLeaveAllocationVM> GetEmployeeLeaveAllocation(string? UserId)
        {
            var User = string.IsNullOrEmpty(UserId) ?
                await _UserService.GetLoggedUser() 
                : await _UserService.GetUserById(UserId);
            var allocations = await GetAllocations(User.Id);

            var allocationVmList = _mapper.Map<List<LeaveAllocation>, List<LeaveAllocationVM>>(allocations);
            var allocationCount = await _context.leaveTypes.CountAsync();


            var employeeVM = new EmployeeLeaveAllocationVM()
            {
                Id = User.Id,
                FirstName = User.FirstName,
                LastName = User.LastName,
                DateOfBirth = User.DateOfBirth,
                Email = User.Email,
                LeaveAllocations = allocationVmList,
                isCompletedAllocation = allocations.Count == allocationCount

            };
            return employeeVM;


        }

        public async Task<List<EmployeeListVM>> GetEmployees()
        {
            var users = await _UserService.GetEmployees();
            if (users == null || users.Count == 0)
                return null;
            var employeeList = _mapper.Map<List<ApplicationUser>, List<EmployeeListVM>>(users.ToList());

            return employeeList;
        }



        public async Task<LeaveAllocationEditVM> GetAllocationForEmployee(int? Id)
        {
            var allocation = await _context.leaveAllocations
                .Include(l => l.LeaveType)
                .Include(l => l.Employee)
                .FirstOrDefaultAsync(l => l.Id == Id);

            var allocationVM = _mapper.Map<LeaveAllocationEditVM>(allocation);
            return allocationVM;

        }

        public async Task EditAllocation(LeaveAllocationEditVM leaveAllocationEdit)
        {
            await _context.leaveAllocations
            .Where(q => q.Id == leaveAllocationEdit.Id)
            .ExecuteUpdateAsync(s => s.SetProperty(e => e.NumberOfDays, leaveAllocationEdit.NumberOfDays));

        }



        public async Task<LeaveAllocation> GetCurrentAllocation(int LeaveTypeId, string EmployeeId)
        {
            var period = await _periodService.GetCurrentPeriod();
            var allocation = await _context.leaveAllocations
                .FirstOrDefaultAsync(l => l.EmployeeId == EmployeeId
                && l.LeaveTypeId == LeaveTypeId
                && l.PeriodId == period.Id);

            return allocation;

        }
    }

}
