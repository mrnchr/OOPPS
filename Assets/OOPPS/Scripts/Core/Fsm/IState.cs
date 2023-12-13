using System;

namespace OOPPS.Core.Fsm
{
    public interface IState<out TEnum> where TEnum : Enum 
    {
        public TEnum Id { get; }
        
        public void Enter();
        public void Exit();
    }
}