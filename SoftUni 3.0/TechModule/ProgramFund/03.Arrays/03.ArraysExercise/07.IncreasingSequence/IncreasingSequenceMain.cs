namespace _07.IncreasingSequence
{
    using System;
    using System.Linq;

    public class IncreasingSequenceMain
    {
        public static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine()
                   .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();

            int maxLength = -1;
            int startingIndex = -1;
            for (int index = 0; index < sequence.Length; index++)
            {
                int previousIndex = index;
                int currentLength = 1;
                for (int nextIndex = index + 1; nextIndex < sequence.Length; nextIndex++)
                {
                    if (sequence[previousIndex] < sequence[nextIndex])
                    {
                        currentLength++;
                    }
                    else
                    {
                        break;
                    }

                    previousIndex++;
                }

                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    startingIndex = index;
                }
            }

            for (int num = 0; num < maxLength; num++)
            {
                Console.Write(sequence[startingIndex + num] + " ");
            }

            Console.WriteLine();
        }
    }
}
