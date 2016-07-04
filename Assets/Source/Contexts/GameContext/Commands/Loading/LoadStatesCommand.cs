using Assets.Source.Contexts.GameContext.Context;
using Assets.Source.Contexts.GameContext.Model.Political;
using Assets.Source.Contexts.GameContext.Model.Political.Impl;
//using Assets.Source.Utilities.Log;
//using log4net;

namespace Assets.Source.Contexts.GameContext.Commands.Loading
{
    public class AsyncLoadStatesCommand : BaseAsyncLoadCommand<IState, StateProperty>
    {
        //private static readonly ILog Logger = GameLogManager.GetLogger<LoadStatesCommand>();

        #region From signal

        #endregion

        #region Dependencies

        #endregion

        #region Dispatchers

        #endregion

        protected override string Directory
        {
            get { return GameConstants.Directories.CommonStates; }
        }

        protected override LoadStatus LoadStatus
        {
            get { return LoadStatus.LoadStates; }
        }
    }
}