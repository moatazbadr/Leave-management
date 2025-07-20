
using AutoMapper;
using LeaveManagementSystem.Web.Models.LeaveAllocation;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Services.LeaveAllocationService
{
    public class LeaveAllocationService : ILeaveAllocationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        public LeaveAllocationService(
            ApplicationDbContext context,
            IMapper mapper,
            IHttpContextAccessor httpContext,
            UserManager<ApplicationUser> userManager)
        {
            _httpContextAccessor = httpContext;
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task AllocateLeave(string EmployeeId)
        {
            var leavesTypes = await _context.leaveTypes
                .Where(q=> !q.LeaveAllocations.Any(x=>x.EmployeeId==EmployeeId))
                .ToListAsync();
            var currentDate = DateTime.Now;
            var period = await _context.periods.SingleAsync(p => p.EndDate.Year == currentDate.Year);
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
    
            var currentDate = DateTime.Now;
            var period = await _context.periods.SingleAsync(p => p.EndDate.Year == currentDate.Year);
            var allocations = await _context.leaveAllocations
                .Include(l => l.LeaveType)
                .Include(l => l.Period)
                .Where(l => l.EmployeeId == UserId && l.PeriodId==period.Id)
                .ToListAsync();
            if (allocations == null || allocations.Count == 0)
                return allocations;
            return allocations;

        }

        public async Task<EmployeeLeaveAllocationVM> GetEmployeeLeaveAllocation(string? UserId)
        {
            var User =string.IsNullOrEmpty(UserId) ?
                await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User)
                : await _userManager.FindByIdAsync(UserId);
            var allocations =await GetAllocations(User.Id);

            var allocationVmList = _mapper.Map<List<LeaveAllocation>,List<LeaveAllocationVM>>(allocations);
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
            var users = await _userManager.GetUsersInRoleAsync("employee");
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


        private async Task<bool> AllocateExists(string UserId, int periodId, int leaveTypeId)
        {
            var Exists = await _context.leaveAllocations.AnyAsync(q =>
                q.EmployeeId == UserId && q.LeaveTypeId == leaveTypeId
                && q.PeriodId == periodId);
            return Exists;

        }
    }
    
}
