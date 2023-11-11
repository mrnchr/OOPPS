using System.Collections.Generic;
using UnityEngine;

namespace OOPPS.Core
{
    [DefaultExecutionOrder(-1)]
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private List<MonoInstaller> _installers;
        [SerializeField] private List<MonoInitializer> _initializers;
        
        private IDiContainer _container;

        private void Awake()
        {
            _container = new DiContainer();

            DropContainer(_installers);
            DropContainer(_initializers);
            
            Install();
            Initialize();
        }

        private void Initialize()
        {
            foreach (IInitializer i in _initializers)
                i.Initialize();
        }

        private void Install()
        {
            foreach (IInstaller i in _installers)
                i.InstallBindings();
        }

        private void DropContainer(IEnumerable<IHasContainer> dependees)
        {
            foreach (IHasContainer dependee in dependees)
                dependee.SetContainer(_container);
        }

        private void OnDestroy()
        {
            if (!_container.Has<IDestroyable>())
                return;
            
            foreach (IDestroyable destroyable in _container.ResolveAll<IDestroyable>())
            {
                destroyable.Destroy();
            }
        }
    }
}