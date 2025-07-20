using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem.Web.Data
{
    public class LeaveType :BaseEntity
    {
        
        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string Name { get; set; }
        public int Days { get; set; }

        public List<LeaveAllocation>? LeaveAllocations { get; set; } = new List<LeaveAllocation>();

    }
}
