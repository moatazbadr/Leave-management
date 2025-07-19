
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Services.LeaveAllocationService
{
    public class LeaveAllocationService : ILeaveAllocationService
    {
        private readonly ApplicationDbContext _context;

        public LeaveAllocationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AllocateLeave(string EmployeeId)
        {
            var leavesTypes = await _context.leaveTypes.ToListAsync();
            var currentDate = DateTime.Now;
            var period = await _context.periods.SingleAsync(p => p.EndDate.Year == currentDate.Year);
            var monthRemaining = period.EndDate.Month - currentDate.Month;

            foreach (var leaveType in leavesTypes)
            {
                var Rate = decimal.Divide (leaveType.Days , 12);

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


        public async Task GetAllocations(string employeeId)
        {

        }
    }
    
}
