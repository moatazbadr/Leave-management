namespace LeaveManagementSystem.Web.Models.Period
{
    public class PeriodVM
    {
        public int Id { get; set; }
        [Display(Name = "Start Date")]
        public DateOnly StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateOnly EndDate { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; } = string.Empty;
    }
}
