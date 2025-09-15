using LeaveManagementSystem.Application.Models.Period;
using LeaveManagementSystem.Application.Models.LeaveTypes;

namespace LeaveManagementSystem.Application.Models.LeaveAllocation
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
