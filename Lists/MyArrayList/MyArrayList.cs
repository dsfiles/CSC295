﻿/*
 * 1) Not all the methods are implemented
 * 2) Generic programming feature is not available
 */

using System;

namespace MyArrayList
{
    internal class MyArrayListTest
    {
        static void Main(string[] args)
        {
            // create an instance
            MyArrayList list = new MyArrayList();
            // check count and capacity
            Console.WriteLine("An empty list is crated, list count: " + list.Count);
            //add to this list
            list.Add(3);
            Console.WriteLine($"After appending 3, Count: {list.Count}, Capacity: {list.Capacity}");
            list.Add(1);
            Console.WriteLine($"After appending 1, Count: {list.Count}, Capacity: {list.Capacity}");
            list.Add(2);
            Console.WriteLine($"After appending 2, Count: {list.Count}, Capacity: {list.Capacity}");
            list.Add(5);
            Console.WriteLine($"After appending 5, Count: {list.Count}, Capacity: {list.Capacity}");
            list.Add(0);
            Console.WriteLine($"After appending 0, Count: {list.Count}, Capacity: {list.Capacity}");
            Console.WriteLine("Now the list is: ");
            list.DisplayList();
            list.Sort();
            Console.WriteLine("After sorting:");
            list.DisplayList();
            Console.WriteLine("Element at index 1: " + list[1]);
            list.Clear();
            Console.WriteLine($"After invoking Clear(), Count: {list.Count}, Capacity: {list.Capacity}");
        }
    }

    class MyArrayList
    {
        int[] values; // ArrayList data are stored in an array called values
        public int Count { get; private set; }
        public int Capacity
        {
            get { return values.Length; }
        }

        public MyArrayList(int Capacity = 4) //constructor
        {
            values = new int[Capacity]; // allocate the array
            Count = 0; // initially, count is set to 0;
        }

        public void Add(int newValue)
        {
            // check if array is full
            if (Count == Capacity)
            {
                Resize();
            }
            // put newValue into the array at position count
            values[Count] = newValue;
            Count++;
        }

        public void Resize()
        {
            // create a new array of double capacity
            int[] tmp = new int[2 * Capacity];
            // copy over the old values
            for (int pos = 0; pos < Capacity; pos++)
            {
                tmp[pos] = values[pos];
            }
            // reference values array to the new tmp array
            values = tmp;
        }

        public void AddLast(int newValue)
        {
            Add(newValue); // Add method adds a new value to the end
            // insert(newValue, Count)
        }

        public void AddFirst(int newValue)
        {
            Insert(newValue, 0);
        }

        public void Insert(int newValue, int index)
        {
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException($"index should be between {0} and {Count}");
            // check if the array is full, double its capacity if needed
            if (Count == Capacity)
                Resize();
            // shift everything from position i to Count-1, right by one position
            for (int i = Count; i > index; i--)
            {
                values[i] = values[i - 1];
            }
            //insert the new value
            values[index] = newValue;
            Count++;
        }

        public void DeleteLast()
        {
            if (Count == 0) //you CAN't delete last from an empty list
                throw new IndexOutOfRangeException("You CAN't delete last from an empty list");
            Count--; // just decrement the Count without removing
        }

        public void DeleteFirst()
        {
            Delete(0);
        }

        public void Delete(int index)
        {
            // validate index
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException($"index should be between {0} and {Count - 1}");
            // shift everything (that is past index i) to the left one position
            for (int i = index; i < Count - 1; i++)
                values[i] = values[i + 1];
            Count--;

        }
        public void Clear()
        {
            Count = 0; // too simple?
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        // shift everything from position i to Count-1, right by one position
        public void DisplayList()
        {
            if (IsEmpty())
                Console.WriteLine("Empty list!");
            else
            {
                for (int i = 0; i < Count; i++)
                {
                    Console.Write((values[i]) + " ");
                }
                Console.WriteLine();
            }
        }

        public void Reverse()
        {
            throw new NotImplementedException();
        }

        public int this[int i] // indexer
        {
            get { return values[i]; }
            set { values[i] = value; }
        }

        public void Sort()
        {
            QuickSortHelper(values, 0, Count - 1);
        }

        public static void QuickSortHelper(int[] arr, int startIdx, int endIdx)
        {
            if (startIdx < endIdx) //if we have at least 2 elements in the "slice"
            {
                int q = Partition(arr, startIdx, endIdx); //partition the array
                QuickSortHelper(arr, startIdx, q - 1); //sort the first "half"
                QuickSortHelper(arr, q + 1, endIdx); //sort the first "half"
            }
        }

        public static int Partition(int[] arr, int startIdx, int endIdx)
        {
            int pivot = arr[endIdx];//last element = the pivot

            int holder = startIdx - 1; //will tell the position of the last <= pivot value
            for (int i = startIdx; i < endIdx; i++)
            {
                if (arr[i].CompareTo(pivot) <= 0)
                {
                    holder++;
                    int tmp = arr[i];
                    arr[i] = arr[holder];
                    arr[holder] = tmp;
                }
            }
            holder++;
            //swapping
            int tmp2 = arr[endIdx];
            arr[endIdx] = arr[holder];
            arr[holder] = tmp2;
            return holder;
        }
    }
}