namespace _07.Matrices
{
    using System;

    public class MatricesMain
    {
        public static void Main(string[] args)
        {
            string[] inputInfo = Console.ReadLine().Split(' ');

            var matrix = GenerateMatrix(inputInfo);

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static int[,] GenerateMatrix(string[] inputInfo)
        {
            int[,] matrix = new int[int.Parse(inputInfo[1]), int.Parse(inputInfo[2])];
            string pattern = inputInfo[0];

            switch (pattern)
            {
                case "A":
                    ProcessPatternA(matrix);
                    break;
                case "B":
                    ProcessPatternB(matrix);
                    break;
                case "C":
                    ProcessPatternC(matrix);
                    break;
                case "D":
                    ProcessPatterD(matrix);
                    break;
            }

            return matrix;
        }

        private static void ProcessPatterD(int[,] matrix)
        {
            int startRow = 0;
            int startCol = 0;

            int counter = 1;

            while (startRow <= matrix.GetLength(0) / 2)
            {
                counter = PopulateFrame(matrix, startRow, startCol, counter);
                startRow++;
                startCol++;
            }
        }

        private static int PopulateFrame(int[,] matrix, int startRow, int startCol, int counter)
        {
            for (int row = startRow; row < matrix.GetLength(0) - startRow; row++)
            {
                if (matrix[row, startCol] == 0)
                {
                    matrix[row, startCol] = counter++;
                }
            }

            int botRow = matrix.GetLength(0) - startRow - 1;
            for (int col = startCol + 1; col < matrix.GetLength(1) - startCol; col++)
            {
                if (matrix[botRow, col] == 0)
                {
                    matrix[botRow, col] = counter++;
                }
            }

            int rightCol = matrix.GetLength(1) - 1 - startCol;
            for (int row = matrix.GetLength(0) - 1 - startRow - 1; row >= startRow; row--)
            {
                if (matrix[row, rightCol] == 0)
                {
                    matrix[row, rightCol] = counter++;
                }
            }

            for (int col = matrix.GetLength(1) - 1 - startCol - 1; col > startCol; col--)
            {
                if (matrix[startRow, col] == 0)
                {
                    matrix[startRow, col] = counter++;
                }
            }

            return counter;
        }

        private static void ProcessPatternC(int[,] matrix)
        {
            int counter = 1;

            for (int startingRow = matrix.GetLength(0) - 1; startingRow >= 0; startingRow--)
            {
                int col = 0;
                for (int row = startingRow; row < matrix.GetLength(0); row++)
                {
                    matrix[row, col++] = counter++;
                }
            }

            for (int startingCol = 1; startingCol < matrix.GetLength(1); startingCol++)
            {
                int row = 0;
                for (int col = startingCol; col < matrix.GetLength(1); col++)
                {
                    matrix[row++, col] = counter++;
                }
            }
        }

        private static void ProcessPatternB(int[,] matrix)
        {
            int counter = 1;

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (col % 2 == 0)
                {
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        matrix[row, col] = counter++;
                    }
                }
                else
                {
                    for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
                    {
                        matrix[row, col] = counter++;
                    }
                }
            }
        }

        private static void ProcessPatternA(int[,] matrix)
        {
            int counter = 1;
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    matrix[row, col] = counter++;
                }
            }
        }
    }
}
