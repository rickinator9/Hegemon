using Assets.Source.Contexts.GameContext.Model.Connections;
using Assets.Source.Contexts.GameContext.Model.Managers;
using Assets.Source.Contexts.GameContext.Model.Political;
using Assets.Source.Core.Connections;

namespace Assets.Source.Contexts.GameContext.Model.Impl
{
    public class City : ICity
    {
        public string Identifier { get; set; }
        public ICity MotherCity { get; set; }

        private IOne<IState, ICity> _oneState;
        public IState State
        {
            get { return _oneState != null ? _oneState.Value : null; }
            set
            {
                if (_oneState != null)
                    _oneState.Unregister(this);
                _oneState = OneStateManyCitiesConnection.GetByState(value);
                if(_oneState != null)
                    _oneState.Register(this);
            }
        }

        public bool IsCapital { get { return State.Capital == this; } }
    }
    
    public class CityManager : IdentifiableManager<ICity>
    {
    }
}