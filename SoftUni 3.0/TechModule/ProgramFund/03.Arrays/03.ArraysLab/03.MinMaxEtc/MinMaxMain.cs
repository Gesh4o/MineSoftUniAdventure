namespace _03.MinMaxEtc
{
    using System;
    using System.Linq;

    public class MinMaxMain
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            string outputFormat = @"Sum = {0}
Min = {1}
Max = {2}
First = {3}
Last = {4}
Average = {5}
";
            Console.WriteLine(outputFormat, array.Sum(), array.Min(), array.Max(), array.First(), array.Last(), array.Average());

        }
    }
}
