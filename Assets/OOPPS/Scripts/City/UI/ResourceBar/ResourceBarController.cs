using OOPPS.Core;
using OOPPS.Core.Mvc;

namespace OOPPS.City.UI.ResourceBar
{
    public class ResourceBarController : IController, IUpdatable
    {
        private readonly ResourceView _view;
        private readonly ResourceView _woods;
        private readonly ResourceView _money;
        private readonly ResourceView _diamonds;
        private readonly ResourceView _energy;
        private readonly PlayingResources _model;

        public ResourceBarController(ResourceView woods,
            ResourceView money,
            ResourceView diamonds,
            ResourceView energy,
            PlayingResources model)
        {
            _woods = woods;
            _money = money;
            _diamonds = diamonds;
            _energy = energy;
            _model = model;
        }

        public void Update()
        {
            _woods.SetText(ToFormattedString(_model.Woods));
            _money.SetText(ToFormattedString(_model.Coins));
            _diamonds.SetText(ToFormattedString(_model.Diamonds));
            _energy.SetText(ToFormattedString(_model.Energy));
        }

        private static string ToFormattedString(float number) => number.ToString("####");
    }
}