using Assets.Source.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Source.Contexts.GameContext.Commands;
using Assets.Source.Contexts.GameContext.Commands.Loading;
using Assets.Source.Contexts.GameContext.Model;
using Assets.Source.Contexts.GameContext.Model.Political;
using Assets.Source.Contexts.GameContext.Signals;
using Assets.Source.Contexts.GameContext.Signals.Loading;
using Assets.Source.Contexts.GameContext.View;
using Assets.Source.Contexts.GameContext.View.Mediator;
using Assets.Source.Core.Model;
using Assets.Source.Core.Model.Identifiable.Managers;
using UnityEngine;

namespace Assets.Source.Contexts.GameContext.Context
{
	class GameContext : SignalContext
	{
		public GameContext(MonoBehaviour view) :base(view) { }
		public GameContext(MonoBehaviour view, bool autoStartup) :base(view, autoStartup) { }

		protected override void mapBindings()
		{
			base.mapBindings();

		    commandBinder.Bind<StartGameSignal>().To<StartGameCommand>();
		    commandBinder.Bind<LoadSignal>().To<LoadCommand>();
		    commandBinder.Bind<LoadResourcesSignal>().To<ParserLoadResourcesCommand>();
		    commandBinder.Bind<LoadStatesSignal>().To<ParserLoadStatesCommand>();
		    commandBinder.Bind<LoadCitiesSignal>().To<ParserLoadCitiesCommand>();
		    commandBinder.Bind<TerrainInitialiseSignal>().To<TerrainInitialiseCommand>();
		    commandBinder.Bind<LoadTerrainHeightmapSignal>().To<LoadTerrainHeightmapCommand>();

		    injectionBinder.Bind<IResource>().To<Resource>().ToName(GameContextKeys.NewInstance);
		    injectionBinder.Bind<IState>().To<State>().ToName(GameContextKeys.NewInstance);
		    injectionBinder.Bind<ICity>().To<City>().ToName(GameContextKeys.NewInstance);

		    injectionBinder.Bind<BaseIdentifiableManager<IResource>>().To<ResourceManager>().ToSingleton();
		    injectionBinder.Bind<BaseIdentifiableManager<IState>>().To<StateManager>().ToSingleton();
		    injectionBinder.Bind<BaseIdentifiableManager<ICity>>().To<CityManager>().ToSingleton();

		    injectionBinder.Bind<FrameSignal>().ToSingleton();
		    injectionBinder.Bind<GameTickSignal>().ToSingleton();
		    injectionBinder.Bind<LoadingDoneSignal>().ToSingleton();

		    mediationBinder.Bind<FrameView>().To<FrameMediator>();
		    mediationBinder.Bind<TimerView>().To<TimerMediator>();
		}

	    public override void Launch()
	    {
	        base.Launch();

	        var startSignal = injectionBinder.GetInstance<StartGameSignal>();
            startSignal.Dispatch();
	    }
	}
}
