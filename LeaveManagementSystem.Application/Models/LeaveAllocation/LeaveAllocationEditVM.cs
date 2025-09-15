namespace LeaveManagementSystem.Application.Models.LeaveAllocation;

public class LeaveAllocationEditVM : LeaveAllocationVM
{
    public EmployeeListVM ? Employee { get; set; } = new EmployeeListVM();

}
