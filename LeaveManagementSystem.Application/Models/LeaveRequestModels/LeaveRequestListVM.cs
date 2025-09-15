
using LeaveManagementSystem.Application.Services.LeaveRequests;
using System.ComponentModel;

namespace LeaveManagementSystem.Application.Models.LeaveRequestModels
{
    public class LeaveRequestListVM
    {
        public int Id { get; set; }
        [DisplayName("start Date")]
        public DateOnly StartDate { get; set; }
        [DisplayName("End Date")]
        public DateOnly EndDate { get; set; }
        [DisplayName("Total Days")]
        public int NumberOfDays { get; set; }
        [DisplayName("Leave Type")]
        public string LeaveTypeName { get; set; } = string.Empty;
        [DisplayName("Request status")]
        public LeaveRequestStatusEnum  Status { get; set; }
    }
}