namespace _07.SumArrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumArraysMain
    {
        public static void Main(string[] args)
        {
            List<int> firstSequence = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> secondSequence = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int biggerLength = Math.Max(firstSequence.Count - 1, secondSequence.Count - 1);

            EqualFirstSequenceCount(firstSequence, biggerLength);

            EqualSecondSequenceCount(secondSequence, biggerLength);

            for (int i = 0; i < firstSequence.Count; i++)
            {
                Console.Write(firstSequence[i] + secondSequence[i] + " ");
            }

            Console.WriteLine();
        }

        private static void EqualFirstSequenceCount(List<int> firstSequence, int biggerLength)
        {
            int firstCount = 0;
            int firstListInitialLength = firstSequence.Count;
            while (firstSequence.Count - 1 < biggerLength)
            {
                firstCount %= firstListInitialLength;
                firstSequence.Add(firstSequence[firstCount]);
                firstCount++;
            }
        }

        private static void EqualSecondSequenceCount(List<int> secondSequence, int biggerLength)
        {
            int secondCount = 0;
            int secondListInitialLength = secondSequence.Count;
            while (secondSequence.Count - 1 < biggerLength)
            {
                secondCount %= secondListInitialLength;
                secondSequence.Add(secondSequence[secondCount]);
                secondCount++;
            }
        }
    }
}
