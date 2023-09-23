using System;

namespace OOPPS
{
    public class EmptyFloor : BaseFloor
    {
        private void Awake()
        {
            IsHooked = true;
        }

        public override void Hook()
        {
        }

        public override void Unhook()
        {
        }
    }
}