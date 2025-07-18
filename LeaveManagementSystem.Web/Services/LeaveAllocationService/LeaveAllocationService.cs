﻿
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
            var leavesTypes = await _context.leaveTypes.ToListAsync();
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

        public async Task<List<LeaveAllocation>> GetAllocations()
        {
            var User = await _userManager.GetUserAsync(_httpContextAccessor?.HttpContext?.User);

            var allocations = await _context.leaveAllocations
                .Include(l => l.LeaveType)
                .Include(l => l.Period)
                
                .Where(l => l.EmployeeId == User.Id)
                .ToListAsync();
            if (allocations == null || allocations.Count == 0)
                return null;
            return allocations;

        }

        public async Task<EmployeeLeaveAllocationVM> GetEmployeeLeaveAllocation()
        {
            var allocations =await GetAllocations();
            var allocationVmList = _mapper.Map<List<LeaveAllocation>,List<LeaveAllocationVM>>(allocations);
            var User = await _userManager.GetUserAsync(_httpContextAccessor?.HttpContext?.User);
            var employeeVM = new EmployeeLeaveAllocationVM()
            {
                Id = User.Id,
                FirstName = User.FirstName,
                LastName = User.LastName,
                DateOfBirth = User.DateOfBirth,
                Email = User.Email,
                LeaveAllocations = allocationVmList
            };
            return employeeVM;


        }

    }
    
}
