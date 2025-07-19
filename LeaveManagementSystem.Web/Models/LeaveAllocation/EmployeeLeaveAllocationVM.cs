namespace LeaveManagementSystem.Web.Models.LeaveAllocation
{
    public class EmployeeLeaveAllocationVM  : EmployeeListVM
    {
        
       
        [Display(Name ="Date Of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateOnly DateOfBirth { get; set; }

      

        public List<LeaveAllocationVM> LeaveAllocations { get; set; } = new List<LeaveAllocationVM>();

    }
}
