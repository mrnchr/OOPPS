using System;

namespace OOPPS.Core
{
    public interface IInputController<out TData> where TData : IInputData
    {
        public TData Data { get; }
        public event Action<TData> OnInputHandled;
        public void Handle();
        public void Clear();
    }
}