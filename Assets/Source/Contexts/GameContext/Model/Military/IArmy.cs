using Assets.Source.Contexts.GameContext.Model.Characters;
using Assets.Source.Contexts.GameContext.Model.Political;

namespace Assets.Source.Contexts.GameContext.Model.Military
{
    public interface IArmy
    {
        ICharacter Commander { get; set; }

        IUnit[] Units { get; }

        IState State { get; set; }
    }
}