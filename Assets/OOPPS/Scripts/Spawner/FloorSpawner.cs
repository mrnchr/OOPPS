using OOPPS.Core;

namespace OOPPS.Spawner
{
    public class FloorSpawner
    {
        private readonly SpawnConfig _config;
        private readonly ICoroutineRunner _runner;

        public FloorSpawner(SpawnConfig config, ICoroutineRunner runner)
        {
            _config = config;
            _runner = runner;
        }
    }
}