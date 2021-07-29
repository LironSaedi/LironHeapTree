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

        T[] items;
        public Heap(int capacity)
        {
            this.Capacity = capacity;
            this.items = new T[capacity];
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
            if(index == 0)
            {
                return;
            }
            int parent = GetParent(index);
            if (items[index].CompareTo(items[parent]) < 0) //min heap
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
    }
}
