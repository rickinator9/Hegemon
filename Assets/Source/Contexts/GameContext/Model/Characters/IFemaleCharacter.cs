namespace Assets.Source.Contexts.GameContext.Model.Characters
{
    public interface IFemaleCharacter
    {
        IPregnancy Pregnancy { get; set; }

        bool IsPregnant { get; }
    }
}