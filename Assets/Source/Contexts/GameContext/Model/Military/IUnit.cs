using Assets.Source.Contexts.GameContext.Model.Characters;

namespace Assets.Source.Contexts.GameContext.Model.Military
{
    public interface IUnit
    {
        ICharacter Commander { get; set; }

        IArmy Army { get; set; }

        ITroops[] Troops { get; }

        ICity CityOfOrigin { get; set; }
    }
}