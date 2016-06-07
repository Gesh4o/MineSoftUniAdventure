namespace _05.MaxPlatform
{
    using System;
    using System.Linq;

    public class MaxPlatformMain
    {
        public static void Main(string[] args)
        {
            long maxPlatformValue = long.MinValue;

            long[] rowAndCol = Console.ReadLine()
                           .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                           .Select(long.Parse)
                           .ToArray();

            long[,] matrix = new long[rowAndCol[0], rowAndCol[1]];

            for (int row = 0; row < rowAndCol[0]; row++)
            {
                long[] array = Console.ReadLine()
                    .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();

                for (int col = 0; col < rowAndCol[1]; col++)
                {
                    matrix[row, col] = array[col];
                }
            }

            int maxPlatformRow = -1;
            int maxPlatformCol = -1;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    long maxValue = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                        + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                        + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (maxValue > maxPlatformValue)
                    {
                        maxPlatformValue = maxValue;
                        maxPlatformRow = row;
                        maxPlatformCol = col;
                    }
                }
            }

            Console.WriteLine(maxPlatformValue);
            PrintPlatform(matrix, maxPlatformRow, maxPlatformCol);
        }

        private static void PrintPlatform(long[,] matrix, int maxPlatformRow, int maxPlatformCol)
        {
            for (int row = maxPlatformRow; row <= maxPlatformRow + 2; row++)
            {
                for (int col = maxPlatformCol; col <= maxPlatformCol + 2; col++)
                {
                    if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
                    {
                        Console.Write(matrix[row, col] + " ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
