namespace LeaveManagementSystem.Web.Services.LeaveAllocationService
{
    public interface ILeaveAllocationService
    {
        Task AllocateLeave(string EmployeeId);
        Task GetAllocations(string employeeId);
    }
}
