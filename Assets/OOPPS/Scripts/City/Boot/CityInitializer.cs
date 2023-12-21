using System.Collections.Generic;
using OOPPS.City.Building;
using OOPPS.City.Fsm;
using OOPPS.City.Services;
using OOPPS.Core;
using OOPPS.Persistence;
using UnityEngine;

namespace OOPPS.City.Boot
{
    public class CityInitializer : MonoInitializer
    {
        [SerializeField] private List<BuildingView> _buildings;

        public override void Initialize()
        {
            CreateBuildingControllers();
            InitializeUpdater();
        }

        private void InitializeUpdater()
        {
            var list = _container.Resolve<List<BuildingController>>();
            _container.Resolve<Updater>()
                .Add(_container.ResolveAll<IUpdatable>())
                .Add(list);
        }

        private void CreateBuildingControllers()
        {
            var list = _container.Resolve<List<BuildingController>>();
            var city = _container.Resolve<ICityService>();
            var persistence = _container.Resolve<DataPersistenceManager>();

            foreach (BuildingView view in _buildings)
            {
                var machine = new BuildingStateMachine();
                var instance = new BuildingController(view, machine, city, persistence);
                machine.AddState(new EmptyBuildingState(BuildingStage.Empty, instance));
                machine.AddState(new PlaceBuildingState(BuildingStage.Place, instance));
                machine.AddState(new BuildBuildingState(BuildingStage.Build, instance));
                machine.AddState(new EarnBuildingState(BuildingStage.Earn, instance));
                list.Add(instance);
                
                instance.Initialize();
            }
        }
    }
}