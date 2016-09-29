namespace Assets.Source.Core.Connections
{
    public interface IOneDominant<TDominant, out TSubmissive>
    {
        TDominant Value { get; }

        TSubmissive GetSubmissiveForDominant(TDominant submissive);

        TSubmissive[] GetSubmissivesForDominant(TDominant submissive);
    }

    public interface IOneSubmissive<TDominant, in TSubmissive>
    {
        void Register(TSubmissive submissive);

        void Unregister(TSubmissive submissive);

        TDominant GetDominantForSubmissive(TSubmissive submissive);
    }
}