using CustomQueue;
using System.Diagnostics;

namespace Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var microsoftQueue = new Queue<int>();
            var myQueue = new CustomQueue<int>();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for(int i = 0; i < 1000000; i++) {
                myQueue.Enqueue(i);
                myQueue.Contains(i);
                if(i%8 == 0)
                {
                    myQueue.Dequeue();
                }
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);

            stopwatch.Restart();
            for (int i = 0; i < 1000000; i++)
            {
                microsoftQueue.Enqueue(i);
                microsoftQueue.Contains(i);
                if (i % 8 == 0)
                {
                    microsoftQueue.Dequeue();
                }
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }
    }
}