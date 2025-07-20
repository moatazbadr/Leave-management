using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Web.Models.LeaveTypes
{
    public class LeaveTypesReadOnly :BaseLeaveType

    {
       
        public string Name { get; set; } = string.Empty;

        [Display(Name ="Maximum number of allowed Days")]
        public int Days { get; set; }

    }

   

}
