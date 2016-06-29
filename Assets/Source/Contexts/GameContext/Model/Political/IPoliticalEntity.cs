using System.Collections.Generic;
using Assets.Source.Contexts.GameContext.Model.Political.Diplomacy;
using Assets.Source.Core.Model;

namespace Assets.Source.Contexts.GameContext.Model.Political
{
    public interface IPoliticalEntity : IIdentifiable
    {
        string Name { get; set; }

        IList<ITreaty> Treaties { get; }  

        ICity Capital { get; set; }
    }
}