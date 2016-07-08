using Assets.Source.Contexts.GameContext.Commands.Loading;
using strange.extensions.signal.impl;

namespace Assets.Source.Contexts.GameContext.Signals.Loading
{
    /// <summary>
    /// Sent when a loading command completed loading.
    /// </summary>
    public class LoadingDoneSignal : Signal<LoadStatus>
    {
         
    }
}