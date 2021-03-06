﻿using System.Security.AccessControl;
using UnityEngine;

namespace Assets.Source.Contexts.GameContext.Context
{
    public class GameConstants
    {
        public struct Directories
        {
            public static string Root { get; set; }

            public static readonly string Common = Root + @"Common/";
            public static readonly string CommonCities = Common + @"Cities/";
            public static readonly string CommonResources = Common + @"Resources/";
            public static readonly string CommonStates = Common + @"States/";

            public static readonly string Map = Root + @"Map/";
        } 
    }
}