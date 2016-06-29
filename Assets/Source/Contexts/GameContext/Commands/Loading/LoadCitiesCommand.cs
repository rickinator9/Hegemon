using Assets.Source.Contexts.GameContext.Context;
using Assets.Source.Contexts.GameContext.Model;
using Assets.Source.Core.Parser.DataParser.Properties;
using strange.extensions.command.impl;
//using Assets.Source.Utilities.Log;
//using log4net;

namespace Assets.Source.Contexts.GameContext.Commands.Loading
{
    public class LoadCitiesCommand : BaseLoadCommand<ICity, CityProperty>
    {
        //private static readonly ILog Logger = GameLogManager.GetLogger<LoadCitiesCommand>();

        #region From signal

        #endregion

        #region Dependencies

        #endregion

        #region Dispatchers

        #endregion

        protected override string Directory
        {
            get { return GameConstants.Directories.CommonCities; }
        }
    }
}