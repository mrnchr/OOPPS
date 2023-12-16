using System;
using System.Collections;
using OOPPS.Core;
using UnityEngine;

namespace OOPPS.City.InputSystem
{
    public class CityInputController : ICityInputController
    {
        private readonly ICoroutineRunner _runner;
        private CityInputData _data;
        public CityInputData Data => _data;
        public event Action<CityInputData> OnInputHandled;

        public CityInputController(ICoroutineRunner runner)
        {
            _runner = runner;
            _runner.RunCoroutine(HandleRoutine());
        }
        
        public void Handle()
        {
            Clear();

            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
            {
                _data.Tap = true;
                _data.TapData = Input.touches[0].position;
            }

            OnInputHandled?.Invoke(_data);
        }

        public void Clear()
        {
            _data = new CityInputData();
        }

        private IEnumerator HandleRoutine()
        {
            while(true)
            {
                yield return null;
                Handle();
            }
        }
    }

    public interface ICityInputController : IInputController<CityInputData>
    {
    }
}