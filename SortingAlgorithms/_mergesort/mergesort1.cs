/*
 * MergeSort - one array
 */

using System;
class Sort
{
    static void Main()
    {
        int[] x = { 5, 1, 2, 4, 0, -23 };
        //foreach (int item in x)
        //{
        //    Console.WriteLine(item);
        //}

        MergeSort(0, x.Length - 1, x);
        foreach (int item in x)
        {
            Console.WriteLine(item);
        }
    }
    static void MergeSort(int left, int right, int[] x)
    {
        if (left < right)
        {

            int mid = (left + right) / 2;

            MergeSort(left, mid, x);
            MergeSort(mid + 1, right, x);

            Merge(left, right, mid, x);
        }
    }
    static void Merge(int left, int right, int mid, int[] c)
    {
        int[] m = new int[right - left + 1];

        int i = left, j = mid + 1, k = 0;

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
}