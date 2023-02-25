using AVLTree;
namespace AVLTreeConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree<int,int>();
            tree.Insert(7, 7);
            Console.WriteLine("--------{0}", tree.Count);
            tree.Insert(1, 1);
            Console.WriteLine("--------{0}",tree.Count);
            tree.Insert(3, 3);
            Console.WriteLine("--------{0}", tree.Count);
            tree.Insert(14, 14);
            Console.WriteLine("--------{0}", tree.Count);
            tree.Insert(0, 0);
            Console.WriteLine("--------{0}", tree.Count);
            tree.Insert(2, 2);
            Console.WriteLine("--------{0}", tree.Count);
            tree.Insert(6, 6);
            Console.WriteLine("--------{0}", tree.Count);
            tree.Remove(new Node<int, int>(1, 1));
            Console.WriteLine("--------{0}", tree.Count);
            tree.Remove(new Node<int, int>(2, 2));
            Console.WriteLine("--------{0}", tree.Count);
            tree.ConsolePrint();
        }
    }
}