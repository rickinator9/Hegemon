using Assets.Source.Contexts.GameContext.Context;
using Assets.Source.Contexts.GameContext.Signals.Loading;
using Assets.Source.Utilities.IoC;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;

//using Assets.Source.Utilities.Log;
//using log4net;

namespace Assets.Source.Contexts.GameContext.Commands.Loading
{
    public class TerrainInitialiseCommand : Command
    {
        //private static readonly ILog Logger = GameLogManager.GetLogger<TerrainInitialiser>();

        #region From signal

        #endregion

        #region Dependencies
        //[Inject(ContextKeys.CONTEXT)]
        //public GameObject Context { get; set; }
        #endregion

        #region Dispatchers
        [Inject]
        public LoadingDoneSignal LoadingDoneDispatcher { get; set; }
        #endregion

        public override void Execute()
        {
            var terrainGameObject = new GameObject("Terrain");
            //terrainGameObject.transform.parent = Context.transform;
            var terrainComponent = terrainGameObject.AddComponent<Terrain>();
            terrainComponent.terrainData = new TerrainData();

            var terrainColliderComponent = terrainGameObject.AddComponent<TerrainCollider>();
            terrainColliderComponent.terrainData = terrainComponent.terrainData;

            //injectionBinder.Bind<Terrain>().ToValue(terrainComponent).ToName(GameContextKeys.TerrainComponent);

            LoadingDoneDispatcher.Dispatch(LoadStatus.TerrainInitialise);
        }
    }
}