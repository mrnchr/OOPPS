using System;
using OOPPS.Core.Mvc;
using UnityEngine;
using UnityEngine.UI;

namespace OOPPS.City.UI.BuildButton
{
    public class BuildButtonView : MonoBehaviour, IView
    {
        [SerializeField] private Button _button;
        private BuildButtonController _controller;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        public void SetController(BuildButtonController controller)
        {
            _controller = controller;
        }

        private void OnClick()
        {
            _controller.SwitchBuildMode();
        }
    }
}