using LeaveManagementSystem.Data;

namespace LeaveManagementSystem.Application.Models;

public interface ILeaveAllocationService
{
    Task AllocateLeave(string EmployeeId);
    Task<List<Data.LeaveAllocation>> GetAllocations(string? UserId);
    Task<EmployeeLeaveAllocationVM> GetEmployeeLeaveAllocation(string? UserId);
    Task<List<EmployeeListVM>> GetEmployees();
    Task<LeaveAllocationEditVM> GetAllocationForEmployee(int? Id);
    Task EditAllocation(LeaveAllocationEditVM leaveAllocationEdit);
    Task<Data.LeaveAllocation> GetCurrentAllocation(int LeaveTypeId, string EmployeeId);

}
