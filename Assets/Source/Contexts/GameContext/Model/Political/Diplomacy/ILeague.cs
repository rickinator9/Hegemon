namespace Assets.Source.Contexts.GameContext.Model.Political.Diplomacy
{
    public interface ILeague : IPoliticalEntity
    {
         IState[] Members { get; }
    }
}