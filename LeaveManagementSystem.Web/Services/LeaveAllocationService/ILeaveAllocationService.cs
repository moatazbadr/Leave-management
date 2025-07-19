using LeaveManagementSystem.Web.Models.LeaveAllocation;

namespace LeaveManagementSystem.Web.Services.LeaveAllocationService
{
    public interface ILeaveAllocationService
    {
        Task AllocateLeave(string EmployeeId);
        Task<List<LeaveAllocation>> GetAllocations();
        Task<EmployeeLeaveAllocationVM> GetEmployeeLeaveAllocation();
    }
}
