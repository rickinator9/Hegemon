namespace Assets.Source.Contexts.GameContext.Model.Characters
{
    public interface IZygote
    {
        Gender Gender { get; set; }
        
        int Fetuses { get; set; } 
    }
}