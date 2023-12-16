using OOPPS.Persistence;
using UnityEngine.SceneManagement;

namespace OOPPS.City.Services
{
    public class GameStarter : IGameStarter 
    {
        private readonly CityConfig _config;
        private readonly IResourcesController _resourcesCtrl;
        private readonly ISceneLoader _loader;

        public GameStarter(CityConfig config, IResourcesController resourcesCtrl, ISceneLoader loader)
        {
            _config = config;
            _resourcesCtrl = resourcesCtrl;
            _loader = loader;
        }
        
        public void StartGame()
        {
            if (_resourcesCtrl.Resources.Energy.Value >= _config.EnergyToStart)
            {
                _resourcesCtrl.SubtractEnergy(_config.EnergyToStart);
                _loader.LoadScene("Building");
            }
        }
    }

    public interface IGameStarter
    {
        public void StartGame();
    }
}