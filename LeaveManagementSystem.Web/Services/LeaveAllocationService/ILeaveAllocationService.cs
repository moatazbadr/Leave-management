namespace LeaveManagementSystem.Web.Services.LeaveAllocationService
{
    public interface ILeaveAllocationService
    {
        public Task AllocationLeave(string EmployeeId);
    }
}
