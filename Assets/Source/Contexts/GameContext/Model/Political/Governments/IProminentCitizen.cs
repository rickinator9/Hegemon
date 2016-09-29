using Assets.Source.Contexts.GameContext.Model.Characters;

namespace Assets.Source.Contexts.GameContext.Model.Political.Governments
{
    public interface IProminentCitizen
    {
        ICharacter Character { get; set; }
        
        int Popularity { get; set; } 
    }
}