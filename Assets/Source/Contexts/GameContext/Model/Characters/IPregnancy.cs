using Assets.Source.Contexts.GameContext.Model.Dates;

namespace Assets.Source.Contexts.GameContext.Model.Characters
{
    public interface IPregnancy
    {
        IDate ConceptionDate { get; set; }

        Gender[] Fetuses { get; set; }

        IMaleCharacter BiologicalFather { get; set; }
        IFemaleCharacter Mother { get; set; }
    }
}