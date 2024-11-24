/*
 * MergeSort() - split one array into two separate arrays
 * Merge() - merge two arrays into one aray
 * 11/9/2024
 */

using System;
public class Program {
    public static void Main(string[] args) {
        Console.WriteLine("hi");
        int[] a = {1, 3, 5};
        int[] b = {4, 6, 8, 10, 200};
        //int[] c = new int[a.Length + b.Length];
        
        int[] c = { 1, 3, 5, 4, 6, 8, 10, 200 };

        MergeSort(c);
        foreach (var item in c)
        {
            Console.WriteLine( item);
        }
    }


    static void MergeSort(int[] arr)
    {
        if (arr.Length > 1)
        {
            int[] a = new int[arr.Length / 2];
            int[] b = new int[arr.Length - arr.Length / 2];
            for (int i = 0; i < arr.Length/2; i++)
            {
                a[i] = arr[i];
            }
            for (int i = arr.Length/2; i < arr.Length; i++)
            {
                b[i-arr.Length/2] = arr[i];
            }
            Console.WriteLine("-----a-----");
            foreach (var item in a)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----b-----");
            foreach (var item in b)
            {
                Console.WriteLine(item);
            }

            MergeSort(a);
            MergeSort(b);
            int[] t = new int[arr.Length];
            Merge(a, b, t);
            for (int i = 0; i < t.Length; i++)
            {
                arr[i] = t[i];
            }
        }
    }

    static void Merge(int[] a, int[] b,  int[] c)
    {  
        int i=0; int j=0; int k=0;
        while( i<a.Length && j<b.Length)
        {
            if (a[i] < b[j] )
            {
                c[k++] = a[i++];
            }
            else
            {
                c[k++] = b[j++];
            }
        }
        while (i < a.Length)
        {
            c[k++] = a[i++];
        }
        while(j < b.Length)
        {
            c[k++] = b[j++];
        }
    }
}
