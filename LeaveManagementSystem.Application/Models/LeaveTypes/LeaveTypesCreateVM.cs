using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Application.Models.LeaveTypes
{
    public class LeaveTypesCreateVM
    {
        [Required]
        [MaxLength(150 ,ErrorMessage ="You shouldn't leave that empty")]
        public string Name { get; set; }
        [Required]
        [Range(1,90 ,ErrorMessage ="You will get fired if the period is more than 90 days")]
        [Display(Name = "Maximum number of allowed Days")]

        public int Days { get; set; }

    }
}
