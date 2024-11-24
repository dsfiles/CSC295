/*
 * QuickSort - vesion 2
 * Nov 10, 2024
 */

using System;
class Sort
{
    static void Main()
    {
        int[] x = { 5, 1, 2, 4, 6, 3};
        QuickSort(x, 0, x.Length-1);
        Print(x);
    }
    static void QuickSort(int[] arr, int left, int right)
    {
        if (right > left) // continues to sort only if the array size is 2 or greater
        {
            // Creates a temporary array to store re-arranged numbers using the pivot
            int[] temp = new int[right-left+1];

            // Chooses the last number in arr as the pivot
            int pivot = arr[right];

            int l = 0, r = right-left;

            for (int i = left; i <= right; i++)
            {
                // Compares each number in arr to the pivot. If the number is greater or equal to the pivot,
                // place the number in array temp starting from the last position. The pivot will be placed
                // at the correct position.
                if (arr[i] >= pivot)
                {
                    temp[r--] = arr[i];
                }
                else
                // Places the numbers that are less than the pivot in the first positition and continues
                // untill the position just before the pivot.
                {
                    temp[l++] = arr[i];
                }
            }

            // Copy the re-arranged numbers back to arr
            for (int i = 0; i < temp.Length; i++)
            {
                arr[i+left] = temp[i];
            }

            // variable left+l is the index of pivot in arr
            QuickSort(arr, left, left+l-1); ; // Sorts the left half of arr recursively
            QuickSort(arr, left+l+1, right); // Sorts the right half of arr recursively
        }
    }

    // A simple utility method to print an array
    static void Print(int[] arr)
    {
        foreach (var item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}