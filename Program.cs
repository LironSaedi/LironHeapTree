using System;
using System.Collections.Generic;

namespace LironHeapTree
{
    class Program
    {
        static void Main(string[] args)
        {
            // int[] array = new int[] { 1, 9, 2, 13, 10, 3 };
            
            int items = 20;
            Heap<int> heap = new Heap<int>(items, Comparer<int>.Create((x, y) => y.CompareTo(x))); // min heap to make it max heap just switch  x.CompareTo(y)) to  y.CompareTo(x))
            int randNum;
            Random gen = new Random();
            for (int i = 0; i < items; i++)
            {
                randNum = gen.Next(1, 100000);
                heap.Insert(randNum);
            }

            for (int i = 0; i < items; i++)
            {
                Console.WriteLine(heap.Pop());
            }

            //Comparer<int> a =Comparer<int>.Create((x, y) => y.CompareTo(x)) ;
            //Console.WriteLine(a.Compare(10, 11));
            //heap.Insert(13);
            //heap.Insert(1);
            //heap.Insert(9);
            //heap.Insert(2);
            //heap.Insert(10);
            //heap.Insert(3); 
            ;
        }
    }
}
