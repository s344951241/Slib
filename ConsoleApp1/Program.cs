using Slib.PriorityQueue;
using Slib.Sort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ints = new int[] { 0, 1, 2, 3, 4 };
            int flag = 3;
            Console.WriteLine(ints[flag++]);
            Console.WriteLine(ints[flag]);
            Console.WriteLine("-------------------------------------------");
            int[] arr = new int[] { 3, 1, 6, 5, 4, 2, 8, 7 };
            HeapSort<int>.sort(arr);
            foreach (int n in arr)
            {
                Console.WriteLine(n);
            }


            Console.ReadKey();

            String[] strings = { "it", "was", "the", "best", "of", "times", "it", "was", "the", "worst" };

            IndexMinPQ<String> pq = new IndexMinPQ<String>(strings.Length);
            for (int i = 0; i < strings.Length; i++)
            {
                pq.insert(i, strings[i]);
            }

            // delete and print each key
            while (!pq.isEmpty())
            {
                int i = pq.delMin();
                Console.WriteLine(i + " " + strings[i]);
            }
            Console.WriteLine();

            // reinsert the same strings
            for (int i = 0; i < strings.Length; i++)
            {
                pq.insert(i, strings[i]);
            }

            // print each key using the iterator
            foreach (int i in  pq)
            {
                Console.WriteLine(i + " " + strings[i]);
            }
            while (!pq.isEmpty())
            {
                pq.delMin();
            }
            Console.ReadKey();



        }
    }
}
