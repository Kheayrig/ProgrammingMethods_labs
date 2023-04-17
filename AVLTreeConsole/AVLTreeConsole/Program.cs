using AVLTree;
using System.Diagnostics;

namespace AVLTreeConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new();
            HashSet<int> hashSet = new HashSet<int>();
            while (hashSet.Count < 1000000)
            {
                hashSet.Add(rnd.Next());
            }
            var array = hashSet.ToArray();

            var tree = new AVLTree<int, int>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < array.Length; i++)
            {
                tree.Insert(array[i], array[i]);
            }
            for (int i = 5000; i < 7000; i++)
            {
                tree.Remove(array[i]);
            }
            for (int i = 0; i < array.Length; i++)
            {
                tree.Contains(array[i]);
            }
            stopwatch.Stop();
            Console.WriteLine("AVLTree: " + stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            SortedDictionary<int, int> dictionary = new();
            stopwatch.Start();
            for (int i = 0; i < array.Length; i++)
            {
                dictionary.Add(array[i], array[i]);
            }
            for (int i = 5000; i < 7000; i++)
            {
                dictionary.Remove(array[i]);
            }
            for (int i = 0; i < array.Length; i++)
            {
                dictionary.ContainsKey(array[i]);
            }
            stopwatch.Stop();
            Console.WriteLine("SortedDictionary: " + stopwatch.ElapsedMilliseconds);
        }
    }
}