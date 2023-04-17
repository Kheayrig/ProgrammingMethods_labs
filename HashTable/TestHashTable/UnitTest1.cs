using HashTableLibrary;

namespace TestHashTable
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class HashTableTests
        {
            private int[] GenerateArrayRandomNumbers(int count)
            {
                var array = new List<int>();
                var rnd = new Random();
                while (array.Count != count)
                {
                    var number = rnd.Next();
                    if (!array.Contains(number))
                        array.Add(number);
                }
                return array.ToArray();
            }

            [TestMethod]
            public void AddItemsTest()
            {
                var hashTable = new HashTable<int, int>();
                var array = GenerateArrayRandomNumbers(20);
                foreach (var item in array)
                {
                    hashTable.Add(item, item);
                }
                Assert.AreEqual(array.Length, hashTable.Count);
                foreach (var item in array)
                {
                    Assert.AreEqual(hashTable[item], item);
                }
            }

            [TestMethod]
            public void RemoveItemsTest()
            {
                var hashTable = new HashTable<int, int>();
                var array = GenerateArrayRandomNumbers(20);
                foreach (var item in array)
                {
                    hashTable.Add(item, item);
                }
                foreach (var item in array)
                {
                    hashTable.Remove(item);
                    Assert.IsFalse(hashTable.ContainsKey(item));
                }
                Assert.AreEqual(0, hashTable.Count);
            }

            [TestMethod]
            public void ContainsItemsTest()
            {
                var hashTable = new HashTable<int, int>();
                var array = GenerateArrayRandomNumbers(20);
                foreach (var item in array)
                {
                    hashTable.Add(item, item);
                }
                foreach (var item in array)
                {
                    Assert.IsTrue(hashTable.ContainsKey(item));
                }
            }

            [TestMethod]
            public void ColliziaTest()
            {
                var hashTable = new HashTable<int, int>();
                var array = new int[5];
                for(int i = 11; i < 60; i+=11)
                {
                    hashTable.Add(i, i);
                }
                hashTable.Remove(11);
                hashTable.Remove(33);
                hashTable.Remove(44);
                Assert.IsTrue(hashTable.ContainsKey(22));
                Assert.IsTrue(hashTable.ContainsKey(55));
                Assert.IsFalse(hashTable.ContainsKey(33));
            }
        }
    }
}