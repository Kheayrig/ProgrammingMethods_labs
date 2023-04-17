using HashTableLibrary;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace HashTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] text;
            var dict = new Dictionary<string, int>();
            var hashTable = new HashTable<string, int>();

            using(var sr = new StreamReader("WarAndWorld.txt"))
            {
                text = sr.ReadToEnd().Split(new char[] {' ', '\n', '\t', '\r'}, StringSplitOptions.RemoveEmptyEntries);
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            CheckTable(text, hashTable);
            stopwatch.Stop();

            Console.WriteLine($"Time: {stopwatch.ElapsedMilliseconds}") ;

            stopwatch.Restart();
            CheckDict(text, dict);
            stopwatch.Stop();

            Console.WriteLine($"Time: {stopwatch.ElapsedMilliseconds}");

        }
        static void CheckTable(string[] text, HashTable<string, int> hashTable)
        {
            foreach(var item in text)
            {
                if(hashTable.ContainsKey(item)) hashTable[item]++;
                else hashTable.Add(item, 1);
            }
            Console.WriteLine(hashTable.Count);
            foreach (var item in hashTable)
            {
                if (item.Value > 27) hashTable.Remove(item.Key);
            }
            Console.WriteLine(hashTable.Count);
        }
        static void CheckDict(string[] text, Dictionary<string, int> dict)
        {
            foreach (var item in text)
            {
                if (dict.ContainsKey(item)) dict[item]++;
                else dict.Add(item, 1);
            }
            Console.WriteLine(dict.Count);
            foreach (var item in dict)
            {
                if (item.Value > 27) dict.Remove(item.Key);
            }
            Console.WriteLine(dict.Count);
        }
    }
}