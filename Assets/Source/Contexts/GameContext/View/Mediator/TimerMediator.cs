using Assets.Source.Contexts.GameContext.Model;
using Assets.Source.Contexts.GameContext.Model.Managers;
using Assets.Source.Contexts.GameContext.Model.Political;
using Assets.Source.Contexts.GameContext.Signals;
using Assets.Source.Utilities.IoC;
using UnityEngine;

namespace Assets.Source.Contexts.GameContext.View.Mediator
{
    class TimerMediator : ViewMediator<TimerView>
    {

        #region Dependencies
        [Inject]
        public BaseIdentifiableManager<IState> StateManager { get; set; }
        #endregion

        #region Dispatchers
        [Inject]
        public GameTickSignal GameTickDispatcher { get; set; }
        #endregion

        private float _dayAccumulator;

        public override void OnRegister()
        {
            base.OnRegister();

            View.TickSignal.AddListener(OnTick);
        }

        private void OnTick(float partOfDay)
        {
            Debug.Log(partOfDay);
            GameTickDispatcher.Dispatch(partOfDay);

            _dayAccumulator += partOfDay;

        }
    }
}