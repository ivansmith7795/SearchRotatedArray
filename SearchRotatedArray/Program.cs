using System;
using System.Diagnostics;

//C# .NET Core example of how to search for a number in a rotated array using a modified binary search algorithm
//Written by Ivan Smith

namespace SearchRotatedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            //Build array and search for key values 3 and 6
            int[] v1 = { 6, 7, 1, 2, 3, 4, 5 };
            Debug.WriteLine("Key(3) found at: " + binary_search_rotated(v1, 3));
            Debug.WriteLine("Key(6) found at: " + binary_search_rotated(v1, 6));

            //Build array and search for key values 3 and 6
            int[] v2 = { 4, 5, 6, 1, 2, 3 };
            Debug.WriteLine("Key(3) found at: " + binary_search_rotated(v2, 3));
            Debug.WriteLine("Key(6) found at: " + binary_search_rotated(v2, 6));
        }

        public static int BinarySearch(
            int[] arr,
            int st,
            int end,
            int key)
        {
            // assuming all the keys are unique.

            //return -1 if value not found
            if (st > end)
            {
                return -1;
            }
            //split the array in two (binary search method)
            int mid = st + (end - st) / 2;

            //return mid if it is the key we're looking for
            if (arr[mid] == key)
            {
                return mid;
            }
           
            if (arr[st] <= arr[mid] &&
                key <= arr[mid] && key >= arr[st])
            {
                return BinarySearch(
                          arr, st, mid - 1, key);
            }
            else if (arr[mid] <= arr[end] &&
                     key >= arr[mid] && key <= arr[end])
            {
                return BinarySearch(
                            arr, mid + 1, end, key);
            }
            else if (arr[st] >= arr[mid])
            {
                return BinarySearch(
                            arr, st, mid - 1, key);
            }
            else if (arr[end] <= arr[mid])
            {
                return BinarySearch(
                            arr, mid + 1, end, key);
            }

            return -1;
        }

        static int binary_search_rotated(
            int[] arr,
            int key)
        {
            return BinarySearch(
                      arr, 0, arr.Length - 1, key);
        }
    }
}
