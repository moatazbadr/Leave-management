namespace LeaveManagementSystem.Web.Services.LeaveAllocationService
{
    public interface ILeaveAllocationService
    {
        Task AllocateLeave(string EmployeeId);
        Task<List<LeaveAllocation>> GetAllocations();
    }
}
