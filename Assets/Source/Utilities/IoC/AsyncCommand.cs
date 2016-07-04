using System.Threading;
using Assets.Source.Contexts.GameContext.Signals;
using strange.extensions.command.impl;
//using Assets.Source.Utilities.Log;
//using log4net;

namespace Assets.Source.Utilities.IoC
{
    public abstract class AsyncCommand : Command
    {
        //private static readonly ILog Logger = GameLogManager.GetLogger<AsyncCommand>();

        #region From signal

        #endregion

        #region Dependencies
        [Inject]
        public FrameSignal FrameSignal { get; set; }
        #endregion

        #region Dispatchers

        #endregion

        private Thread _thread;

        public override void Execute()
        {
            Retain();

            FrameSignal.AddListener(Update);
            _thread = new Thread(Run);
            _thread.Start();
        }

        protected abstract void Run();

        private void Update()
        {
            if (!_thread.IsAlive)
            {
                FrameSignal.RemoveListener(Update);
                Release();
                OnFinish();
            }
        }

        protected abstract void OnFinish();
    }
}