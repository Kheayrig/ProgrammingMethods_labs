using AVLTree;
namespace AVLTreeConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 1000;
            AVLTree<string, int> tree = new AVLTree<string, int>();
            for (int i = 0; i < n; i++)
            {
                tree.Insert(i.ToString(), i);
            }
            tree.ConsolePrint();
            for (int i = 0; i < n; i++)
            {
                tree.Remove(i.ToString());
            }
            //var tree = new AVLTree<int,int>();
            //tree.Insert(7, 7);
            //Console.WriteLine("--------{0}", tree.Count);
            //tree.Insert(1, 1);
            //tree.ConsolePrint();
            //Console.WriteLine("--------{0}",tree.Count);
            //tree.Insert(3, 3);
            //tree.ConsolePrint();
            //Console.WriteLine("--------{0}", tree.Count);
            //tree.Insert(14, 14);
            //tree.ConsolePrint();
            //Console.WriteLine("--------{0}", tree.Count);
            //tree.Insert(0, 0);
            //tree.ConsolePrint();
            //Console.WriteLine("--------{0}", tree.Count);
            //tree.Insert(2, 2);
            //tree.ConsolePrint();
            //Console.WriteLine("--------{0}", tree.Count);
            //tree.Insert(6, 6);
            //tree.ConsolePrint();
            //Console.WriteLine("--------{0}", tree.Count);
            //tree.ConsolePrint();
            //tree.Remove(new Node<int, int>(1, 1));
            //tree.ConsolePrint();
            //Console.WriteLine("--------{0}", tree.Count);
            //tree.Remove(new Node<int, int>(2, 2));
            //tree.ConsolePrint();
            //Console.WriteLine("--------{0}", tree.Count);
            //tree.Remove(new Node<int, int>(0, 0));
            //tree.ConsolePrint();
            //Console.WriteLine("--------{0}", tree.Count);
        }
    }
}