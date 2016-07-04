using Assets.Source.Contexts.GameContext.Context;
using Assets.Source.Contexts.GameContext.Model;
using Assets.Source.Core.Parser.DataParser.Properties;
using strange.extensions.command.impl;
using UnityEngine;

//using Assets.Source.Utilities.Log;
//using log4net;

namespace Assets.Source.Contexts.GameContext.Commands.Loading
{
    public class AsyncLoadCitiesCommand : BaseAsyncLoadCommand<ICity, CityProperty>
    {
        //private static readonly ILog Logger = GameLogManager.GetLogger<LoadCitiesCommand>();

        #region From signal

        #endregion

        #region Dependencies
        [Inject(GameContextKeys.WorldSpaceCanvas)]
        public GameObject WorldSpaceCanvas { get; set; }
        #endregion

        #region Dispatchers

        #endregion

        protected override string Directory
        {
            get { return GameConstants.Directories.CommonCities; }
        }

        protected override LoadStatus LoadStatus
        {
            get { return LoadStatus.LoadCities; }
        }

        protected override void OnFinish()
        {
            base.OnFinish();

            var cityPrefab = Resources.Load<GameObject>(@"Prefabs\City");
            var cityUiPrefab = Resources.Load<GameObject>(@"Prefabs\UI\City Panel");

            foreach (var city in Manager.ToArray)
            {
                var vector3 = new Vector3(city.Position.x, 0f, city.Position.y);
                var cityGo = GameObject.Instantiate(cityPrefab, vector3, Quaternion.identity);
                var cityPanelGo = (GameObject)GameObject.Instantiate(cityUiPrefab, vector3, Quaternion.identity);
                cityPanelGo.transform.SetParent(WorldSpaceCanvas.transform, true);
            }
        }
    }
}