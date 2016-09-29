namespace Assets.Source.Contexts.GameContext.Model.Dates.Months
{
    public interface IMonth
    {
        int Days { get; set; }
        int LeapYearDays { get; set; }
        int MonthNumber { get; set; }
        string MonthName { get; set; }
    }
}