using Assets.Source.Contexts.GameContext.Context;
using Assets.Source.Contexts.GameContext.Model.Connections;
using Assets.Source.Contexts.GameContext.Model.Political;
using Assets.Source.Core.Connections;
using Assets.Source.Core.Model;
using Assets.Source.Core.Model.Identifiable;
using Assets.Source.Core.Model.Identifiable.Managers;
using Assets.Source.Core.Parser.DataParser.Properties;
using strange.extensions.injector.api;
using UnityEngine;

namespace Assets.Source.Contexts.GameContext.Model
{
    public interface ICity : IIdentifiable
    {
        ICity MotherCity { get; set; }

        IState State { get; set; }

        Vector2 Position { get; set; }

        bool IsCapital { get; }
    }
    public class City : ICity
    {
        public string Identifier { get; set; }
        public ICity MotherCity { get; set; }

        private IOneSubmissive<IState, ICity> _oneState;
        public IState State
        {
            get { return _oneState != null ? _oneState.GetDominantForSubmissive(this) : null; }
            set
            {
                if (_oneState != null)
                    _oneState.Unregister(this);
                _oneState = OneStateManyCitiesConnection.GetByState(value);
                if (_oneState != null)
                    _oneState.Register(this);
            }
        }

        public Vector2 Position { get; set; }

        public bool IsCapital { get { return State.Capital == this; } }
    }

    public class CityManager : IdentifiableManager<ICity>
    {
    }

    public class CityProperty : BaseDataParserProperty<ICity>
    {
        private string state { get; set; }

        private Vector2 position { get; set; }

        public override ICity PopulateModel(IInjectionBinder injectionBinder)
        {
            var city = injectionBinder.GetInstance<ICity>(GameContextKeys.NewInstance);
            city.Identifier = _id;
            city.Position = position;
            var stateManager = injectionBinder.GetInstance<BaseIdentifiableManager<IState>>();
            var stateModel = stateManager[state];

            if (stateModel == null)
                Debug.Log("Could not find an existing State " + stateModel + "for city " + _id);

            city.State = stateModel;

            return city;
        }
    }
}