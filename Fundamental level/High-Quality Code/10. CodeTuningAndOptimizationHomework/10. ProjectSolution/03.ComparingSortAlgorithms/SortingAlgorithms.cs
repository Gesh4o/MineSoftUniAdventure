namespace _01.ComparingSortAlgorithms
{
    using System;
    using System.Diagnostics;

    public static class SortingAlgorithms
    {
        /// <summary>
        /// Mine sorting algorithm based on Selection sort.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        public static void SelectionSort<T>(T[] array) where T : IComparable<T>
        {
            ////ValidateArray(array);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int arrayLength = array.Length;
            for (int currentIndex = 0; currentIndex < arrayLength - 1; currentIndex++)
            {
                int minIndex = currentIndex;
                for (int nextIndex = currentIndex + 1; nextIndex < arrayLength; nextIndex++)
                {
                    if (array[minIndex].CompareTo(array[nextIndex]) > 0)
                    {
                        minIndex = nextIndex;
                    }   
                }

                T oldValue = array[currentIndex];
                array[currentIndex] = array[minIndex];
                array[minIndex] = oldValue;
            }

            ////for (int i = 0; i < arrayLength - 1; i++)
            ////{
            ////    Debug.Assert(array[i].CompareTo(array[i + 1]) < 0, "Sorting failed.");
            ////}
        }

        /// <summary>
        /// Mine sorting algorthm based on Insertion sort.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        public static void InsertSort<T>(T[] array) where T : IComparable<T>
        {
            ////ValidateArray(array);

            int arrayLength = array.Length;

            for (int currentIndex = 0; currentIndex < arrayLength - 1; currentIndex++)
            {
                int nextIndexToCompare = currentIndex + 1;   
                for (int sortedIndex = currentIndex; sortedIndex >= 0; sortedIndex--)
                {
                    if (array[sortedIndex].CompareTo(array[nextIndexToCompare]) > 0)
                    {
                        T oldValue = array[nextIndexToCompare];
                        array[nextIndexToCompare] = array[sortedIndex];
                        array[sortedIndex] = oldValue;
                        nextIndexToCompare--;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            ////for (int i = 0; i < arrayLength - 1; i++)
            ////{
            ////    Debug.Assert(array[i].CompareTo(array[i + 1]) <= 0, "Sorting failed.");
            ////}
        }

        /// <summary>
        /// Sorting algorthm using insertion sort.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        public static void PerformInsertionSort<T>(T[] array) where T : IComparable<T>
        {
            // I took this one from stackoverflow.com
            int arrayLength = array.Length;

            for (int nextIndex = 1; nextIndex < arrayLength; nextIndex++)
            {
                int uncheckedIndex = nextIndex;
                while ((uncheckedIndex > 0) && (array[uncheckedIndex].CompareTo(array[uncheckedIndex - 1]) > 1))
                {
                    int previousIndex = uncheckedIndex - 1;
                    T oldValue = array[previousIndex];
                    array[previousIndex] = array[uncheckedIndex];
                    array[uncheckedIndex] = oldValue;

                    uncheckedIndex--;
                }
            }
        }

        /// <summary>
        /// Sorting algorithm using selection sort.
        /// </summary>
        /// <param name="array"></param>
        /// <see cref="http://cforbeginners.com/CSharp/SelectionSort.html"/>
        public static void PerformSelectSort(int[] array)
        {
            int minimalPosition;
            int temp;
            for (int currentIndex = 0; currentIndex < array.Length - 1; currentIndex++)
            {
                minimalPosition = currentIndex;

                for (int nextIndex = currentIndex + 1; nextIndex < array.Length; nextIndex++)
                {
                    if (array[nextIndex] < array[minimalPosition])
                    {
                        minimalPosition = nextIndex;
                    }
                }

                if (minimalPosition != currentIndex)
                {
                    temp = array[currentIndex];
                    array[currentIndex] = array[minimalPosition];
                    array[minimalPosition] = temp;
                }
            }
        }

        /// <summary>
        /// Sorting algorithm using selection sort.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <see cref="https://begeeben.wordpress.com/2012/08/21/merge-sort-in-c/"/>
        public static void PerformMergeSort(int[] input, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                PerformMergeSort(input, left, middle);
                PerformMergeSort(input, middle + 1, right);

                // Merge
                int[] leftArray = new int[middle - left + 1];
                int[] rightArray = new int[right - middle];

                Array.Copy(input, left, leftArray, 0, middle - left + 1);
                Array.Copy(input, middle + 1, rightArray, 0, right - middle);

                int i = 0;
                int j = 0;
                for (int k = left; k < right + 1; k++)
                {
                    if (i == leftArray.Length)
                    {
                        input[k] = rightArray[j];
                        j++;
                    }
                    else if (j == rightArray.Length)
                    {
                        input[k] = leftArray[i];
                        i++;
                    }
                    else if (leftArray[i] <= rightArray[j])
                    {
                        input[k] = leftArray[i];
                        i++;
                    }
                    else
                    {
                        input[k] = rightArray[j];
                        j++;
                    }
                }
            }
        }

        /// <summary>
        /// Sorting algorithm using selection sort.
        /// </summary>
        /// <param name="elements"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <see cref="http://snipd.net/quicksort-in-c"/>
        public static void PerformQuicksort(int[] elements, int left, int right)
        {
            int i = left, j = right;
            int pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (elements[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    int tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                PerformQuicksort(elements, left, j);
            }

            if (i < right)
            {
                PerformQuicksort(elements, i, right);
            }
        }

        private static void ValidateArray<T>(T[] array) where T : IComparable<T>
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Cannot sort null array!");
            }

            if (array.Length == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(array), "Array is empty- cannot be sorted.");
            }
        }
    }
}
