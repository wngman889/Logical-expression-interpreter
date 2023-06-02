using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Kursowa_rabota_SAA
{
    public class MyDictionary<K,V>: IEnumerable<KeyValuePair<K,V>>
    {
        private const int INITIAL_SIZE = 16;
        MyLinkedList<KeyValuePair<K, V>>[] values;
        public int Count { get; private set; }
        public int Capacity//the array
        {
            get
            {
                return this.values.Length;
            }  
        }
        public MyDictionary()
        {
            this.values = new MyLinkedList<KeyValuePair<K, V>>[INITIAL_SIZE];
        }
        public void Add(K key, V value)
        {
            var hash = this.HashKey(key);

            if (values[hash] == null)
                values[hash] = new MyLinkedList<KeyValuePair<K, V>>();//check if there is values

            if (!ContainsKey(key))//check if there is value with the same key
                throw new InvalidOperationException("There is value with the same key!");

            var pair = new KeyValuePair<K, V>(key, value);
            values[hash].AddLast(pair);
            Count++;

            if (Count >= Capacity)
                Resize();
        }
        public bool ContainsKey(K key)
        {
            var hash = HashKey(key);

            if (values[hash] == null)
                return false;

            var collection = values[hash];
            return true;
        }
        private int HashKey(K key)
        {
            var hash = Math.Abs(key.GetHashCode()) % this.Capacity;//hashing only positive
            return hash;
        }
        private void Resize()
        {
            //Add values
            //store the values
            var cachedValues = values;
            //resize
            values = new MyLinkedList<KeyValuePair<K, V>>[2 * Capacity];
            this.Count = 0;
            foreach (var collection in cachedValues)
            {
                if (collection != null)
                {
                    foreach (var value in collection)
                        Add(value.Key, value.Value);
                }
            }
        }
        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            foreach (var collection in this.values)
            {
                if (collection != null)
                {
                    foreach (var value in collection)
                    {
                        yield return value;//not quitting the loop
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
