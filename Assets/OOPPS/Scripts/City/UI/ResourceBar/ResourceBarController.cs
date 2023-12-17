using OOPPS.Core;
using OOPPS.Core.Mvc;
using OOPPS.Utilities;

namespace OOPPS.City.UI.ResourceBar
{
    public class ResourceBarController : IController, IUpdatable
    {
        private readonly ResourceView _view;
        private readonly ResourceView _woods;
        private readonly ResourceView _money;
        private readonly ResourceView _diamonds;
        private readonly PlayingResources _resources;

        public ResourceBarController(ResourceView woods,
            ResourceView money,
            ResourceView diamonds,
            PlayingResources resources)
        {
            _woods = woods;
            _money = money;
            _diamonds = diamonds;
            _resources = resources;
        }

        public void Update()
        {
            _woods.SetText(_resources.Woods.ToIntegerString());
            _money.SetText(_resources.Coins.ToIntegerString());
            _diamonds.SetText(_resources.Diamonds.ToIntegerString());
        }
    }
}