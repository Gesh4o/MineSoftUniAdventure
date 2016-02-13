namespace _01.SortArrayOfNumbers
{
    using System;
    using System.Linq;

    public class SortArrayMain
    {
        public static void Main()
        {
            int[] array =
                Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            array = BubleSortAlgorithm.SortIntegers(array);

            Console.WriteLine(string.Join(" ", array));
        }
    }
}
