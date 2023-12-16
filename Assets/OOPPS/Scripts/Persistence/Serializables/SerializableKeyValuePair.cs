using System;

namespace OOPPS.Persistence.Serializables
{
    [Serializable]
    public class SerializableKeyValuePair<TKey, TValue>
    {
        public TKey Key;
        public TValue Value;

        public SerializableKeyValuePair()
        {
            Key = default;
            Value = default;
        }
    
        public SerializableKeyValuePair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        public override string ToString() => $"{Key}: {Value}";
    }
}