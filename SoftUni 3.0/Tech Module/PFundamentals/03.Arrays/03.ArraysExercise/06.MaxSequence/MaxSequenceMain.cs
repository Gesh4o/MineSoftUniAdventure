namespace _06.MaxSequence
{
    using System;
    using System.Linq;

    internal class MaxSequenceMain
    {
        public static void Main(string[] args)
        {
            int[] sequence =
                Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            int maxEqualElementValue = int.MinValue;
            int maxEqualElementEqualCount = -1;
            for (int currentIndex = 0; currentIndex < sequence.Length; currentIndex++)
            {
                int nextIndex = currentIndex + 1;

                while (nextIndex < sequence.Length && sequence[currentIndex] > sequence[nextIndex])
                {
                    nextIndex++;
                }

                int currentCount = nextIndex - currentIndex;
                if (maxEqualElementEqualCount < currentCount)
                {
                    maxEqualElementValue = sequence[currentIndex];
                    maxEqualElementEqualCount = nextIndex - currentIndex;
                }
            }

            for (int i = 0; i < maxEqualElementEqualCount; i++)
            {
                Console.Write("{0} ", maxEqualElementValue);
            }

            Console.WriteLine();
        }
    }
}
