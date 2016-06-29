using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.impl;
using UnityEngine;

namespace Assets.Source.Utilities.IoC
{
	class SignalContext : MVCSContext
	{
		public SignalContext(MonoBehaviour view) : base(view) { }
		public SignalContext(MonoBehaviour view, bool autoStartup) :base(view, autoStartup) { }

		protected override void addCoreComponents()
		{
			base.addCoreComponents();

			injectionBinder.Unbind<ICommandBinder>();
			injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
		}
	}
}
