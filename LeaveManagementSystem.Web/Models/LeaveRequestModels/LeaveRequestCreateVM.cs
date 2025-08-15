using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace LeaveManagementSystem.Web.Models.LeaveRequestModels
{
    public class LeaveRequestCreateVM : IValidatableObject
    {
        [DisplayName("Start Date")]
        [Required]
        public DateOnly StartDate { get; set; }
        [DisplayName("End Date")]
        [Required]
        public DateOnly EndDate { get; set; }
        [DisplayName("Leave Type")]
        [Required]
        public int leaveTypeId { get; set; }
        [DisplayName("Comment")]
        public string RequestComments { get; set; } = string.Empty;
        public SelectList ? LeaveTypes { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
           if (StartDate >EndDate)
            {
                yield return new ValidationResult("Start Date cannot be after End Date", [nameof(StartDate), nameof(EndDate)]);
            }
        }
    }
} 