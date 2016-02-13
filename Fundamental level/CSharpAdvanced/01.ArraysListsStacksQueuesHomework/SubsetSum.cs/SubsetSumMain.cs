namespace SubsetSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SubsetSumMain
    {
        public static void Main()
        {
            int searchedSum = int.Parse(Console.ReadLine());

            int[] sequence =
                Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            List<List<int>> subSets = new List<List<int>>();

            int upperBound = (int)Math.Pow(2, sequence.Length);
            for (int i = 0; i < upperBound; i++)
            {
                int sum = 0;
                List<int> subsequence = new List<int>();

                // Used a lot of help for this one. :/
                for (int j = 0; j < sequence.Length; j++)
                {
                    if ((i & (1 << j)) != 0)
                    {
                        sum += sequence[(sequence.Length - 1) - j];
                        subsequence.Add(sequence[(sequence.Length - 1) - j]);
                    }
                }

                if (sum == searchedSum)
                {
                    subSets.Add(subsequence);
                }

            }

            subSets = subSets.OrderBy(s => s.Count).ThenBy(s => s.Min()).ToList();
            for (int i = 0; i < subSets.Count; i++)
            {
                subSets[i] = subSets[i].OrderBy(s => s).ToList();
            }

            subSets = subSets.Distinct().ToList();

            foreach (var subSet in subSets)
            {
                Console.WriteLine("{0} = {1}", string.Join(" + ", subSet), searchedSum);
            }
        }
    }
}
