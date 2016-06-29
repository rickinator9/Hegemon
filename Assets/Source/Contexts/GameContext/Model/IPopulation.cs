using System.Collections;
using System.Collections.Generic;

namespace Assets.Source.Contexts.GameContext.Model
{
    public interface IPopulation
    {
        int TotalPopulation { get; }

        IList<IPopulationGroup> PopulationGroups { get; }
    }
}