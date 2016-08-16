using System.IO;
using Assets.Source.Contexts.GameContext.Context;
using Assets.Source.Contexts.GameContext.Signals.Loading;
using Assets.Source.Utilities.IoC;
using strange.extensions.command.impl;
using UnityEngine;

//using Assets.Source.Utilities.Log;
//using log4net;

namespace Assets.Source.Contexts.GameContext.Commands.Loading
{
    public class LoadTerrainHeightmapCommand : AsyncCommand
    {
        //private static readonly ILog Logger = GameLogManager.GetLogger<LoadTerrainHeightmapCommand>();

        #region From signal

        #endregion

        #region Dependencies
        [Inject(GameContextKeys.TerrainComponent)]
        public Terrain Terrain { get; set; }
        #endregion

        #region Dispatchers
        [Inject]
        public LoadingDoneSignal LoadingDoneDispatcher { get; set; }
        #endregion

        private byte[] binaryImageData;

        protected override void Run()
        {
            var filePath = GameConstants.Directories.Map + "heightmap.png";
            if (File.Exists(filePath))
                binaryImageData = File.ReadAllBytes(filePath);
        }

        protected override void OnFinish()
        {
            LoadingDoneDispatcher.Dispatch(LoadStatus.LoadTerrainHeightmap);
            if (binaryImageData == null) return;
            
            var texture = new Texture2D(1,1);
            texture.LoadImage(binaryImageData);

            var width = texture.width;
            var height = texture.height;
            if (width > height) width = height;
            else if (height > width) height = width;

            var elevationScalar = 0.085f;

            var heightData = new float[width, height];
            for(var x = 0; x < width; x++)
            {
                for(var y = 0; y < height; y++)
                {
                    var color = texture.GetPixel(x, y);
                    var elevation = (color.r + color.g + color.b)/3;
                    if (elevation*255 > 87)
                    {
                        var elevationAboveSeaLevel = (elevation*255 - 87)/255;
                        var scaledElevation = elevationAboveSeaLevel*elevationScalar;
                        elevation = 87f/255f + scaledElevation;
                    }
                    heightData[width - x - 1, y] = elevation;
                }
            }

            var terrainData = Terrain.terrainData;
            terrainData.heightmapResolution = width;
            terrainData.size = new Vector3(width, 255, height);
            terrainData.SetHeights(0, 0, heightData);
        }
    }
}