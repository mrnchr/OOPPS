using System;

namespace OOPPS.Utilities
{
    public static class CsExtensions
    {
        public static string ToIntegerString(this float obj)
        {
            return obj.ToString("###0");
        }

        public static string ToTimeString(this TimeSpan obj)
        {
            var output = "";
            AddMeasure(obj.Days, "d");
            AddMeasure(obj.Hours, "h");
            AddMeasure(obj.Minutes, "m");
            output += obj.Seconds + "s";

            return output;
            
            void AddMeasure(int value, string unit)
            {
                output += value > 0 ? value + unit : "";
            }
        }
    }
}