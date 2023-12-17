using OOPPS.Core;
using OOPPS.Core.Mvc;
using OOPPS.Utilities;

namespace OOPPS.City.UI.ResourceBar
{
    public class EnergyBarController : IController, IUpdatable
    {
        private readonly ResourceView _view;
        private readonly PlayingResources _resources;

        public EnergyBarController(ResourceView view,
            PlayingResources resources,
            ResourcesConfig config)
        {
            _view = view;
            _resources = resources;
        }
        
        public void Update()
        {
            _view.SetText(_resources.Energy.Value.ToIntegerString());
        }
    }
}