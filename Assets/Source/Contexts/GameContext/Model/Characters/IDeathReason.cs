using Assets.Source.Core.Exceptions;
using Assets.Source.Core.Model.Identifiable;

namespace Assets.Source.Contexts.GameContext.Model.Characters
{
    public interface ICauseOfDeath : IIdentifiable
    {
        bool CanHaveKiller { get; set; }

        string DefaultText { get; set; }

        string KillerText { get; set; }
    }

    public class CauseOfDeath : ICauseOfDeath
    {
        private string _identifier;

        public string Identifier
        {
            get { return _identifier; }
            set
            {
                if(!string.IsNullOrEmpty(_identifier))
                    throw new OnlySettableOnceException();

                _identifier = value;
            }
        }

        private bool _canHaveKiller;
        private bool _canHaveKillerSet;
        public bool CanHaveKiller
        {
            get { return _canHaveKiller; }
            set
            {
                if(_canHaveKillerSet == true)
                    throw new OnlySettableOnceException();

                _canHaveKillerSet = true;
                _canHaveKiller = value;
            }
        }

        public string DefaultText { get; set; }
        public string KillerText { get; set; }
    }
}