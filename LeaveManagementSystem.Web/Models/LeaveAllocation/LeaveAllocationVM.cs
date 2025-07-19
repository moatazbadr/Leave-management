using LeaveManagementSystem.Web.Models.LeaveTypes;

namespace LeaveManagementSystem.Web.Models.LeaveAllocation
{
    public class LeaveAllocationVM
    {
        public int Id { get; set; }
        [Display(Name = "Number of Days")]
        public int NumberOfDays { get; set; }
        [Display(Name = "Allocation Period")]
        public PeriodVM Period { get; set; }= new PeriodVM();

        public LeaveTypesReadOnly? leaveType { get; set; } = new LeaveTypesReadOnly();

    }
}
