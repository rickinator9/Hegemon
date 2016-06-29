namespace Assets.Source.Core.Connections
{
    public interface IOne<TOne, TThis>
    {
        void Register(TThis value);

        TOne Unregister(TThis value);
        
        TOne Value { get; } 
    }
}