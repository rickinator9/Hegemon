using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

    public class DateManager
    {
        private Dictionary<long, IDate> _dates;

        private static DateManager _instance;
        public static DateManager Instance
        {
            get { return _instance ?? (_instance = new DateManager()); }
        }

        public DateManager()
        {
            _dates = new Dictionary<long, IDate>();
        }

        public IDate GetDate(byte day, IMonth month, int year)
        {
            var dateHash = GenerateDateHash(day, month, year);
            if (!_dates.ContainsKey(dateHash))
                _dates[dateHash] = CreateDate(day, month, year);

            return _dates[dateHash];
        }

        public long GenerateDateHash(byte day, IMonth month, int year)
        {
            long dateHash = day + month.MonthNumber*1000 + Math.Abs(year)*1000000;
            if (year < 0)
                dateHash *= -1;
            return dateHash;
        }

        private IDate CreateDate(byte day, IMonth month, int year)
        {
            return new RealisticDate(day, month, year);
        }
    }
}
