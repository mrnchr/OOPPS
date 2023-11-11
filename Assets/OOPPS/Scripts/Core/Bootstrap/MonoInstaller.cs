using UnityEngine;

namespace OOPPS.Core
{
    public class MonoInstaller : MonoBehaviour, IInstaller, IHasContainer
    {
        protected IDiContainer _container;

        public virtual void InstallBindings()
        {
        }
        
        public void SetContainer(IDiContainer container)
        {
            _container = container;
        }
    }
}
