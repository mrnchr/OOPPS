namespace OOPPS.Utilities
{
    public static class CsExtensions
    {
        public static string ToIntegerString(this float obj)
        {
            return obj.ToString("###0");
        }
    }
}