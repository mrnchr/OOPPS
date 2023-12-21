using System.Collections.Generic;
using OOPPS.City.Building;
using OOPPS.Core.Mvc;

namespace OOPPS.City.UI.BuildButton
{
    public class BuildButtonController : IController
    {
        private readonly BuildButtonView _view;
        private readonly List<BuildingController> _buildings;
        private readonly BuildButtonModel _model;

        public BuildButtonController(BuildButtonView view, List<BuildingController> buildings)
        {
            _view = view;
            _buildings = buildings;
            _model = new BuildButtonModel();

            _view.SetController(this);
        }

        public void SwitchBuildMode()
        {
            SetBuildMode(!_model.ActiveBuildMode);
        }

        public void SetBuildMode(bool active)
        {
            _model.ActiveBuildMode = active;
            foreach (BuildingController building in _buildings)
            {
                building.SetBuildMode(active);
            }
        }
    }
}