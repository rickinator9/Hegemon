using Assets.Source.Contexts.GameContext.Signals;
using Assets.Source.Utilities.IoC;
//using Assets.Source.Utilities.Log;
//using log4net;

namespace Assets.Source.Contexts.GameContext.View.Mediator
{
    class FrameMediator : ViewMediator<FrameView>
    {
        //private static readonly ILog Logger = GameLogManager.GetLogger<FrameMediator>();

        #region Listens to signals

        #endregion

        #region Dependencies

        #endregion

        #region Dispatchers
        [Inject]
        public FrameSignal FrameDispatcher { get; set; }
        #endregion

        public override void OnRegister()
        {
            base.OnRegister();

            View.FrameSignal.AddListener(OnFrame);
        }

        private void OnFrame()
        {
            FrameDispatcher.Dispatch();
        }
    }
}