namespace LeaveManagementSystem.Web.Models.LeaveRequestModels
{
    public class ReviewLeaveRequestVM :LeaveRequestListVM
    {
        public EmployeeListVM EmployeeListVM { get; set; } = new EmployeeListVM();
        public string ? RequestComment { get; set; } = string.Empty;


    }
}