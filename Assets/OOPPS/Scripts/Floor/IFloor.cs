namespace OOPPS
{
    public interface IFloor
    {
        public bool IsHooked { get; set; }
        public void Hook();
        public void Unhook();
    }
}