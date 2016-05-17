namespace _02.SortNumbersWithSelectionSort
{
    using System;
    using System.Linq;

    public class SelectionSortMain
    {
        public static void Main(string[] args)
        {
            int[] array =
                Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            array = SelectionSort.SortIntegers(array);

            Console.WriteLine(string.Join(" ", array));
        }
    }
}
