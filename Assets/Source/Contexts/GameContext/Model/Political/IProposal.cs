using Assets.Source.Contexts.GameContext.Model.Characters;

namespace Assets.Source.Contexts.GameContext.Model.Political
{
    public interface IProposal
    {
        string Name { get; set; }

        ICharacter Submitter { get; set; }

        delegate OnSuccess;
    }
}