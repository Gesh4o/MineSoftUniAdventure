namespace _06.HourglassSum
{
    using System;
    using System.Linq;

    public class HourglassMain
    {
        private const int DefaultMatrixRows = 6;
        private const int DefaultMatrixCols = 6;

        public static void Main(string[] args)
        {
            int[,] matrix = InitializeMatrix();

            long maxSum = GetmaxSum(matrix);

            Console.WriteLine(maxSum);
        }

        private static long GetmaxSum(int[,] matrix)
        {
            long maxSum = long.MinValue;
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    long currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] + matrix[row + 1, col + 1]
                                      + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                    }
                }
            }

            return maxSum;
        }

        private static int[,] InitializeMatrix()
        {
            int[,] matrix = new int[DefaultMatrixRows, DefaultMatrixCols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currentRow =
                    Console.ReadLine()
                        .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            return matrix;
        }
    }
}
