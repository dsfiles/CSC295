/* CSC295 Week2 Assignment
 * Write your own collection of sorting programs to implement these algorithms: 
 * Bubble sort, Insertion Sort, Selection Sort, Merge Sort, and Quick Sort. Do you get the same 
 * relative timings as shown in Figure 7.20 (Page 260)? If not, why do you think this happened? 
 * How do your results compare with those of your classmates? 
 * What does this say about the difficulty of doing empirical timing studies?
 */

using System;
using System.Diagnostics;
class Program
{
    static void Main(string[] args)
    {
        Random rand = new Random();
        Stopwatch stopwatch = new Stopwatch(); // Create a stopwatch object to track the time
        int size = 10000; // Try array sizes of 10, 100, 1k, 10k, 100k, or even higher
        int[] arr1 = new int[size];
        int[] arr2 = new int[size];
        int[] arr3 = new int[size];
        int[] arr4 = new int[size];
        int[] arr5 = new int[size];
        int[] arr6 = new int[size];

        // Create arrays of random numbers
        for (int i = 0; i < size; i++)
            arr1[i] = arr2[i] = arr3[i] = arr4[i] = arr5[i] = arr6[i] = rand.Next();

        // Create sorted arrays in ascending order
        //for (int i = 0; i < size; i++)
        //    arr1[i] = arr2[i] = arr3[i] = arr4[i] = arr5[i] = arr6[i] = i;

        // Create sorted arrays in descending order
        //for (int i = 0; i < size; i++)
        //    arr1[i] = arr2[i] = arr3[i] = arr4[i] = arr5[i] = arr6[i] = size-1-i;

        Console.WriteLine($"Time (in milliseconds) to sort {size} numbers ...");
        stopwatch.Start();
        BubbleSort(arr1);
        stopwatch.Stop();
        Console.WriteLine($"Regular bubble sort: {stopwatch.Elapsed.TotalMilliseconds}");

        stopwatch.Restart();
        BubbleSortOptimized(arr2);
        stopwatch.Stop();
        Console.WriteLine($"Optimized bubble sort: {stopwatch.Elapsed.TotalMilliseconds}");

        stopwatch.Restart();
        SelectionSort(arr3);
        stopwatch.Stop();
        Console.WriteLine($"Selection sort: {stopwatch.Elapsed.TotalMilliseconds}");

        stopwatch.Restart();
        InsertionSort(arr4);
        stopwatch.Stop();
        Console.WriteLine($"Insertion sort: {stopwatch.Elapsed.TotalMilliseconds}");

        stopwatch.Restart();
        MergeSort(arr5, 0, size - 1);
        stopwatch.Stop();
        Console.WriteLine($"Merge sort: {stopwatch.Elapsed.TotalMilliseconds}");

        stopwatch.Restart();
        QuickSort(arr6, 0, size - 1);
        stopwatch.Stop();
        Console.WriteLine($"Quick sort: {stopwatch.Elapsed.TotalMilliseconds}");
    }

    // Your sorting algorithms here
  
}
