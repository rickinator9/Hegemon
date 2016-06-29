namespace Assets.Source.Contexts.GameContext.Model.Dates.Months
{
    public interface IMonth
    {
        int Days { get; }
        int LeapYearDays { get; }
        int MonthNumber { get; }
    }
}