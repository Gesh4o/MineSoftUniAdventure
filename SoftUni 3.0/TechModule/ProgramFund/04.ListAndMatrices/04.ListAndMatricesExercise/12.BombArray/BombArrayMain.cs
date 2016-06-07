namespace _12.BombArray
{
    using System;
    using System.Linq;

    public class BombArrayMain
    {
        public static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] bombInfo = Console.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int bombNumber = bombInfo[0];
            int bombRange = bombInfo[1];

            for (int index = 0; index < sequence.Length; index++)
            {
                if (sequence[index] == bombNumber)
                {
                    int leftEnd = Math.Max(0, index - bombRange);
                    int rightEnd = Math.Min(sequence.Length - 1, index + bombRange);

                    for (int indexToRemove = leftEnd; indexToRemove <= rightEnd; indexToRemove++)
                    {
                        sequence[indexToRemove] = 0;
                    }
                }
            }

            Console.WriteLine(sequence.Sum());

        }
    }
}
