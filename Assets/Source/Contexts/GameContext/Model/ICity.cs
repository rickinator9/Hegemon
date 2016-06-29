using Assets.Source.Contexts.GameContext.Context;
using Assets.Source.Contexts.GameContext.Model.Managers;
using Assets.Source.Contexts.GameContext.Model.Political;
using Assets.Source.Core.Model;
using Assets.Source.Core.Parser.DataParser.Properties;
using strange.extensions.injector.api;
using UnityEngine;

namespace Assets.Source.Contexts.GameContext.Model
{
    public interface ICity : IIdentifiable
    {
        ICity MotherCity { get; set; }

        IState State { get; set; }
        
        bool IsCapital { get; } 
    }

    public class CityProperty : BaseDataParserProperty<ICity>
    {
        private string state { get; set; }

        public override ICity PopulateModel(IInjectionBinder injectionBinder)
        {
            var city = injectionBinder.GetInstance<ICity>(GameContextKeys.NewInstance);
            city.Identifier = _id;
            var stateManager = injectionBinder.GetInstance<BaseIdentifiableManager<IState>>();
            var stateModel = stateManager[state];

            if (stateModel == null)
                Debug.Log("Could not find an existing State " + stateModel + "for city " + _id);

            city.State = stateModel;

            return city;
        }
    }
}