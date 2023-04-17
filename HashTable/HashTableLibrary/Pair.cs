using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableLibrary
{
    public class Pair<TKey, TValue> : IEquatable<Pair<TKey, TValue>>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        bool _isDeleted;

        public bool Equals(Pair<TKey, TValue> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqualityComparer<TKey>.Default.Equals(Key, other.Key);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Pair<TKey, TValue>)obj);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<TKey>.Default.GetHashCode(Key);
        }

        public static bool operator ==(Pair<TKey, TValue>? left, Pair<TKey, TValue>? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Pair<TKey, TValue>? left, Pair<TKey, TValue>? right)
        {
            return !Equals(left, right);
        }

        public Pair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
            _isDeleted = false;
        }

        internal bool IsDeleted()
        {
            return _isDeleted;
        }
        internal bool DeletePair()
        {
            if (_isDeleted) return false;
            _isDeleted = true;
            return true;
        }
    }
}
