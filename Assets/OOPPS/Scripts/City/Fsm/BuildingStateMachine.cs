using System.Collections.Generic;
using OOPPS.City.Building;

namespace OOPPS.City.Fsm
{
    public class BuildingStateMachine : IBuildingStateMachine
    {
        private readonly List<IBuildingState> _states = new List<IBuildingState>();
        private IBuildingState _current;
        
        public BuildingStage Current => _current.Id;
        
        public void AddState(IBuildingState state)
        {
            _states.Add(state);
        }

        public void ChangeState(BuildingStage id)
        {
            ChangeState(_states.Find(x => x.Id == id));
        }

        public void ChangeState(IBuildingState state)
        {
            _current?.Exit();
            _current = state;
            _current.Enter();
        }

        public void Remove(BuildingStage id)
        {
            Remove(_states.Find(x => x.Id == id));
        }

        public void Remove(IBuildingState state)
        {
            _states.Remove(state);
        }
    }
}