using OOPPS.Core;

namespace OOPPS
{
    public class TurtleInitializer : MonoInitializer
    {
        public override void Initialize()
        {
            var updater = _container.Resolve<Updater>();
            foreach (IUpdatable updatable in _container.ResolveAll<IUpdatable>())
            {
                updater.Add(updatable);
            }
        }
    }
}