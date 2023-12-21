using System;
using OOPPS.Core;
using OOPPS.Core.Mvc;
using OOPPS.Utilities;

namespace OOPPS.City.UI.ResourceBar
{
    public class EnergyBarController : IController, IUpdatable
    {
        private readonly EnergyBarView _view;
        private readonly PlayingResources _resources;
        private readonly IResourcesController _resourcesCtrl;

        public EnergyBarController(EnergyBarView view, PlayingResources resources, IResourcesController resourcesCtrl)
        {
            _view = view;
            _resources = resources;
            _resourcesCtrl = resourcesCtrl;
        }
        
        public void Update()
        {
            _view.SetText(_resources.Energy.Value.ToIntegerString());
            _view.SetTime(_resourcesCtrl.IsFull() ? "" : _resourcesCtrl.GetTimeToReset().ToTimeString());
        }
    }
}