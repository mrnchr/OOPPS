using OOPPS.Core;
using OOPPS.Persistence;

namespace OOPPS.City.Services
{
    public class GameStarter : IGameStarter, IDestroyable
    {
        private readonly CityConfig _config;
        private readonly IResourcesController _resourcesCtrl;
        private readonly ISceneLoader _loader;
        private readonly CloudTransitionsController _cloud;

        public GameStarter(CityConfig config,
            IResourcesController resourcesCtrl,
            ISceneLoader loader,
            CloudTransitionsController cloud)
        {
            _config = config;
            _resourcesCtrl = resourcesCtrl;
            _loader = loader;
            _cloud = cloud;

            _cloud.OnCloudShowEnded += LoadGameScene;
        }

        public void StartGame()
        {
            if (_resourcesCtrl.Resources.Energy.Value >= _config.EnergyToStart)
            {
                _resourcesCtrl.SubtractEnergy(_config.EnergyToStart);
                _cloud.ShowClouds();
            }
        }

        private void LoadGameScene()
        {
            _loader.LoadScene("Building");
        }

        public void Destroy()
        {
            _cloud.OnCloudShowEnded -= LoadGameScene;
        }
    }

    public interface IGameStarter
    {
        public void StartGame();
    }
}