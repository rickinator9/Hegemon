using Assets.Source.Contexts.GameContext.Model.Dates.Months;

namespace Assets.Source.Contexts.GameContext.Model.Dates
{
    public class RealisticDate : IDate
    {
        public byte Day { get; set; }
        public IMonth Month { get; set; }
        public int Year { get; set; }

        public bool IsLeapYear
        {
            get { return (Year%4 == 0 && Year%400 != 0); }
        }

        private int DaysInThisMonth
        {
            get { return IsLeapYear ? Month.LeapYearDays : Month.Days; }
        }

        private int DaysInThisYear
        {
            get { return IsLeapYear ? 366 : 365; }
        }

        public IDate AddDays(int days)
        {
            throw new System.NotImplementedException();

        }

        public IDate RemoveDays(int days)
        {
            throw new System.NotImplementedException();
        }

        public IDate AddMonths(int months)
        {
            throw new System.NotImplementedException();
        }

        public IDate RemoveMonths(int months)
        {
            throw new System.NotImplementedException();
        }

        public IDate AddYears(int years)
        {
            throw new System.NotImplementedException();
        }

        public IDate RemoveYears(int years)
        {
            throw new System.NotImplementedException();
        }
    }
}