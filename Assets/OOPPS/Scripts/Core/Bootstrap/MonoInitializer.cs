using UnityEngine;

namespace OOPPS.Core
{
    public class MonoInitializer : MonoBehaviour, IInitializer, IHasContainer
    {
        protected IDiContainer _container;

        public virtual void Initialize()
        {
        }

        public void SetContainer(IDiContainer container)
        {
            _container = container;
        }
    }
}