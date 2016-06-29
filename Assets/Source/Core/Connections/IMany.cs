namespace Assets.Source.Core.Connections
{
    public interface IMany<TMany, TThis>
    {
         TMany[] Values { get; }

         TThis Value { get; set; }
    }
}