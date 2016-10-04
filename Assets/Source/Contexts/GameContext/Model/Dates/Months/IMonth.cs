using System.Collections.Generic;
using System.Linq;

namespace Assets.Source.Contexts.GameContext.Model.Dates.Months
{
    public interface IMonth
    {
        byte Days { get; set; }
        byte LeapYearDays { get; set; }
        byte MonthNumber { get; set; }
        string MonthName { get; set; }
    }

    public class MonthManager
    {
        private Dictionary<int, IMonth> _months;

        public IMonth[] Months
        {
            get { return _months.Values.ToArray(); }
        }

        private static MonthManager _instance;
        public static MonthManager Instance
        {
            get { return _instance ?? (_instance = new MonthManager()); }
        }

        public void AddMonth(IMonth month)
        {
            _months[month.MonthNumber] = month;
        }
    }
}