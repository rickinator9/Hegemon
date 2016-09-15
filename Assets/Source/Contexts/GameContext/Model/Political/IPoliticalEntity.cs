using System.Collections.Generic;
using Assets.Source.Contexts.GameContext.Model.Political.Diplomacy;
using Assets.Source.Core.Model;
using Assets.Source.Core.Model.Identifiable;

namespace Assets.Source.Contexts.GameContext.Model.Political
{
    public interface IPoliticalEntity : IIdentifiable
    {
        string Name { get; set; }

        ITreaty[] Treaties { get; }  

        ICity Capital { get; set; }

        IState Liege { get; set; }
        bool IsVassal { get; }
    }
}