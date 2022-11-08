using System.Collections.Generic;
using UnityEngine;

namespace Lesson_6.Task_1
{
    public sealed class Lesson_6_Task_1 : MonoBehaviour
    {
        public SerializableDictionary<int, int> myDictionary = new SerializableDictionary<int, int>();
        private void Start()
        {
            myDictionary.Add(10, 9999);
            myDictionary.Add(20, 999);
        }
    }

    [System.Serializable]
    public class SerializableDictionary<Key, Value> : ISerializationCallbackReceiver
    {
        private Dictionary<Key, Value> _dictionary = new Dictionary<Key, Value>();
        [SerializeField] List<Key> _keys = new List<Key>();
        [SerializeField] List<Value> _values = new List<Value>();

        public void Add(Key key, Value value)
        {
            _dictionary.Add(key, value);
        }

        public void OnAfterDeserialize()
        {
            _dictionary.Clear();
            if (_keys.Count != _values.Count)
            {
                throw new System.Exception(
                    string.Format("there are {0} keys and {1} values after deserialization. Lengths do not match.")
                    );
            }
            for (int i = 0; i < _keys.Count; i++)
            {
                _dictionary.Add(_keys[i], _values[i]);
            }
        }

        public void OnBeforeSerialize()
        {
            _keys.Clear();
            _values.Clear();

            Dictionary<Key, Value>.KeyCollection temporaryKeys = _dictionary.Keys;
            foreach (Key currentKey in temporaryKeys)
            {
                _keys.Add(currentKey);
                _values.Add(_dictionary[currentKey]);
            }
        }
    }
}