/*
 * QuickSort - vesion 3 use of one array only
 * Nov 11, 2024
 */

using System;
class Sort
{
    static void Main()
    {
        int[] x = { 5, 1, 2, 4, 6, 3, -10};
        QuickSort(x, 0, x.Length-1);
        Print(x);
    }
    static void QuickSort(int[] arr, int left, int right)
    {
        if (right > left) // continues to sort only if the array size is 2 or greater
        {
            // Chooses the last number in arr as the pivot
            int pivot = arr[right];

            // indexes l and r are used to iterate over the numbers from the left and right
            // r starts from the second number to the last one, which is the pivot
            // p is the index of pivot
            int l = left, r = right-1, p, temp; 

            while(true)
            {
                // Advances l index untill the number is greater than the pivot
                while (l < right && arr[l] < pivot)
                {
                    l++;
                }

                // Advances the l index untill the number is less than the pivot
                while (r >= 0 && arr[r] > pivot)
                {
                    r--;
                }

                // Swapts the two numbers if indexes l and r have not crossed each other
                if (l < r)
                {
                    temp = arr[l];
                    arr[l] = arr[r];
                    arr[r] = temp;
                    l++; // Moves l one position to the right
                    r--; // Moves r one positive to the left
                }
                if (l == r) // If l and r meet
                {
                    if (arr[l] < pivot)
                    {
                        arr[right] = arr[l+1];
                        arr[l+1] = pivot;
                        p = l + 1;
                        break;
                    } else // arr[l] > pivot
                    {
                        arr[right] = arr[l];
                        arr[l] = pivot;
                        p = l;
                        break;
                    }
                } 
                // If l and r already passed each other
                if (l > r)
                {
                    arr[right] = arr[l];
                    arr[l] = pivot;
                    p = l;
                    break;
                }
            }

            QuickSort(arr, left, p-1); ; // Sorts the left half of arr recursively
            QuickSort(arr, p+1, right); // Sorts the right half of arr recursively
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