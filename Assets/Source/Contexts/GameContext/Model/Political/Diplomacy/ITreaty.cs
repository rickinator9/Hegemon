using System.Runtime.InteropServices;
using UnityEngineInternal;

namespace Assets.Source.Contexts.GameContext.Model.Political.Diplomacy
{
    public interface ITreaty
    {
        IPoliticalEntity Signatory1 { get; set; }
        IPoliticalEntity Signatory2 { get; set; }
    }
}