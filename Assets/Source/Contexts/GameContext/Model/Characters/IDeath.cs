namespace Assets.Source.Contexts.GameContext.Model.Characters
{
    public interface IDeath
    {

        ICharacter Killer { get; set; }
    }
}