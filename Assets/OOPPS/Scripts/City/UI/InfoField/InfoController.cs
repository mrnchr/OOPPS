using System.Collections;
using OOPPS.City.Services;
using OOPPS.Core;
using OOPPS.Core.Mvc;
using UnityEngine;

namespace OOPPS.City.UI.InfoField
{
    public class InfoController : IController, IDestroyable
    {
        private readonly InfoView _view;
        private readonly ICityService _city;
        private readonly ICoroutineRunner _runner;
        private readonly InfoFieldConfig _config;
        private bool _isShowed;
        private IEnumerator _routine;

        public InfoController(InfoView view, ICityService city, ICoroutineRunner runner, InfoFieldConfig config)
        {
            _view = view;
            _city = city;
            _runner = runner;
            _config = config;
            
            _city.OnNotEnoughResources += Show;
        }

        public void Show()
        {
            if(_isShowed)
            {
                _runner.AbortCoroutine(_routine);
                _isShowed = false;
            }
            
            _routine = ShowRoutine();
            _runner.RunCoroutine(_routine);
        }

        public void Destroy()
        {
            _city.OnNotEnoughResources -= Show;
        }

        private IEnumerator ShowRoutine()
        {
            _isShowed = true;
            _view.SetActive(true);

            yield return new WaitForSeconds(_config.ShowTime);

            _view.SetActive(false);
            _isShowed = false;
        }
    }
}