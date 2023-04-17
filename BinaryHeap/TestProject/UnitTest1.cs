using BinaryHeap;
using ConsoleTask;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        private List<int> GetRandomArray(int size)
        {
            var rnd = new Random();
            var list = new List<int>();
            while (list.Count != size)
            {
                var value = rnd.Next();
                if (!list.Contains(value))
                    list.Add(value);
            }
            return list;
        }

        [TestMethod]
        public void SingleElement()
        {
            var heap = new BinaryHeap<int>(new MinComparer<int>());
            int expected = 10;
            heap.Insert(expected);
            int actual = heap.Peek();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HeapifyDownTest()
        {
            var array = GetRandomArray(100);
            var heap = new BinaryHeap<int>(new MinComparer<int>());
            foreach (var item in array)
            {
                heap.Insert(item);
            }
            array.Sort();
            foreach (var item in array)
            {
                Assert.AreEqual(item, heap.Pop());
            }
            Assert.AreEqual(0, heap.Count);
        }

        [TestMethod]
        public void HeapifyUpTest()
        {
            var heap = new BinaryHeap<int>(new MaxComparer<int>());
            for (int i = 0; i < 100; i++)
            {
                heap.Insert(i);
                Assert.AreEqual(i, heap.Peek());
            }
        }

        [TestMethod]
        public void ThirdMaxFasterTest()
        {
            var array = GetRandomArray(100);
            var heap = new MaxThirdElement<int>(new MaxComparer<int>());
            foreach (var item in array)
            {
                heap.Insert(item);
            }
            array.Sort();
            Assert.AreEqual(array[array.Count - 3], heap.GetThirdFaster());
        }

        [TestMethod]
        public void ThirdMaxHeadOnTest()
        {
            var array = GetRandomArray(100);
            var heap = new MaxThirdElement<int>(new MaxComparer<int>());
            foreach (var item in array)
            {
                heap.Insert(item);
            }
            array.Sort();
            Assert.AreEqual(array[array.Count - 3], heap.GetThirdHeadOn());
        }
    }
}