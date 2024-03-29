﻿using System.Collections;
using System.Drawing;

namespace HashTableLibrary
{
    public class HashTable<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>, IHashTable<TKey, TValue> where TKey : IEquatable<TKey>
    {
        const int c1 = 1;
        const int c2 = 1;
        Pair<TKey, TValue>[] _table;
        private int _capacity;
        HashMaker<TKey> _hashMaker1;
        public int Count { get; private set; }
        private const double FillFactor = 0.5; 
        private readonly GetPrimeNumber _primeNumber = new GetPrimeNumber();

        public HashTable(int m = 11)
        {
            _capacity = _primeNumber.GetMin();
            while (_capacity < m) _primeNumber.Next();
            _table = new Pair<TKey, TValue>[_capacity];
            _hashMaker1 = new HashMaker<TKey>(_capacity);
            Count = 0;
        }

        public TValue this[TKey key]
        {
            get
            {
                var pair = Find(key);
                if (pair == null)
                    throw new KeyNotFoundException();
                return pair.Value;
            }

            set
            {
                var pair = Find(key);
                if (pair == null)
                    throw new KeyNotFoundException();
                pair.Value = value;
            }
        }

        public void Add(TKey key, TValue value)
        {
            var hash = _hashMaker1.ReturnHash(key);

            if (!TryToPut(hash, key, value)) // ячейка занята
            {
                int iterationNumber = 1;
                while (true)
                {
                    var place = (hash + c1 * iterationNumber + c2 * iterationNumber * iterationNumber) % _capacity;
                    if (TryToPut(place, key, value)) break;
                    iterationNumber++;
                    if (iterationNumber >= _capacity)
                        throw new ApplicationException("HashTable full!!!");
                }
            }
            if ((double)Count / _capacity >= FillFactor)
            {
                IncreaseTable();
            }
        }

        private bool TryToPut(int place, TKey key, TValue value)
        {
            if (_table[place] == null || _table[place].IsDeleted())
            {
                _table[place] = new Pair<TKey, TValue>(key, value);
                Count++;
                return true;
            }
            if (_table[place].Key.Equals(key))
            {
                throw new ArgumentException("Key has already exists");
            }
            return false;
        }

        private Pair<TKey, TValue>? Find(TKey x)
        {
            var hash = _hashMaker1.ReturnHash(x);
            if (_table[hash] == null)
                return null;
            if (!_table[hash].IsDeleted() && _table[hash].Key.Equals(x))
            {
                return _table[hash];
            }
            int iterationNumber = 1;
            while (true)
            {
                var place = (hash + c1 * iterationNumber + c2 * iterationNumber * iterationNumber) % _capacity;
                if (_table[place] == null)
                    return null;
                if (!_table[place].IsDeleted() && _table[place].Key.Equals(x))
                {
                    return _table[place];
                }
                iterationNumber++;
                if (iterationNumber >= _capacity)
                    return null;
            }
        }

        private void IncreaseTable()
        {
            // получить число и увеличить таблицу
            var oldTable = _table;
            _capacity = _primeNumber.Next();
            _table = new Pair<TKey, TValue>[_capacity];
            Count = 0;
            _hashMaker1 = new HashMaker<TKey>(_capacity);
            foreach (var item in oldTable)
            {
                if(item != null && !item.IsDeleted()) Add(item.Key, item.Value);
            }
        }

        public bool Remove(TKey x)
        {
            var item = Find(x);
            if(item == null) return false;
            item.DeletePair();
            Count--;
            return true;
        }

        public bool ContainsKey(TKey key)
        {
            return Find(key) != null;
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return (from pair in _table where pair != null && !pair.IsDeleted() select new KeyValuePair<TKey, TValue>(pair.Key, pair.Value)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}