using Assets.Source.Contexts.GameContext.Model.Dates;

namespace Assets.Source.Contexts.GameContext.Model.Characters
{
    public interface IDeath
    {
        IDate Date { get; set; }

        ICauseOfDeath CauseOfDeath { get; set; }

        ICharacter Killer { get; set; }
    }
}