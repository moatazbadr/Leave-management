namespace LeaveManagementSystem.Web.Data
{
    public class LeaveRequest :BaseEntity
    {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public LeaveType ? leaveType { get; set; }
        public int leaveTypeId { get; set; }
        public LeaveRequestStatus ? LeaveRequestStatus { get; set; }
        public int LeaveRequestStatusId { get; set; }

        public ApplicationUser ? Employee { get; set; }
        public string EmployeeId { get; set; } = default!;
        //Employee can put a comment on his/her Requested Leave

        //مين اللي وافق علي ال الاجازة
        public ApplicationUser? Reviewer { get; set; }
        public string ? ReviewerId { get; set; }
        public string RequestComments { get; set; } = string.Empty;


    }
}
