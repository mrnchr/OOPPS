using System;
using System.Globalization;
using UnityEngine;

namespace OOPPS.Persistence
{
    [Serializable]
    public struct SerializableTimeSpan : ISerializationCallbackReceiver
    {
        public TimeSpan Value;
        public string SerializableValue;

        public static implicit operator TimeSpan(SerializableTimeSpan obj) => obj.Value;
        public static implicit operator SerializableTimeSpan(TimeSpan obj) => new SerializableTimeSpan { Value = obj };

        public void OnBeforeSerialize()
        {
            SerializableValue = Value.ToString("c", CultureInfo.InvariantCulture);
        }

        public void OnAfterDeserialize()
        {
            try
            {
                Value = TimeSpan.ParseExact(SerializableValue, "c", CultureInfo.InvariantCulture);
            }
            catch
            {
                Value = default;
            }
        }

        public override string ToString() => Value.ToString();
    }
}