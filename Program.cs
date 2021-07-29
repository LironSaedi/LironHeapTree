using System;
using System.Collections.Generic;

namespace LironHeapTree
{
    class Program
    {
        static void Main(string[] args)
        {
           // int[] array = new int[] { 1, 9, 2, 13, 10, 3 };
            Heap<int> heap = new Heap<int>(10);
            heap.Insert(13);
            heap.Insert(1);
            heap.Insert(9);
            heap.Insert(2);
            heap.Insert(10);
            heap.Insert(3);
            ;
        }
    }
}
