using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingProject
{
    public class Sort
    {

        public static void QuickSort(int[] arr, int left, int right)
        {
            // Returns to the calling method to stop recursion if there is only one element
            // in the array
            if (left == right) return;

            int temp; // a temporary variable used to swap two numbers
                      // if there are only two elements and they are out of order,
                      // swap them
            if (right - left == 1 && arr[left] > arr[right])
            {
                temp = arr[left];
                arr[left] = arr[right];
                arr[right] = temp;
            }

            // Indexes l and r are used to iterate over the numbers
            // l starts from left and scans righward
            // r starts from right and scans leftward
            // p will be used to mark the index of pivot
            int l = left, r = right - 1, p = right;

            // Chooses the last number in arr as the pivot
            int pivot = arr[right];

            // The [left, right] segment of arr has three or more elements
            // iterates index l first, then index r untill they overlap
            while (l < r)
            {
                while (arr[l] < pivot && l < r)
                {
                    l++;
                }
                // Advances the l index untill the number is less than the pivot
                while (arr[r] > pivot && l < r )
                {
                    r--;
                }
                // Swaps the two numbers if indexes l and r have not crossed each other
                if (l != r)
                {
                    temp = arr[l];
                    arr[l] = arr[r];
                    arr[r] = temp;
                }
            } //end of while (l < r)

            // Indexes l and r overalp, i.e., l == r
            // Swaps the number with the pivot if the number is greater then the pivot
            if (arr[l] > pivot)
            {
                temp = arr[l];
                arr[l] = arr[right];
                arr[right] = temp;
                p = l; // Updates the index of pivot, otherwise p stays at index "right"
            }

            // Sorts the left half recursively if there are two or more elements
            if (p - left >= 2)
                QuickSort(arr, left, p - 1);

            // Sorts the right half recursively if there are two or more elements
            if (right - p >= 2)
                QuickSort(arr, p + 1, right);

        }
        public static void MergeSort(int[] arr)
        {
            /*
             * 1. if the size of arr is two or greater split arr into two sub arrays, 
             *    store the left half in array a, store the right half in array b
             * 2. recursively sort array a
             * 3. recursively sort array b
             * 4. merge a and b into arr
             */

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
                    b[i-a.Length] = arr[i];
                }
                //Program.Print(a);
                //Program.Print(b);
                MergeSort(a);
                MergeSort(b);

                Merge(a, b, arr);
            }
        }
        public static void MergeSort2(int[] arr)
        {
            MergeSort(0, arr.Length-1, arr);
        }
        public static void MergeSort(int left, int right, int[] arr)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;

                MergeSort(left, mid, arr);
                MergeSort(mid + 1, right, arr);

                Merge(left, mid, right, arr);
            }

        }
        public static void Merge(int left, int mid, int right, int[] c)
        {
            int[] m = new int[right - left + 1];
            int i = left, j = mid + 1, k = 0; // i for left half, j for right half, k for array m
            while (i <= mid & j <= right)  {
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
        public static void Merge(int[] a, int[] b, int[] c)
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
}
