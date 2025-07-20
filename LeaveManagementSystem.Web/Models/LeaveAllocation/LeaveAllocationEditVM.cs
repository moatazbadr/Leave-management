namespace LeaveManagementSystem.Web.Models.LeaveAllocation
{
    public class LeaveAllocationEditVM : LeaveAllocationVM
    {
        public EmployeeListVM ? Employee { get; set; } = new EmployeeListVM();

    }
}
