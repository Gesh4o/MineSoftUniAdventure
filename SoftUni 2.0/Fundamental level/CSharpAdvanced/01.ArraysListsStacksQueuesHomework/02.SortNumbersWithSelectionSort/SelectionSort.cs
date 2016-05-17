namespace _02.SortNumbersWithSelectionSort
{
    using System.Collections.Generic;
    using System.Linq;

    public static class SelectionSort
    {
        public static int[] SortIntegers(IList<int> collection)
        {
            for (int unsortedIndex = 0; unsortedIndex < collection.Count - 1; unsortedIndex++)
            {
                int currentSmallestNumIndex = unsortedIndex;
                for (int currentIndex = unsortedIndex + 1; currentIndex < collection.Count; currentIndex++)
                {
                    // Check if there is a number which is smaller and if so gets it index.
                    if (collection[currentSmallestNumIndex] > collection[currentIndex])
                    {
                        currentSmallestNumIndex = currentIndex;
                    }
                }

                // Performs swap when smaller number is found.
                if (currentSmallestNumIndex != unsortedIndex)
                {
                    int tempValue = collection[currentSmallestNumIndex];
                    collection[currentSmallestNumIndex] = collection[unsortedIndex];
                    collection[unsortedIndex] = tempValue;
                }
            }

            return collection.ToArray();
        }
    }
}
