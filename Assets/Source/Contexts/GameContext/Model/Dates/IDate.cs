using Assets.Source.Contexts.GameContext.Model.Dates.Months;

namespace Assets.Source.Contexts.GameContext.Model.Dates
{
    public interface IDate
    {
        byte Day { get; set; }
        IMonth Month { get; set; }
        int Year { get; set; }

        bool IsLeapYear { get; }

        IDate AddDays(int days);
        IDate RemoveDays(int days);

        IDate AddMonths(int months);
        IDate RemoveMonths(int months);

        IDate AddYears(int years);
        IDate RemoveYears(int years);
    }
}
