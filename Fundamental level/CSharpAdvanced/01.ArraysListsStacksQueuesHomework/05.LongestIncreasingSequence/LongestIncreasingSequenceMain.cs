namespace _05.LongestIncreasingSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LongestIncreasingSequenceMain
    {
        public static void Main()
        {
            int[] inputArray =
                Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            List<int[]> sequences = new List<int[]>();

            int sequenceLength = 1;
            for (int currentIndex = 0; currentIndex < inputArray.Length; currentIndex++)
            {
                // End of the increasing sequence is put if it is the end of the array or if next element is not bigger.
                if (currentIndex == inputArray.Length - 1 || inputArray[currentIndex] >= inputArray[currentIndex + 1])
                {
                    int[] sequence = new int[sequenceLength];
                    for (int i = 0; i < sequenceLength; i++)
                    {
                        sequence[i] = inputArray[(currentIndex + 1) - sequenceLength + i];
                    }

                    sequenceLength = 1;
                    sequences.Add(sequence);
                }
                else
                {
                    sequenceLength++;
                }
            }


            foreach (int[] sequence in sequences)
            {
                Console.WriteLine(string.Join(" ", sequence));
            }

            Console.Write("Longest: ");
            Console.WriteLine(string.Join(" ", sequences.OrderByDescending(seq => seq.Length).First()));
        }
    }
}
