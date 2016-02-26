namespace _02.MaximalSum
{
    using System;
    using System.Linq;

    public class MaximalSumMain
    {
        public static void Main(string[] args)
        {
            const int DefaultSquareSize = 3;

            int[] matrixSizes = Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

            int n = matrixSizes[0];
            int m = matrixSizes[1];

            int[,] matrix = new int[n, m];

            for (int row = 0; row < n; row++)
            {
                int[] matrixRow =
                    Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = matrixRow[col];
                }
            }

            int maximalSum = int.MinValue;
            int maximalSumRowIndex = -1;
            int maximalSumColIndex = -1;
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int currentSum = matrix[row, col] + matrix[row + 1, col] + matrix[row + 2, col]
                                   + matrix[row, col + 1] + matrix[row + 1, col + 1] + matrix[row + 2, col + 1]
                                   + matrix[row, col + 2] + matrix[row + 1, col + 2] + matrix[row + 2, col + 2];

                    if (currentSum > maximalSum)
                    {
                        maximalSum = currentSum;
                        maximalSumRowIndex = row;
                        maximalSumColIndex = col;
                    }
                }
            }

            if (maximalSumRowIndex != -1 && maximalSumColIndex != -1)
            {
                Console.WriteLine("Sum = {0}", maximalSum);

                for (int row = maximalSumRowIndex; row < maximalSumRowIndex + DefaultSquareSize; row++)
                {
                    for (int col = maximalSumColIndex; col < maximalSumColIndex + DefaultSquareSize; col++)
                    {
                        Console.Write("{0} ", matrix[row, col]);
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
