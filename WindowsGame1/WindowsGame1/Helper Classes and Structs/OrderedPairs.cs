using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;

namespace MarioGame
{
    public class OrderedPairs<TKey, TValue> : HashSet<TKey>
    {
        private List<TKey> KeyList { get; set; } 
        private Dictionary<TKey, TValue> Map { get; set; }

        public OrderedPairs()
        {
            KeyList = new List<TKey>();
            Map = new Dictionary<TKey, TValue>();
        } 

        public void Add(TKey key, TValue value)
        {
            Add(key);
            KeyList.Add(key);
            Map.Add(key, value);
        }

        public TValue this[TKey key] { get { return Map[key]; } }

        public List<TKey> Keys { get { return KeyList; } }

        public List<TValue> Values
        {
            get { return (from key in KeyList select Map[key]).ToList(); }
        }

        public KeyValuePair<TKey, TValue> PairAt(int i)
        {
            return new KeyValuePair<TKey, TValue>(KeyList[i], this[KeyList[i]]);
        }

        public TKey KeyAt(int i)
        {
            return PairAt(i).Key;
        }

        public TValue ValueAt(int i)
        {
            return PairAt(i).Value;
        }
    }
}