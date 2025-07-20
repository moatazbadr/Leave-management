using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Web.Models.LeaveTypes
{
    public class LeaveTypeEditVM :BaseLeaveType
    {
        [Required]
        [MaxLength(150, ErrorMessage = "You shouldn't leave that empty")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Range(1, 90, ErrorMessage = "You will get fired if the period is more than 90 days")]
        [Display(Name = "Maximum number of allowed Days")]

        public int Days { get; set; }
    }
}
