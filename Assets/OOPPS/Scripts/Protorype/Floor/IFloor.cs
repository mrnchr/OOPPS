namespace OOPPS
{
    public interface IFloor
    {
        public Hook Hook { get; set; }
        public bool IsHooked { get; set; }
        public void MakeHook(Hook hook);
        public void Unhook();
    }
}