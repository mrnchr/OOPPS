using OOPPS.Core.Mvc;
using UnityEngine;
using UnityEngine.UI;

namespace OOPPS.City.UI.StartButton
{
    public class StartButtonView : MonoBehaviour, IView
    {
        [SerializeField] private Image _image;
        [SerializeField] private Button _button;
        [SerializeField] private Sprite _allow;
        [SerializeField] private Sprite _disallow;
        private StartButtonController _controller;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        public void SetController(StartButtonController controller)
        {
            _controller = controller;
        }

        public void SetAllowSprite()
        {
            _image.sprite = _allow;
        }

        public void SetDisallowSprite()
        {
            _image.sprite = _disallow;
        }

        private void OnClick()
        {
            _controller.RequestStart();
        }
    }
}