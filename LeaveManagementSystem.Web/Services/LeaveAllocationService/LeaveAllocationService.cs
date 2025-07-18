
namespace LeaveManagementSystem.Web.Services.LeaveAllocationService
{
    public class LeaveAllocationService : ILeaveAllocationService
    {
        private readonly ApplicationDbContext _context;

        public LeaveAllocationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task AllocationLeave(string EmployeeId)
        {
            throw new NotImplementedException();
        }
    }
}
