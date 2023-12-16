using System;
using OOPPS.Core;
using OOPPS.Core.Mvc;
using OOPPS.Persistence;
using UnityEngine;

namespace OOPPS.City
{
    public class ResourcesController : IResourcesController, IController, IUpdatable
    {
        private readonly PlayingResources _resources;
        private readonly ResourcesConfig _config;
        private readonly DataPersistenceManager _persistence;

        public ResourcesController(PlayingResources resources,
            ResourcesConfig config,
            DataPersistenceManager persistence)
        {
            _resources = resources;
            _config = config;
            _persistence = persistence;
        }

        public void Add(float value)
        {
            _resources.Energy.Value += value;
            _resources.Energy.Value = Mathf.Clamp(_resources.Energy.Value, 0, _config.MaxEnergy);
        }

        public void OnLoad()
        {
            long delta = (DateTime.Now - _resources.Energy.StartResetTime).Ticks;
            long count = (int)(delta / _config.ResetEnergyTime.Value.Ticks);
            Add(count * _config.ResetEnergyUnit);
            _resources.Energy.StartResetTime = DateTime.Now - new TimeSpan(delta);
        }

        public void Update()
        {
            if (ComeEnergyResetTime() && !IsFull())
            {
                Add(_config.ResetEnergyUnit);
                _resources.Energy.StartResetTime = DateTime.Now;
                _persistence.Save();
            }
        }

        public void Subtract(float value)
        {
            if (value >= 1 && IsFull())
            {
                _resources.Energy.StartResetTime = DateTime.Now;
            }

            Add(-value);
        }

        private bool IsFull() => Mathf.Approximately(_resources.Energy.Value, _config.MaxEnergy);

        private bool ComeEnergyResetTime() => _resources.Energy.StartResetTime.Value + _config.ResetEnergyTime <= DateTime.Now;
    }

    public interface IResourcesController
    {
        public void Add(float value);
        public void OnLoad();
        public void Subtract(float value);
    }
}