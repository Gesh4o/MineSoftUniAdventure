namespace Assertions_Homework
{
    using System;
    using System.Diagnostics;

    public class Assertions
    {
        public static void Main()
        {
            int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
            Console.WriteLine("array = [{0}]", string.Join(", ", arr));
            SelectionSort(arr);
            Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

            SelectionSort(new int[0]); // Test sorting empty array
            SelectionSort(new int[1]); // Test sorting single element array

            Console.WriteLine(BinarySearch(arr, -1000));
            Console.WriteLine(BinarySearch(arr, 0));
            Console.WriteLine(BinarySearch(arr, 17));
            Console.WriteLine(BinarySearch(arr, 10));
            Console.WriteLine(BinarySearch(arr, 1000));
        }

        public static void SelectionSort<T>(T[] array) where T : IComparable<T>
        {
            Debug.Assert(array != null, "Cannot sort null array!"); // It is said to use Assert.

            Debug.Assert(array.Length != 0, "Array is empty!");

            int arrayLength = array.Length;
            for (int index = 0; index < arrayLength - 1; index++)
            {
                int minElementIndex = FindMinElementIndex(array, index, array.Length - 1);
                Swap(ref array[index], ref array[minElementIndex]);
            }

            for (int i = 0; i < arrayLength - 1; i++)
            {
                Debug.Assert(array[i].CompareTo(array[i + 1]) < 0, "Sorting not performed!");
            }
        }

        public static int BinarySearch<T>(T[] array, T value) where T : IComparable<T>
        {
            Debug.Assert(array != null, "Cannot sort null array!");

            Debug.Assert(array.Length != 0, "Array is empty!");

            Debug.Assert(value != null, "Given value argument is null.");

            return BinarySearch(array, value, 0, array.Length - 1);
        }

        private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex) 
            where T : IComparable<T>
        {
            int minElementIndex = startIndex;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }

            return minElementIndex;
        }

        private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex) 
            where T : IComparable<T>
        {
            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;
                if (arr[midIndex].Equals(value))
                {
                    return midIndex;
                }

                if (arr[midIndex].CompareTo(value) < 0)
                {
                    // Search on the right half
                    startIndex = midIndex + 1;
                }
                else 
                {
                    // Search on the right half
                    endIndex = midIndex - 1;
                }
            }

            // Searched value not found
            // "...all possible precondition and postconditions are checked."
            Debug.Assert(false, "Value was not found!"); // It's dumb, I know.
            return -1;
        }

        private static void Swap<T>(ref T firstValue, ref T secondValue)
        {
            T oldFirstValue = firstValue;
            firstValue = secondValue;
            secondValue = oldFirstValue;
        }
    }
}
