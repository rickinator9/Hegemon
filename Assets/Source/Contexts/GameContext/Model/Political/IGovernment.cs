using Assets.Source.Contexts.GameContext.Model.Characters;

namespace Assets.Source.Contexts.GameContext.Model.Political
{
    public interface IGovernment
    {
        bool CanSubmitProposal(ICharacter character);
    }
}