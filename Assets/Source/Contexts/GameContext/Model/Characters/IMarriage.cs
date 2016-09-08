using Assets.Source.Contexts.GameContext.Model.Dates;
using Assets.Source.Core.Exceptions;

namespace Assets.Source.Contexts.GameContext.Model.Characters
{
    public enum MarriageStatus
    {
        Bethrothed,
        Marriage,
        Divorced,
        Widowhood
    }

    public interface IMarriage
    {
        ICharacter One { get; set; }
        
        ICharacter Other { get; set; }
        
        MarriageStatus Status { get; set; }
        
        bool IsActive { get; }

        bool IsSameSex { get; }

        IDate StartDate { get; set; }

        IDate EndDate { get; set; }
        
        ICharacter GetSpouseOf(ICharacter character);
    }

    public class Marriage : IMarriage
    {
        private ICharacter _one;
        public ICharacter One
        {
            get { return _one; }
            set
            {
                if(_one != null)
                    throw new OnlySettableOnceException();

                _one = value;
            }
        }

        private ICharacter _other;
        public ICharacter Other
        {
            get { return _other; }
            set
            {
                if (_other != null)
                    throw new OnlySettableOnceException();

                _other = value;
            }
        }

        public MarriageStatus Status { get; set; }

        public bool IsActive
        {
            get { return Status == MarriageStatus.Divorced || Status == MarriageStatus.Widowhood; }
        }

        public bool IsSameSex
        {
            get { return One.Gender == Other.Gender; }
        }

        private IDate _startDate;
        public IDate StartDate
        {
            get { return _startDate; }
            set
            {
                if(_startDate != null)
                    throw new OnlySettableOnceException();

                _startDate = value;
            }
        }

        private IDate _endDate;
        public IDate EndDate
        {
            get { return _endDate; }
            set
            {
                if(_endDate != null)
                    throw new OnlySettableOnceException();

                _endDate = value;
            }
        }

        public ICharacter GetSpouseOf(ICharacter thisCharacter)
        {
            return One == thisCharacter ? One : Other;
        }
    }
}