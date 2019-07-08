using Slib.Graph;
using Slib.PriorityQueue;
using Slib.Sort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Slib;
using Slib.Design;
using Slib.Stack;
using Slib.Tree;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] ints = new int[] { 0, 1, 2, 3, 4 };
            //int flag = 3;
            //Console.WriteLine(ints[flag++]);
            //Console.WriteLine(ints[flag]);
            //Console.WriteLine("-------------------------------------------");
            //int[] arr = new int[] { 3, 1, 6, 5, 4, 2, 8, 7 };
            //HeapSort<int>.sort(arr);
            //foreach (int n in arr)
            //{
            //    Console.WriteLine(n);
            //}


            //Console.ReadKey();

            //String[] strings = { "it", "was", "the", "best", "of", "times", "it", "was", "the", "worst" };

            //IndexMinPQ<String> pq = new IndexMinPQ<String>(strings.Length);
            //for (int i = 0; i < strings.Length; i++)
            //{
            //    pq.insert(i, strings[i]);
            //}

            //// delete and print each key
            //while (!pq.isEmpty())
            //{
            //    int i = pq.delMin();
            //    Console.WriteLine(i + " " + strings[i]);
            //}
            //Console.WriteLine();

            //// reinsert the same strings
            //for (int i = 0; i < strings.Length; i++)
            //{
            //    pq.insert(i, strings[i]);
            //}

            //// print each key using the iterator
            //foreach (int i in  pq)
            //{
            //    Console.WriteLine(i + " " + strings[i]);
            //}
            //while (!pq.isEmpty())
            //{
            //    pq.delMin();
            //}

            //EdgeWeightedGraph ewg = new EdgeWeightedGraph(6);
            //Edge e1 = new Edge(0, 1, 6);
            //Edge e2 = new Edge(0, 2, 1);
            //Edge e3 = new Edge(0, 3, 5);
            //Edge e4 = new Edge(1, 2, 5);
            //Edge e5 = new Edge(1, 4, 3);
            //Edge e6 = new Edge(2, 3, 5);
            //Edge e7 = new Edge(2, 4, 6);
            //Edge e8 = new Edge(2, 5, 4);
            //Edge e9 = new Edge(3, 5, 2);
            //Edge e10 = new Edge(4, 5, 6);
            //ewg.addEdge(e1);
            //ewg.addEdge(e2);
            //ewg.addEdge(e3);
            //ewg.addEdge(e4);
            //ewg.addEdge(e5);
            //ewg.addEdge(e6);
            //ewg.addEdge(e7);
            //ewg.addEdge(e8);
            //ewg.addEdge(e9);
            //ewg.addEdge(e10);

            //LazyPrimMST lp = new LazyPrimMST(ewg);
            //Queue<Edge> queue = lp.edgs();
            //foreach (Edge e in queue)
            //{
            //    Console.WriteLine(e.weight());
            //}
            Console.WriteLine("111111");
            int[] arr = new int[] { 6, 4, 5, 3, 1, 2 };
            MergeSort<int>.sort(arr);
            Console.WriteLine(arr.Print<int>());


            NullPattern.Invoke();


            MinPQ<int> minPQ = new MinPQ<int>();
            minPQ.insert(1);
            minPQ.insert(2);
            minPQ.insert(4);
            minPQ.insert(3);

            foreach(var item in minPQ)
            {
                Console.WriteLine(item);
            }


            DoubleStack<int> Dstack = new DoubleStack<int>(3);
            Dstack.Push(1,1);
            Dstack.Push(3, 2);
            Dstack.Push(4, 2);
            Dstack.Push(2, 1);

            Console.WriteLine(Dstack.Pop(1));
            Console.WriteLine(Dstack.Pop(2));
            Console.WriteLine(Dstack.Pop(1));


            BiTree<string> g = new BiTree<string>("G");
            BiTree<string> h = new BiTree<string>("H");
            BiTree<string> d = new BiTree<string>("D", g, h);
            BiTree<string> b = new BiTree<string>("B", d, null);
            BiTree<string> i = new BiTree<string>("I");
            BiTree<string> e = new BiTree<string>("E", null, i);
            BiTree<string> f = new BiTree<string>("F");
            BiTree<string> c = new BiTree<string>("C", e, f);
            BiTree<string> root = new BiTree<string>("A", b, c);

            root.PostOrderTraverse(delegate (BiTree<string> tree)
            {
                Console.Write(tree.Data);
            });

         

            Console.ReadKey();
        }
    }
}
