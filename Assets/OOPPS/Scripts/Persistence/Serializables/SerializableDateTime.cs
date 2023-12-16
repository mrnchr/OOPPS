using System;
using System.Globalization;
using UnityEngine;

namespace OOPPS.Persistence.Serializables
{
    [Serializable]
    public struct SerializableDateTime : ISerializationCallbackReceiver
    {
        public DateTime Value;
        public string SerializableValue;

        public static implicit operator DateTime(SerializableDateTime obj) => obj.Value;
        public static implicit operator SerializableDateTime(DateTime obj) => new SerializableDateTime { Value = obj };

        public void OnBeforeSerialize()
        {
            SerializableValue = Value.ToUniversalTime().ToString("O", CultureInfo.InvariantCulture);
        }

        public void OnAfterDeserialize()
        {
            try
            {
                Value = DateTime.ParseExact(SerializableValue, "O", CultureInfo.InvariantCulture);
            }
            catch
            {
                Value = default;
            }
        }

        public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);
    }
}