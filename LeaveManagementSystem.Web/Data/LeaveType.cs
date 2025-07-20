using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem.Web.Data
{
    public class LeaveType :BaseEntity
    {
        
        [Column(TypeName = "nvarchar(100)")]
   
        public string ? Name { get; set; }=string.Empty;
        public int Days { get; set; }

        public List<LeaveAllocation>? LeaveAllocations { get; set; } = new List<LeaveAllocation>();

    }
}
