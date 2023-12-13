using System;

namespace OOPPS.Core.Fsm
{
    public interface IStateMachine<in TState, TEnum> where TState : IState<TEnum> where TEnum : Enum 
    {
        public TEnum Current { get; }
        
        public void AddState(TState state);
        public void ChangeState(TEnum id);
        public void ChangeState(TState state);
        public void Remove(TEnum id);
        public void Remove(TState state);
    }
}