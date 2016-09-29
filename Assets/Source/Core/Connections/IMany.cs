namespace Assets.Source.Core.Connections
{
    public interface IManyDominant<TDominant, out TSubmissive>
    {
        TDominant Value { get; }

        TSubmissive[] GetSubmissivesForDominant(TDominant dominant);
    }

    public interface IManySubmissive<TDominant, in TSubmissive>
    {
        void AddDominant(TDominant dominant, TSubmissive submissive);

        void RemoveDominant(TDominant dominant, TSubmissive submissive);

        TDominant GetDominantForSubmissive(TSubmissive submissive);

        TDominant[] GetDominantsForSubmissive(TSubmissive submissive);
    }
}