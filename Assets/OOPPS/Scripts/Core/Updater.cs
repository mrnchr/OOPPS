using System.Collections.Generic;
using UnityEngine;

namespace OOPPS.Core
{
    public class Updater : MonoBehaviour
    {
        private readonly List<IUpdatable> _updatables = new List<IUpdatable>();
        
        public Updater Add(IUpdatable updatable)
        {
            _updatables.Add(updatable);
            return this;
        }

        public Updater Add(List<IUpdatable> updatables)
        {
            _updatables.AddRange(updatables);
            return this;
        }

        public Updater Remove(IUpdatable updatable)
        {
            _updatables.Remove(updatable);
            return this;
        }

        private void Update()
        {
            foreach (IUpdatable updatable in _updatables)
                updatable.Update();
        }
      
    }
}