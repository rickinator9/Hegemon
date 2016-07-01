using System.Collections.Generic;
using Assets.Source.Contexts.GameContext.Model;
using Assets.Source.Contexts.GameContext.Signals.Loading;
using Assets.Source.Core.Parser.DataParser.Converters;
using strange.extensions.command.impl;

namespace Assets.Source.Contexts.GameContext.Commands
{
    public class StartGameCommand : Command
    {

        #region From signal

        #endregion

        #region Dependencies
        #endregion

        #region Dispatchers
        [Inject]
        public LoadResourcesSignal LoadResourcesDispatcher { get; set; }

        [Inject]
        public LoadStatesSignal LoadStatesDispatcher { get; set; }

        [Inject]
        public LoadCitiesSignal LoadCitiesDispatcher { get; set; }
        #endregion

        public override void Execute()
        {
            var floatConverter = new FloatConverter();
            var stringConverter = new StringConverter();
            var vector2Converter = new Vector2Converter();                                       

            LoadResourcesDispatcher.Dispatch();
            LoadStatesDispatcher.Dispatch();
            LoadCitiesDispatcher.Dispatch();
        }
    }
}