using System.Collections.Generic;
using Assets.Source.Utilities.IoC;
using strange.extensions.signal.impl;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.Contexts.GameContext.View
{
    public class TimerView : InitialisableView
    {
        public Text CurrentDateText;
        public Image StatusImage;

        public Signal<float> TickSignal = new Signal<float>();

        private bool _isPaused = true;
        private int _speed = 1;

        private readonly Dictionary<int, float> _secondsPerDayPerSpeed = new Dictionary<int, float>
        {
            {1, 6f},
            {2, 3f},
            {3, 1f},
            {4, 0.75f},
            {5, 0.1f}
        };

        public void Update()
        {
            if (_isPaused) return;

            TickSignal.Dispatch(Time.deltaTime / _secondsPerDayPerSpeed[_speed]);
        }

        public void OnTogglePause()
        {
            _isPaused = !_isPaused;
        }

        public void OnSpeedIncrease()
        {
            if (_speed != 5)
                _speed++;
        }

        public void OnSpeedDecrease()
        {
            if (_speed > 1)
                _speed--;
        }
    }
}
