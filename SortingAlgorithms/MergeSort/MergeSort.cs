using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MergeSortAlgorithm
{
    public static void Main()
    {
        int[] arr1 = { 2, 1, 5, 4, 0, 3, -1 };
        int[] arr2 = { 2, 1, 5, 4, 0, 3, -1 };
        Print(arr1, "Original array: ");
        MergeSort1(arr1);
        Print(arr1, "Sorted array using MergeSort version 1:");

        Print(arr2, "\nOriginal array: ");
        MergeSort2(arr2);
        Print(arr2, "Sorted array using MergeSort version 2:");
    }

    // A simple method prints the elements of an array in a single row
    public static void Print(int[] arr, string msg)
    {
        Console.WriteLine(msg);
        foreach (int i in arr)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }

    /*
    * Version 2 - Steps:
    * 1. Splits an array into two halves using the middle element
    * 2. Recursively sorts the left half
    * 3. Recursively sorts the right half
    * 4. Merges the sorted left half and sorted right half
    */

    public static void MergeSort2(int[] arr)
    {
        MergeSort2(0, arr.Length - 1, arr);
    }
    public static void MergeSort2(int left, int right, int[] arr)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;

            MergeSort2(left, mid, arr);
            MergeSort2(mid + 1, right, arr);

            Merge2(left, mid, right, arr);
        }

    }

    // Merges two sorted segments of an array into one sorted array
    public static void Merge2(int left, int mid, int right, int[] c)
    {
        int[] m = new int[right - left + 1];
        int i = left, j = mid + 1, k = 0; // i for left half, j for right half, k for array m
        while (i <= mid & j <= right)
        {
            if (c[i] < c[j])
                m[k++] = c[i++];
            else
                m[k++] = c[j++];
        }
        while (i <= mid)
            m[k++] = c[i++];

        while (j <= right)
            m[k++] = c[j++];

        for (int l = 0; l < m.Length; l++)
        {
            c[left + l] = m[l];
        }
    }


    /*
     * Version 1 - use of separate arrays
     * 1. if the size of arr is two or greater, split arr into two sub arrays, 
     *    store the left half in array a, store the right half in array b
     * 2. recursively sort array a
     * 3. recursively sort array b
     * 4. merge a and b into arr
     */

    public static void MergeSort1(int[] arr)
    {

        // your code for steps 1 & 2in
        if (arr.Length > 1)
        {
            int[] a = new int[arr.Length / 2];
            int[] b = new int[arr.Length - arr.Length / 2];
            // your code here to populate a and b
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = arr[i];
            }
            for (int i = a.Length; i < arr.Length; i++)
            {
                b[i - a.Length] = arr[i];
            }
            //Program.Print(a);
            //Program.Print(b);
            MergeSort1(a);
            MergeSort1(b);

            Merge1(a, b, arr);
        }
    }

    // Merges two sorted arrays (a & b) into one sorted array (c)
    public static void Merge1(int[] a, int[] b, int[] c)
    {
        int i = 0, j = 0, k = 0; // index i for a, j for b, k for c
        /* 
        while( both a and b are not empty ){
            read the smaller number and store it in array c
        }*/
        while (i < a.Length && j < b.Length)
        {
            if (a[i] < b[j])
            {
                c[k++] = a[i++];
            }
            else
            {
                c[k++] = b[j++];
            }
        }
        /*
        while( a is not empty){
            read all the numbes from a into c
        } */
        while (i < a.Length)
        {
            c[k++] = a[i++];
        }
        /*
        while( b is not empty){
            read all the numbes from b into c
        } */
        while (j < b.Length)
        {
            c[k++] = b[j++];
        }
    }
}