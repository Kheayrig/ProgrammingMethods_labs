using AVLTree;

namespace TestAVLTree
{
    [TestClass]
    public class UnitTest1
    {
        const int n = 1000000;

        [TestMethod]
        public void TestInsertCountIncrement()
        {
            AVLTree<string, int> tree = new AVLTree<string, int>();
            tree.Insert("abc", 123);
            Assert.AreEqual(1, tree.Count);
        }

        [TestMethod]
        public void TestInsertCountIncrementTwice()
        {
            AVLTree<int, int> tree = new AVLTree<int, int>();
            tree.Insert(1, 123);
            tree.Insert(2, 1234);
            Assert.AreEqual(2, tree.Count);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void TestInsertExceptionIfInsertEqualsKeys()
        {
            AVLTree<string, int> tree = new AVLTree<string, int>();
            tree.Insert("abc", 123);
            tree.Insert("abc", 123);
        }

        [TestMethod]
        public void TestGetGettedValueEqualsInsertedValue()
        {
            AVLTree<string, int> tree = new AVLTree<string, int>();
            tree.Insert("abc", 123);
            Assert.AreEqual(123, tree["abc"]);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void TestGetExceptionIfTryGetNotExistsKey()
        {
            AVLTree<string, int> tree = new AVLTree<string, int>();
            var abc = tree["abc"];
        }

        [TestMethod]
        public void TestRemoveCountEqualZeroAfterInsertAndRemoveOneElement()
        {
            AVLTree<string, int> tree = new AVLTree<string, int>();
            tree.Insert("abc", 123);
            tree.Remove("abc");
            Assert.AreEqual(0, tree.Count);
        }

        [TestMethod]
        public void TestRemoveCountEqualZeroAfterInsertAndRemoveSomeElements()
        {
            AVLTree<string, int> tree = new AVLTree<string, int>();
            for (int i = 0; i < n; i++)
            {
                tree.Insert(i.ToString(), i);
            }
            for (int i = 0; i < n; i++)
            {
                tree.Remove(i.ToString());
            }
            Assert.AreEqual(0, tree.Count);
        }

        [TestMethod]
        public void TestContainsWorkAtSimpleExample()
        {
            AVLTree<string, int> tree = new AVLTree<string, int>();
            tree.Insert("abc", 123);
            Assert.IsTrue(tree.Contains("abc"));
        }

        [TestMethod]
        public void TestContainsWorkAtMediumExample()
        {
            AVLTree<string, int> tree = new AVLTree<string, int>();
            for (int i = 0; i < n; i++)
            {
                tree.Insert(i.ToString(), i);
            }
            Assert.IsTrue(tree.Contains((n / 2).ToString()));
        }

        [TestMethod]
        public void TestContainsWorkAtHardExample()
        {
            AVLTree<string, int> tree = new AVLTree<string, int>();
            int GuessedKeys = 0;
            for (int i = 0; i < n; i++)
            {
                tree.Insert(i.ToString(), i);
            }
            for (int i = 0; i < n; i++)
            {
                if (tree.Contains(i.ToString()))
                    GuessedKeys++;
            }
            Assert.AreEqual(n, GuessedKeys);
        }
    }
}