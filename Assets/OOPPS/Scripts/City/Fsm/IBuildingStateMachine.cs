using OOPPS.City.Building;
using OOPPS.Core.Fsm;

namespace OOPPS.City.Fsm
{
    public interface IBuildingStateMachine : IStateMachine<IBuildingState, BuildingStage>
    {
    }
}