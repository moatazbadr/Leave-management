namespace LeaveManagementSystem.Web.Models.LeaveRequestModels
{
    public class ReviewLeaveRequestVM :LeaveRequestListVM
    {
        public EmployeeListVM EmployeeListVM { get; set; } = new EmployeeListVM();

    }
}