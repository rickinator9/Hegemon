using Assets.Source.Contexts.GameContext.Model.Managers;
using Assets.Source.Contexts.GameContext.Model.Political.Diplomacy;

namespace Assets.Source.Contexts.GameContext.Model.Political
{
    public interface IState : IPoliticalEntity
    {
        ILeague League { get; set; }

        ICity[] Cities { get; }
    }

    public class StateManager : IdentifiableManager<IState>
    {
    }
}