namespace Assets.Source.Contexts.GameContext.Model.Dates.Months
{
    public class RealisticMonth : IMonth
    {
        public byte Days { get; set; }
        public byte LeapYearDays { get; set; }
        public byte MonthNumber { get; set; }
        public string MonthName { get; set; }
    }
}