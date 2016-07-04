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
        LoadResources
    }

    public class LoadCommand : Command
    {
        //private static readonly ILog Logger = GameLogManager.GetLogger<LoadCommand>();

        #region From signal
        [Inject]
        public FrameSignal FrameSignal { get; set; }

        [Inject]
        public LoadingDone LoadingDone { get; set; }
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

        private IList<LoadCall> LoadCalls;

        public override void Execute()
        {
            LoadCalls = new List<LoadCall>
            {
                new LoadCall {LoadStatus = LoadStatus.LoadStates, CallSignal = LoadStatesDispatcher, Dependencies = new HashSet<LoadStatus>()},
                new LoadCall {LoadStatus = LoadStatus.LoadCities, CallSignal = LoadCitiesDispatcher, Dependencies = new HashSet<LoadStatus> {LoadStatus.LoadStates}},
                new LoadCall {LoadStatus = LoadStatus.LoadResources, CallSignal = LoadResourcesDispatcher, Dependencies = new HashSet<LoadStatus>()}
            };

            FrameSignal.AddListener(OnFrame);
            LoadingDone.AddListener(OnLoadingDone);

            Retain();
        }

        private void OnFrame()
        {
            if (LoadCalls.Count == 0)
            {
                OnFinish();
                return;
            }

            foreach (var loadCall in LoadCalls)
            {
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
            LoadingDone.RemoveListener(OnLoadingDone);

            Release();
        }

        private void OnLoadingDone(LoadStatus loadStatus)
        {
            for (var i = LoadCalls.Count - 1; i > 0; i--)
            {
                var loadCall = LoadCalls[i];
                if (loadCall.Dependencies.Contains(loadStatus))
                    loadCall.Dependencies.Remove(loadStatus);

                if(loadCall.LoadStatus == loadStatus)
                    LoadCalls.RemoveAt(i);
            }

            foreach (var loadCall in LoadCalls.Where(loadCall => loadCall.Dependencies.Contains(loadStatus)))
            {
                loadCall.Dependencies.Remove(loadStatus);
            }
        }

        private class LoadCall
        {
            public LoadStatus LoadStatus;
            public Signal CallSignal;
            public HashSet<LoadStatus> Dependencies;
            public bool Called = false;
        }
    }
}