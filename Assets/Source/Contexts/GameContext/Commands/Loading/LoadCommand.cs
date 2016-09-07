using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Source.Contexts.GameContext.Signals;
using Assets.Source.Contexts.GameContext.Signals.Loading;
using strange.extensions.command.impl;
using strange.extensions.signal.impl;

//using Assets.Source.Utilities.Log;
//using log4net;

namespace Assets.Source.Contexts.GameContext.Commands.Loading
{
    public enum LoadStatus
    {
        LoadCities,
        LoadStates,
        LoadResources,

        TerrainInitialise,
        LoadTerrainHeightmap
    }

    public class LoadCommand : Command
    {
        //private static readonly ILog Logger = GameLogManager.GetLogger<LoadCommand>();

        #region From signal
        [Inject]
        public FrameSignal FrameSignal { get; set; }

        [Inject]
        public LoadingDoneSignal LoadingDoneSignal { get; set; }
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

        [Inject]
        public TerrainInitialiseSignal TerrainInitialiseDispatcher { get; set; }

        [Inject]
        public LoadTerrainHeightmapSignal LoadTerrainHeightmapDispatcher { get; set; }
        #endregion
        
        private IList<LoadCall> _loadCalls;

        public override void Execute()
        {
            _loadCalls = new List<LoadCall>
            {
                new LoadCall {LoadStatus = LoadStatus.LoadStates, CallSignal = LoadStatesDispatcher, Dependencies = new HashSet<LoadStatus>()},
                new LoadCall {LoadStatus = LoadStatus.LoadCities, CallSignal = LoadCitiesDispatcher, Dependencies = new HashSet<LoadStatus> {LoadStatus.LoadStates}},
                new LoadCall {LoadStatus = LoadStatus.LoadResources, CallSignal = LoadResourcesDispatcher, Dependencies = new HashSet<LoadStatus>()},

                new LoadCall {LoadStatus = LoadStatus.TerrainInitialise, CallSignal = TerrainInitialiseDispatcher, Dependencies = new HashSet<LoadStatus>()},
                new LoadCall {LoadStatus = LoadStatus.LoadTerrainHeightmap, CallSignal = LoadTerrainHeightmapDispatcher, Dependencies = new HashSet<LoadStatus> {LoadStatus.TerrainInitialise}}
            };

            FrameSignal.AddListener(OnFrame);
            LoadingDoneSignal.AddListener(OnLoadingDone);

            Retain();
        }

        private void OnFrame()
        {
            if (_loadCalls.Count == 0)
            {
                OnFinish();
                return;
            }

            for (var i = _loadCalls.Count - 1; i >= 0; i--)
            {
                var loadCall = _loadCalls[i];
                if (!loadCall.Called && loadCall.Dependencies.Count == 0)
                {
                    loadCall.Called = true;
                    loadCall.CallSignal.Dispatch();
                }
            }
        }

        private void OnFinish()
        {
            FrameSignal.RemoveListener(OnFrame);
            LoadingDoneSignal.RemoveListener(OnLoadingDone);

            Release();
        }

        private void OnLoadingDone(LoadStatus loadStatus)
        {
            for (var i = _loadCalls.Count - 1; i > 0; i--)
            {
                var loadCall = _loadCalls[i];
                if (loadCall.Dependencies.Contains(loadStatus))
                    loadCall.Dependencies.Remove(loadStatus);

                if(loadCall.LoadStatus == loadStatus)
                    _loadCalls.RemoveAt(i);
            }

            foreach (var loadCall in _loadCalls.Where(loadCall => loadCall.Dependencies.Contains(loadStatus)))
            {
                loadCall.Dependencies.Remove(loadStatus);
            }
        }

        public class LoadCall
        {
            public LoadStatus LoadStatus;
            public Signal CallSignal;
            public HashSet<LoadStatus> Dependencies;
            public bool Called = false;
        }
    }
}