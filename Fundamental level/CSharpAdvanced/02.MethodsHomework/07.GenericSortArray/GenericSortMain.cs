namespace _07.GenericSortArray
{
    using System;

    public class GenericSortMain
    {
        public static void Main(string[] args)
        {
            int[] intArray = new[] { 1, 3, 4, 5, 1, 0, 5 };
            intArray = SortArray(intArray);

            Console.WriteLine(string.Join(", ", intArray));

            string[] stringArray = new[] { "sorted!", "Array", "is", "not" };
            stringArray = SortArray(stringArray);
            Console.WriteLine(string.Join(" ", stringArray));

            DateTime[] dateTimesArray = new[] { DateTime.Now, DateTime.Now.AddDays(12), DateTime.Now.AddHours(12) };
            dateTimesArray = SortArray(dateTimesArray);
            Console.WriteLine(string.Join(" -> ", dateTimesArray));
        }

        public static T[] SortArray<T>(T[] array) where T : IComparable<T>
        {
            for (int currentIndex = 0; currentIndex < array.Length - 1; currentIndex++)
            {
                int currentSmallestItemIndex = currentIndex;
                for (int nextIndex = currentIndex + 1; nextIndex < array.Length; nextIndex++)
                {
                    if (array[currentSmallestItemIndex].CompareTo(array[nextIndex]) > 0)
                    {
                        currentSmallestItemIndex = nextIndex;
                    }
                }

                if (currentSmallestItemIndex != currentIndex)
                {
                    T tempValue = array[currentIndex];
                    array[currentIndex] = array[currentSmallestItemIndex];
                    array[currentSmallestItemIndex] = tempValue;
                }
            }

            return array;
        }
    }
}
