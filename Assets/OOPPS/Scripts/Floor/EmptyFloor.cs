using System;

namespace OOPPS
{
    public class EmptyFloor : BaseFloor
    {
        private void Awake()
        {
            IsHooked = true;
        }

        public override void MakeHook(Hook hook)
        {
        }

        public override void Unhook()
        {
        }
    }
}