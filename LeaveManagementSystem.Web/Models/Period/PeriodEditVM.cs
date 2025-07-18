namespace LeaveManagementSystem.Web.Models.Period
{
    public class PeriodEditVM :BaseEntity
    {
        public string Name { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }
}
