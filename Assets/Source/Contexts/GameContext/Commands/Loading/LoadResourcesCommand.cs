using Assets.Source.Contexts.GameContext.Context;
using Assets.Source.Contexts.GameContext.Model;
using Assets.Source.Core.Parser.DataParser;
using Assets.Source.Core.Parser.DataParser.Properties;
using Assets.Source.Core.Parser.DataParser.Types;
using strange.extensions.command.impl;

namespace Assets.Source.Contexts.GameContext.Commands.Loading
{
    public class AsyncLoadResourcesCommand : BaseAsyncLoadCommand<IResource, ResourceProperty>
    {
        #region From signal

        #endregion

        #region Dependencies
        #endregion

        #region Dispatchers

        #endregion

        protected override string Directory
        {
            get { return GameConstants.Directories.CommonResources; }
        }

        protected override LoadStatus LoadStatus
        {
            get { return LoadStatus.LoadResources; }
        }
    }
}