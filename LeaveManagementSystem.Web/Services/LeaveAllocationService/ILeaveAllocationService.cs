using LeaveManagementSystem.Web.Models.LeaveAllocation;

namespace LeaveManagementSystem.Web.Services.LeaveAllocationService
{
    public interface ILeaveAllocationService
    {
        Task AllocateLeave(string EmployeeId);
        Task<List<LeaveAllocation>> GetAllocations(string? UserId);
        Task<EmployeeLeaveAllocationVM> GetEmployeeLeaveAllocation(string? UserId);
        Task<List<EmployeeListVM>> GetEmployees();
    }
}
