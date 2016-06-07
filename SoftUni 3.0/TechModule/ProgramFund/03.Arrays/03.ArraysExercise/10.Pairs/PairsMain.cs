namespace _10.Pairs
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class PairsMain
    {
        public static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int difference = int.Parse(Console.ReadLine());
            HashSet<int> visitedIndexes = new HashSet<int>();
            int count = 0;
            for (int firstIndex = 0; firstIndex < sequence.Length; firstIndex++)
            {
                for (int secondIndex = firstIndex + 1; secondIndex < sequence.Length; secondIndex++)
                {
                    int currentDifference = sequence[firstIndex] - sequence[secondIndex];
                    if (currentDifference < 0)
                    {
                        currentDifference *= -1;
                    }

                    if (currentDifference == difference)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
