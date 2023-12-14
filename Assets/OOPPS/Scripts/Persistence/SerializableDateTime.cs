using System;
using System.Globalization;
using UnityEngine;

namespace OOPPS.Persistence
{
    [Serializable]
    public class SerializableDateTime : ISerializationCallbackReceiver
    {
        public DateTime Value;
        public string SerializableData;
        
        public void OnBeforeSerialize()
        {
            SerializableData = Value.ToUniversalTime().ToString("O", CultureInfo.InvariantCulture);
        }

        public void OnAfterDeserialize()
        {
            Value = DateTime.ParseExact(SerializableData, "O", CultureInfo.InvariantCulture);
        }
    }
}