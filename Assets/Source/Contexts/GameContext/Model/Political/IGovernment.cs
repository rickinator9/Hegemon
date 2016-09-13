using Assets.Source.Contexts.GameContext.Model.Characters;

namespace Assets.Source.Contexts.GameContext.Model.Political
{
    public interface IGovernment
    {
        IProposal[] OpenProposals { get; }

        bool CanSubmitProposal(ICharacter character);

        void SubmitProposal(IProposal proposal);
    }
}