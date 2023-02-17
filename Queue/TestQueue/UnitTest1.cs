using CustomQueue;

namespace TestQueue
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCount()
        {
            var q = new CustomQueue<int>(); 
            for(int i = 0; i < 10; i++)
            {
                q.Enqueue(i);
            }
            Assert.AreEqual(10, q.Count);
        }
        [TestMethod]
        public void TestCountAfterDequeue()
        {
            var q = new CustomQueue<int>(); 
            for(int i = 0; i < 10; i++)
            {
                q.Enqueue(i);
            }
            q.Dequeue();
            q.Dequeue();
            Assert.AreEqual(8, q.Count);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestCountAfterDequeueEmptyQueue()
        {
            var q = new CustomQueue<int>();
            q.Enqueue(1);
            q.Dequeue();
            q.Dequeue();
        }
        [TestMethod]
        public void TestDequeue()
        {
            var q = new CustomQueue<int>();
            for (int i = 0; i < 10; i++)
            {
                q.Enqueue(i);
            }
            for (int i = 0; i < 10; i++)
            {
                var item = q.Dequeue();
                Assert.AreEqual(i, item);
            }
            
        }
        [TestMethod]
        public void TestPeek()
        {
            var q = new CustomQueue<int>();
            for (int i = 0; i < 10; i++)
            {
                q.Enqueue(i);
            }
            for (int i = 0; i < 10; i++)
            {
                var item = q.Peek();
                var item2 = q.Dequeue();
                Assert.AreEqual(item2, item);
            }
            
        }
        [TestMethod]
        public void TestContainsTrue()
        {
            var q = new CustomQueue<int>();
            for (int i = 1; i < 10; i++)
            {
                q.Enqueue(i);
            }
            Assert.IsTrue(q.Contains(5));
            
        }
        [TestMethod]
        public void TestContainsAfterDequeueTrue()
        {
            var q = new CustomQueue<int>();
            for (int i = 1; i < 10; i++) //1 2 3 4 5 6 7 8 9 x x x x x x x
            {
                q.Enqueue(i);
            }
            for (int i = 1; i < 7; i++) //x x x x x x 7 8 9 x x x x x x x
            {
                q.Dequeue();
            }
            for (int i = 1; i < 5; i++) //x x x x x x 7 8 9 11 12 13 14 x x x
            {
                q.Enqueue(i+10);
            }
            Assert.IsTrue(q.Contains(14));
            Assert.IsTrue(q.Contains(7));
            
        }
        [TestMethod]
        public void TestContainsFalse()
        {
            var q = new CustomQueue<int>();
            for (int i = 1; i < 10; i++)
            {
                q.Enqueue(i);
            }
            Assert.IsFalse(q.Contains(0));
            Assert.IsFalse(q.Contains(10));
            

        }
        [TestMethod]
        public void TestContainsAfterDequeueFalse()
        {
            var q = new CustomQueue<int>();
            for (int i = 1; i < 10; i++) //1 2 3 4 5 6 7 8 9 x x x x x x x
            {
                q.Enqueue(i);
            }
            for (int i = 1; i < 7; i++) //x x x x x x 7 8 9 x x x x x x x
            {
                q.Dequeue();
            }
            for (int i = 1; i < 5; i++) //x x x x x x 7 8 9 11 12 13 14 x x x
            {
                q.Enqueue(i + 10);
            }
            Assert.IsFalse(q.Contains(15));
            Assert.IsFalse(q.Contains(0));

        }
        [TestMethod]
        public void TestSetZeroCapacityAndGrowQueue()
        {
            var q = new CustomQueue<int>(0);
            for (int i = 1; i < 10; i++) //1 2 3 4 5 6 7 8 9 x x x x x x x
            {
                q.Enqueue(i);
            }
            for (int i = 1; i < 7; i++) //x x x x x x 7 8 9 x x x x x x x
            {
                q.Dequeue();
            }
            for (int i = 1; i < 5; i++) //x x x x x x 7 8 9 11 12 13 14 x x x
            {
                q.Enqueue(i + 10);
            }
            Assert.IsFalse(q.Contains(15));
            Assert.IsFalse(q.Contains(0));

        }

    }
}