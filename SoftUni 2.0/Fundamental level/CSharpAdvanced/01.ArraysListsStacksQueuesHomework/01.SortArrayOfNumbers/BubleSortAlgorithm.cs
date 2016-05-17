namespace _01.SortArrayOfNumbers
{
    using System.Collections.Generic;
    using System.Linq;

    public static class BubleSortAlgorithm
    {
        public static int[] SortIntegers(IList<int> collection)
        {
            // SortedIndex contains the index of the last unsorted element. 
            for (int sortedIndex = collection.Count - 1; sortedIndex > 0; sortedIndex--)
            {
                for (int currentIndex = 0; currentIndex < sortedIndex; currentIndex++)
                {
                    if (collection[currentIndex] > collection[currentIndex + 1])
                    {
                        int tempValue = collection[currentIndex + 1];
                        collection[currentIndex + 1] = collection[currentIndex];
                        collection[currentIndex] = tempValue;
                    }
                }
            }

            return collection.ToArray();
        } 
    }
}
