namespace Assets.Source.Core.Model
{
    public interface IIdentifiable
    {
        /// <summary>
        /// Unique identifier for the identifiable object. Can only be set once.
        /// </summary>
        string Identifier { get; set; } 
    }
}