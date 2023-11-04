using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace OOPPS
{
    public class Controller : MonoBehaviour
    {
        public ControlButton[] Buttons;
        public Action<int> OnMove;
        public int Direction;

        private void SetDirection(int direction) => Direction += direction;

        private void Update()
        {
            CalculateDirection();
            OnMove?.Invoke(Direction);
        }

        private void CalculateDirection()
        {
            Direction = 0;
            foreach (ControlButton button in Buttons)
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
    }
}