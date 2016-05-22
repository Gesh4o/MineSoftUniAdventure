namespace _05.MaxPlatform
{
    using System;
    using System.Linq;

    public class MaxPlatformMain
    {
        public static void Main(string[] args)
        {
            int maxPlatformValue = 0;

            ////int maxPlatformRow = -1;
            ////int maxPlatformCol = -1;

            int[] rowAndCol = Console.ReadLine()
                           .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                           .Select(int.Parse)
                           .ToArray();

            int[,] matrix = new int[rowAndCol[0], rowAndCol[1]];

            for (int row = 0; row < rowAndCol[0]; row++)
            {
                int[] array = Console.ReadLine()
                    .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < rowAndCol[1]; col++)
                {
                    matrix[row, col] = array[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int maxValue = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                        + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                        + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (maxValue > maxPlatformValue)
                    {
                        maxPlatformValue = maxValue;
                    }
                }
            }

            Console.WriteLine(maxPlatformValue);
        }
    }
}
