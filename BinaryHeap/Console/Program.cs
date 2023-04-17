using BinaryHeap;

namespace ConsoleTask
{
    internal class Program
    {
        // Дан список из n элементов.
        // Надо найти третий по величине элемент за наименьшее число сравнений.
        
        static void Main(string[] args)
        {
            var list = Enumerable.Range(1, 100).ToList();
            var heap = new MaxThirdElement<int>(new MaxComparer<int>());
            foreach (var element in list)
            {
                heap.Insert(element);
            }
            var item = heap.GetThirdFaster();
            Console.WriteLine($"item = {item}, O(n*log(n) + 3 сравнения)");
            item = heap.GetThirdHeadOn();
            Console.WriteLine($"item = {item}, O(n*log(n) + 2*log(n))");
        }
    }
}