using System.Collections.Generic;
using Assets.Source.Contexts.GameContext.Context;
using Assets.Source.Contexts.GameContext.Model.Connections;
using Assets.Source.Contexts.GameContext.Model.Military;
using Assets.Source.Contexts.GameContext.Model.Political.Diplomacy;
using Assets.Source.Core.Connections;
using Assets.Source.Core.Model.Identifiable.Managers;
using Assets.Source.Core.Parser.DataParser.Properties;
using strange.extensions.injector.api;

namespace Assets.Source.Contexts.GameContext.Model.Political
{
    public interface IState : IPoliticalEntity
    {
        ILeague League { get; set; }

        ICity[] Cities { get; }

        IArmy[] Armies { get; }
    }
    public class State : IState
    {
        public string Identifier { get; set; }
        public string Name { get; set; }
        public IList<ITreaty> Treaties { get; private set; }
        public ICity Capital { get; set; }

        private IOne<ILeague, IState> _oneLeague;
        public ILeague League { get; set; }

        private readonly IMany<ICity, IState> _manyCities;
        public ICity[] Cities { get { return _manyCities.Values; } }

        private readonly IMany<IArmy, IState> _manyArmies; 
        public IArmy[] Armies { get { return _manyArmies.Values; } }

        public State()
        {
            _manyCities = new OneStateManyCitiesConnection(this);
        }
    }

    public class StateProperty : BaseDataParserProperty<IState>
    {
        public override IState PopulateModel(IInjectionBinder injectionBinder)
        {
            var state = injectionBinder.GetInstance<IState>(GameContextKeys.NewInstance);
            state.Identifier = _id;

            return state;
        }
    }

    public class StateManager : IdentifiableManager<IState>
    {
    }
}