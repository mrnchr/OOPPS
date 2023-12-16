using System;
using OOPPS.Persistence;

namespace OOPPS.City
{
    [Serializable]
    public class Energy
    {
        public float Value;
        public SerializableDateTime StartResetTime;

        public void Copy(Energy from)
        {
            Value = from.Value;
            StartResetTime = from.StartResetTime;
        }
    }
}