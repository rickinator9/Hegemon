using Assets.Source.Contexts.GameContext.Model.Dates.Months;
using UnityEngine;

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

        public RealisticDate(byte day, IMonth month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public RealisticDate(byte day, byte month, int year) : this(day, MonthManager.Instance.Months[month-1], year) { }

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
            return DateManager.Instance.GetDate(Day, Month, Year - years);
        }

        public IDate RemoveYears(int years)
        {
            return DateManager.Instance.GetDate(Day, Month, Year - years);
        }

        public override string ToString()
        {
            return Day + " " + Month.MonthName + ", " + Year;
        }
    }
}