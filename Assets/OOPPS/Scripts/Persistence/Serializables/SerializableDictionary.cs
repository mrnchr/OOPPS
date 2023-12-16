using System;
using System.Collections.Generic;
using UnityEngine;

namespace OOPPS.Persistence.Serializables
{
    [Serializable]
    public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
    {
        [SerializeField]
        private List<SerializableKeyValuePair<TKey, TValue>> _pairs = new List<SerializableKeyValuePair<TKey, TValue>>();

        public void OnBeforeSerialize()
        {
            _pairs.Clear();
            foreach (var pair in this)
            {
                _pairs.Add(new SerializableKeyValuePair<TKey, TValue>(pair.Key, pair.Value));
            }
        }

        public void OnAfterDeserialize()
        {
            Clear();

            foreach (var pair in _pairs)
            {
                Add(pair.Key, pair.Value);
            }
        }
    }
}