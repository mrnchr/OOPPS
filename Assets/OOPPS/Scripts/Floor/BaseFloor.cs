using UnityEngine;

namespace OOPPS
{
    public abstract class BaseFloor : MonoBehaviour, IFloor
    {
        [SerializeField] private bool _isHooked;

        public bool IsHooked
        {
            get => _isHooked;
            set => _isHooked = value;
        }

        public abstract void Hook();
        public abstract void Unhook();
    }
}