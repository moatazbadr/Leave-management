namespace LeaveManagementSystem.Application.Models.LeaveRequestModels
{
    public class ReviewLeaveRequestVM :LeaveRequestListVM
    {
        private const string info = "Additional informations";

        public EmployeeListVM EmployeeListVM { get; set; } = new EmployeeListVM();
        [Display(Name = info)]
        public string ? RequestComment { get; set; } = string.Empty;


    }
}