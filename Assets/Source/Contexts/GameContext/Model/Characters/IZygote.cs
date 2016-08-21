namespace Assets.Source.Contexts.GameContext.Model.Characters
{
    /// <summary>
    /// A Zygote is an ovum that has been fertilised. This interface is used to retrieve the gender and number of children
    /// that are developed from a certain ovum.
    /// </summary>
    public interface IZygote
    {
        Gender Gender { get; }
        
        int Fetuses { get; } 
    }
}