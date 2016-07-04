using Assets.Source.Utilities.IoC;
using strange.extensions.signal.impl;

//using Assets.Source.Utilities.Log;
//using log4net;

namespace Assets.Source.Contexts.GameContext.View
{
    class FrameView : InitialisableView
    {
        //private static readonly ILog Logger = GameLogManager.GetLogger<FrameView>();

        #region Dispatchers
        public Signal FrameSignal = new Signal();
        #endregion

        public void Update()
        {
            FrameSignal.Dispatch();
        }
    }
}