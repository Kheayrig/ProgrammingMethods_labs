using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableLibrary
{
    internal class HashMaker<T>
    {
        public int SimpleNumber { get; set; }

        public HashMaker(int divider = 61)
        {
            SimpleNumber = divider;
        }

        public int ReturnHash(T key)
        {
            return Math.Abs(key.GetHashCode()) % SimpleNumber;
        }
    }
}
