using System.Collections.Generic;
using Assets.Source.Contexts.GameContext.Context;
using Assets.Source.Contexts.GameContext.Model.Characters;
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

        IGovernment Government { get; set; }

        ICity[] Cities { get; }

        ICharacter[] Characters { get; }

        IArmy[] Armies { get; }

        IPoliticalEntity[] Vassals { get; }
    }
    public class State : IState
    {
        public string Identifier { get; set; }
        public string Name { get; set; }

        // TODO: Figure out way to model treaties
        public ITreaty[] Treaties { get; private set; }
        public ICity Capital { get; set; }
        public IState Liege { get; set; }

        public bool IsVassal
        {
            get { return Liege != null; }
        }

        private IOneSubmissive<ILeague, IState> _oneLeague;
        public ILeague League { get; set; }
        public IGovernment Government { get; set; }

        private readonly IManyDominant<IState, ICity> _manyCities;
        public ICity[] Cities { get { return _manyCities.GetSubmissivesForDominant(this); } }
        public ICharacter[] Characters { get; private set; }

        private readonly IManyDominant<IState, IArmy> _manyArmies; 
        public IArmy[] Armies { get { return _manyArmies.GetSubmissivesForDominant(this); } }

        private readonly IManyDominant<IState, IPoliticalEntity> _manyVassals;
        public IPoliticalEntity[] Vassals
        {
            get { return _manyVassals.GetSubmissivesForDominant(this); }
        }

        public State()
        {
            _manyCities = new OneStateManyCitiesConnection(this);
            _manyArmies = new OneStateManyArmiesConnection(this);
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