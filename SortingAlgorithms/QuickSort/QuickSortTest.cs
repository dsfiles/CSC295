public class QuickSortTest
{
    static void Main(string[] args)
    {
       int[] arr1 = { 2, 1, 5, 4, 0, 3, -1 };
        int[] arr2 = { 2, 1, 5, 4, 0, 3, -1 };
        int[] arr3 = { 2, 1, 5, 4, 0, 3, -1 };
        Print(arr1, "Original array: ");
        QuickSort1.QuickSort(arr1);
        Print(arr1, "Sorted array using QuickSort version 1:");

        Print(arr2, "\nOriginal array: ");
        QuickSort2.QuickSort(arr2);
        Print(arr2, "Sorted array using QuickSort version 2:");

        Print(arr3, "\nOriginal array: ");
        QuickSort3.QuickSort(arr3);
        Print(arr3, "Sorted array using QuickSort version 3:");

        int[] x = { 5, 1, 2, 4, 6, 3 };
        QuickSort2.QuickSort(x, 0, x.Length - 1);

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
} 