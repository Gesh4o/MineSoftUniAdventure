namespace _01.CountWorkingDays
{
    using System;

    public class WorkingDaysMain
    {
        public static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());

            var firstMatrix = InitializeFirstMatrix(row, col);

            var secondMatrix = InitializeSecondMatrix(row, col);

            PrintMatrixOfAddition(row, col, firstMatrix, secondMatrix);
        }

        private static void PrintMatrixOfAddition(int row, int col, int[,] firstMatrix, int[,] secondMatrix)
        {
            int[,] result = new int[row, col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    result[i, j] = firstMatrix[i, j] + secondMatrix[i, j];

                    Console.Write(result[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        private static int[,] InitializeSecondMatrix(int row, int col)
        {
            int[,] secondMatrix = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write("Enter Matrix({0},{1}): ", i, j);
                    secondMatrix[i, j] = int.Parse(Console.ReadLine());
                }
            }
            return secondMatrix;
        }

        private static int[,] InitializeFirstMatrix(int row, int col)
        {
            int[,] firstMatrix = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write("Enter Matrix({0},{1}): ", i, j);
                    firstMatrix[i, j] = int.Parse(Console.ReadLine());
                }
            }
            return firstMatrix;
        }
    }
}
