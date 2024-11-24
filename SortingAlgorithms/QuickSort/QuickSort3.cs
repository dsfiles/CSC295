public class QuickSort3
{
    /*********************** Quick Sort ***********************
     *
     * QuickSort algorithm version 3 - use of one array only
     * 11/2024
     *********************************************************/
    public static void QuickSort(int[] arr)
    {
        QuickSort(arr, 0, arr.Length - 1);
    }
    public static void QuickSort(int[] arr, int left, int right)
    {
        int temp; // A temporary variable used to swap two numbers

        // If there are only two elements and they are out of order,swap them and return
        if (right - left == 1 && arr[left] > arr[right])
        {
            temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
            return;
        }

        // Indexes l and r are used to iterate over the numbers
        // l starts from left and scans righward
        // r starts from right and scans leftward
        // p will be used to mark the index of pivot
        int l = left, r = right - 1, p = right;

        // Chooses the last element in arr as the pivot
        int pivot = arr[right];

        // The [left, right] segment of arr has three or more elements.
        // moves index l first, then index r untill they overlap
        while (l < r) // Before l and r overlap
        {
            // Advances index l untill the number is greater than the pivot
            while (arr[l] < pivot && l < r)
            {
                l++; 
            }
            // Advances index r untill the number is less than the pivot
            while (arr[r] > pivot && l < r)
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
            p = l; // Updates the index of pivot, otherwise p stays the same, i.e., p is equial to index right
        }

        // Sorts the left half recursively if only there are two or more elements
        if (p - left >= 2)
            QuickSort(arr, left, p - 1);

        // Sorts the right half recursively if only there are two or more elements
        if (right - p >= 2)
            QuickSort(arr, p + 1, right);
    }
}