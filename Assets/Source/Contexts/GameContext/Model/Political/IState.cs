using Assets.Source.Contexts.GameContext.Model.Military;
using Assets.Source.Contexts.GameContext.Model.Political.Diplomacy;
using Assets.Source.Core.Model.Identifiable.Managers;

namespace Assets.Source.Contexts.GameContext.Model.Political
{
    public interface IState : IPoliticalEntity
    {
        ILeague League { get; set; }

        ICity[] Cities { get; }

        IArmy[] Armies { get; }
    }

    public class StateManager : IdentifiableManager<IState>
    {
    }
}