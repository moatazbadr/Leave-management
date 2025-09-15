namespace LeaveManagementSystem.Application.Models.Period
{
    public class PeriodCreateVM
    {
        public string Name { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

    }
}
