﻿namespace LeaveManagementSystem.Web.Models.LeaveAllocation
{
    public class EmployeeLeaveAllocationVM 
    {
        public string Id { get; set; }
         [Display(Name ="First Name")]
        public string ? FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string ? LastName { get; set; }
        [Display(Name ="Date Of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateOnly DateOfBirth { get; set; }

        [Display(Name = "Email Address")]
        public string Email { get; set; }

        public List<LeaveAllocationVM> LeaveAllocations { get; set; } = new List<LeaveAllocationVM>();

    }
}
