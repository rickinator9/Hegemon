using Assets.Source.Contexts.GameContext.Model.Dates;
using strange.extensions.injector.api;

namespace Assets.Source.Contexts.GameContext.Model.Characters
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPregnancy
    {
        IDate ConceptionDate { get; }

        Gender[] Fetuses { get; }

        IMaleCharacter BiologicalFather { get; }
        IFemaleCharacter Mother { get; }
    }
}