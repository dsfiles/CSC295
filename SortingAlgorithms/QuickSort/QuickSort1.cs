/*
 * QuickSort Version 1 - Use of a temporary array (temp) to store re-arranged elements in the original array, 
 * and two arrays (lower and higher) to store all the elements that are less or greater than the pivot.
 * Last update 11/10/24
 */

using System;
public class QuickSort1
{
    public static void QuickSort(int[] arr)
    {
        if (arr.Length > 1) // continues to sort only if the array size is 2 or above
        {
            // Creates a temporary array to store rearranged numbers using the pivot
            int[] temp = new int[arr.Length];

            // Chooses the last number in arr as the pivot
            int pivot = arr[arr.Length - 1];

            int i = 0, l = 0, r = arr.Length - 1;

            while (i < arr.Length)
            {
                // Compares each number in arr to the pivot. If the number is greater or equal to the pivot,
                // place the number in array temp starting from the last position. The pivot will be placed
                // at the correct position.
                if (arr[i] >= pivot)
                {
                    temp[r--] = arr[i++];
                }
                else
                // Places the numbers that are less than the pivot in the first positition and continues
                // untill the position just before the pivot.
                {
                    temp[l++] = arr[i++];
                }
            }

            // Array x = [ 5, 1, 2, 4, 6, 3 ], array temp: [ 1, 2, 3, 6, 4, 5]. Index l becomes the index of pivot
            // after the while loop, l is also equal to the length of array with numbers that are less than the pivot

            // Creates an array to store the numbers less than the pivot
            int[] lower = new int[l];

            // Creates an array to store the numbers greater than the pivot, and the pivot itself
            int[] higher = new int[arr.Length - l - 1]; 

            for (int j = 0; j < l; j++)
            {
                lower[j] = temp[j];
            }

            for (int j = l + 1; j < arr.Length; j++)
            {
                higher[j - l - 1] = temp[j];
            }

            QuickSort(lower); // Sorts array lower recursively
            QuickSort(higher); // Sorts array higher recursively

            // Combines arrays lower, pivot, and higher into the final sorted array
            for (int j = 0; j < lower.Length; j++)
            {
                arr[j] = lower[j];
            }
            for (int j = higher.Length-1; j >= 0; j--)
            {
                arr[arr.Length - higher.Length + j ] = higher[j];
            }
            arr[l] = pivot; // Places the pivot back to the correct position in arr
        }
    }
}