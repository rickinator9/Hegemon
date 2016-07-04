using System.Collections.Generic;
using Assets.Source.Contexts.GameContext.Context;
using Assets.Source.Contexts.GameContext.Model;
using Assets.Source.Contexts.GameContext.Signals.Loading;
using Assets.Source.Core.Parser.DataParser.Converters;
using strange.extensions.command.impl;
using UnityEngine;

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
        public LoadSignal LoadDispatcher { get; set; }
        #endregion

        public override void Execute()
        {
            GameConstants.Directories.Root = Application.dataPath + @"/../";

            var overlayCanvas = GameObject.Find("OverlayCanvas");
            injectionBinder.Bind<GameObject>().ToValue(overlayCanvas).ToName(GameContextKeys.OverlayCanvas);
            var worldSpaceCanvas = GameObject.Find("WorldSpaceCanvas");
            injectionBinder.Bind<GameObject>().ToValue(worldSpaceCanvas).ToName(GameContextKeys.WorldSpaceCanvas);

            var floatConverter = new FloatConverter();
            var stringConverter = new StringConverter();
            var vector2Converter = new Vector2Converter();

            LoadDispatcher.Dispatch();
        }
    }
}