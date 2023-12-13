using System;
using OOPPS.Core;
using UnityEngine;

namespace OOPPS
{
    public class InputController : IInputController<InputData>
    {
        private ControlButton[] _buttons;

        private InputData _data;

        public InputData Data => _data;

        public event Action<InputData> OnInputHandled;

        public InputController(ControlButton[] buttons)
        {
            _buttons = buttons;
        }

        public void Handle()
        {
            Clear();
            CalculateDirection();
            OnInputHandled?.Invoke(Data);
        }

        public void Clear()
        {
            _data = new InputData();
        }

        private void CalculateDirection()
        {
            foreach (ControlButton button in _buttons)
            {
                for (int i = 0; i < Input.touchCount; i++)
                {
                    if (button.IsInBox(Input.GetTouch(i).position))
                        SetDirection(button.InputValue);
                }
                if(Input.GetKey(KeyCode.Mouse0) && button.IsInBox(Input.mousePosition))
                    SetDirection(button.InputValue);
            }

                                
        }

        private void SetDirection(int direction) => _data.Direction += direction;
    }

    public interface IInputData
    {
    }

    public struct InputData : IInputData
    {
        public float Direction;
    }
}