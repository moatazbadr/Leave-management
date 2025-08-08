using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace LeaveManagementSystem.Web.Models.LeaveRequestModels
{
    public class LeaveRequestCreateVM
    {
        [DisplayName("Start Date")]
        public DateOnly StartDate { get; set; }
        [DisplayName("End Date")]
        public DateOnly EndDate { get; set; }
        [DisplayName("Leave Type")]
        public int leaveTypeId { get; set; }
        [DisplayName("Comment")]
        public string RequestComments { get; set; } = string.Empty;
        public SelectList ? LeaveTypes { get; set; }
    }
}