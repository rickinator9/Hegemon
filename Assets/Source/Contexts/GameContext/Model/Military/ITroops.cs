using System.Runtime.InteropServices;

namespace Assets.Source.Contexts.GameContext.Model.Military
{
    public interface ITroops
    {
        ITroopType Type { get; set; }
        
        int Number { get; set; }

        IUnit Unit { get; set; }
    }
}