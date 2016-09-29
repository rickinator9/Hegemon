namespace Assets.Source.Contexts.GameContext.Model.Dates.Months
{
    public class RealisticMonth : IMonth
    {
        public int Days { get; set; }
        public int LeapYearDays { get; set; }
        public int MonthNumber { get; set; }
        public string MonthName { get; set; }
    }
}