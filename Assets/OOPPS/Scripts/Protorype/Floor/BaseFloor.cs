using UnityEngine;

namespace OOPPS
{
    public abstract class BaseFloor : MonoBehaviour, IFloor
    {
        [SerializeField] private bool _isHooked;
        [SerializeField] private Hook _hook;
        [SerializeField] private Hook _previousHook;

        public bool IsHooked
        {
            get => _isHooked;
            set => _isHooked = value;
        }

        public Hook Hook
        {
            get => _hook;
            set => _hook = value;
        }

        public Hook PreviousHook
        {
            get => _previousHook;
            set => _previousHook = value;
        }

        public abstract void MakeHook(Hook hook);
        public abstract void Unhook();
    }
}