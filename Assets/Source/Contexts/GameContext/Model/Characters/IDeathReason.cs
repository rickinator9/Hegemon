using Assets.Source.Core.Model.Identifiable;

namespace Assets.Source.Contexts.GameContext.Model.Characters
{
    public interface IDeathReason : IIdentifiable
    {
        bool CanHaveKiller { get; }

        string DefaultText { get; set; }

        string KillerText { get; set; }
    }
}