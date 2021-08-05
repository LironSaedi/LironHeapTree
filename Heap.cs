using System;
using System.Collections.Generic;
using System.Text;

namespace LironHeapTree
{
    class Heap<T>
        where T : IComparable<T>
    {
        int Capacity;
        int Count;
        bool greaterOrLess;
        T[] items;
        Comparer<T> comparer;
        public Heap(int capacity, Comparer<T> comparer)
        {
            this.Capacity = capacity;
            this.items = new T[capacity];
            this.comparer = comparer;
        }


        int GetLeft(int index)
        {
            return index * 2 + 1;
        }
        int GetRight(int index)
        {
            return index * 2 + 2;
        }
        int GetParent(int index)
        {
            return (index - 1) / 2;
        }


        public void Insert(T input)
        {
            if (items.Length == Count)
            {
                Resize();
            }

            items[Count] = input;
            Count++;

            HeapifyUp(Count - 1);
           
        }
        
        private void Resize()
        {
            T[] largerArray = new T[items.Length * 2];
            for (int i = 0; i < items.Length; i++)
            {
                largerArray[i] = items[i];
            }
            items = largerArray;

        }

        private void HeapifyUp(int index)
        {
            if (index == 0)
            {
                return;
            }
            int parent = GetParent(index);
           
            if (comparer.Compare(items[index], items[parent]) < 0) //min heap
            {
                T holder = items[index];
                items[index] = items[parent];
                items[parent] = holder;
            }

            HeapifyUp(parent);
            //Get the value at index
            //Get the value at parent
            //Compare them
            //If necessary swap their values
            //Recursively call heapify up on parent
            //your base case is when your index is at the root (0)
        }

        public T Pop()
        {
            T holder = items[0];
            items[0] = items[Count - 1];
            Count--;
            
            HeapifyDown(0);
            return holder;
        }
        private void HeapifyDown(int index)
        {
            //Lirons Notes
            //If now left then there is no right.
            //So we need to check if there is a left if the left is > count
            // next we need to check if there is a right child bc if there is no right child the smalelr one is the left.
            // if they both are there then go with the one that is smaller.
            // and if child is smaller than the item we want swap.

            int indexSwap;
            int leftChild = GetLeft(index);
            int rightChild = GetRight(index);

            if (leftChild >= Count)
            {
                return;
            }

            if (rightChild >= Count)
            {
                indexSwap = leftChild;
            }

            else
            {
                indexSwap = comparer.Compare(items[leftChild], items[rightChild]) > 0 ? rightChild : leftChild;
            }

            if (comparer.Compare(items[indexSwap], items[index]) < 0)
            {
                T holder = items[index];
                items[index] = items[indexSwap];
                items[indexSwap] = holder;
            }

            HeapifyDown(indexSwap);
        }
    }
}
