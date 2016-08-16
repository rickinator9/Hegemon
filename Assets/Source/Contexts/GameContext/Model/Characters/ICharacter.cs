using Assets.Source.Contexts.GameContext.Model.Dates;

namespace Assets.Source.Contexts.GameContext.Model.Characters
{
    public interface ICharacter
    {
        string FirstName { get; set; }

        IDynasty Dynasty { get; set; }

        ICharacter Father { get; set; }
        ICharacter Mother { get; set; }

        IDate BirthDate { get; set; }
    }
}