using strange.extensions.mediation.impl;

namespace Assets.Source.Utilities.IoC
{
    public class ViewMediator<T> : Mediator where T : InitialisableView
    {
        [Inject]
        public T View { get; set; }

        public override void OnRegister()
        {
            base.OnRegister();

            View.Initialise();
        }
    }
}