namespace Assets.Source.Contexts.GameContext.Model
{
    public interface IPopulationGroup
    {
        ISocialClass SocialClass { get; }

        ICity CityOfOrigin { get; }

        int NumberOfPeople { get; }
    }
}