using Assets.Source.Contexts.GameContext.Context;
using Assets.Source.Contexts.GameContext.Model;
using Assets.Source.Core.Parser.DataParser.Properties;
using strange.extensions.command.impl;
using UnityEngine;

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

        public override void Execute()
        {
            base.Execute();

            var cityPrefab = Resources.Load<GameObject>(@"Prefabs\City");

            foreach (var city in Manager.ToArray)
            {
                Debug.Log(city.Position);
                var cityGo = GameObject.Instantiate(cityPrefab, new Vector3(city.Position.x, 0f, city.Position.y), Quaternion.identity);
            }
        }
    }
}