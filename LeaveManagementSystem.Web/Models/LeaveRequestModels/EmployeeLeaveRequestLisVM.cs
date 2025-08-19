namespace LeaveManagementSystem.Web.Models.LeaveRequestModels
{
    public class EmployeeLeaveRequestLisVM
    {
        [Display(Name = "Total number of Requests")]
        public int TotalRequests { get; set; }
        [Display(Name = "Pending Requests")]
        public int PendingRequests { get; set; }
        [Display(Name = "Approved Requests")]
        public int ApprovedRequests { get; set; }
        [Display(Name = "Rejected Requests")]
        public int RejectedRequests { get; set; }
        public List<LeaveRequestListVM> LeaveRequests { get; set; } = [];
    }
}