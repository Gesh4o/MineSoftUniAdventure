namespace _04.SequenceInMatrix
{
    using System;
    using System.Linq;

    public class SequenceInMatrixMain
    {
        public static void Main()
        {
            Console.Write("Enter matrix row count n = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter columns on each row m = ");
            int m = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter all elements of the matrix with each row on separate line and each element separated by single space:\n(e.g: 1 2 3\n      4 5 6)");

            string[,] matrix = new string[n, m];
            InitializeMatrix(matrix, m);

            int maxRepetitionCount = 0;
            string repeatedValue = string.Empty;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    string currentValue = matrix[row, col];
                    var currentRepetitionCount = GetCurrentMaxRepetitionCount(matrix, row, col);

                    if (currentRepetitionCount > maxRepetitionCount)
                    {
                        maxRepetitionCount = currentRepetitionCount;
                        repeatedValue = currentValue;
                    }
                }
            }

            PrintResult(maxRepetitionCount, repeatedValue);
        }
        
        private static void InitializeMatrix(string[,] matrix, int m)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] rowArray = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                while (rowArray.Length != m)
                {
                    Console.WriteLine("Invalid input, try again: ");
                    rowArray = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                }

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowArray[col];
                }
            }
        }

        private static int GetCurrentMaxRepetitionCount(string[,] matrix, int row, int col)
        {
            int sameValuesInColumnCount = GetSameValuesInAColCount(matrix, row, col);

            int sameValuesInRowCount = GetSameValuesInRowCount(matrix, row, col);

            int sameValuesInDiagonalCount = GetSameValuesInDiagonalCount(matrix, row, col);

            int currentRepetitionCount = Math.Max(
                sameValuesInColumnCount,
                Math.Max(sameValuesInDiagonalCount, sameValuesInRowCount));
            return currentRepetitionCount;
        }

        private static int GetSameValuesInDiagonalCount(string[,] matrix, int row, int col)
        {
            int diagonalRow = row + 1;
            int diagonalCol = col + 1;
            int sameValuesInDiagonalCount = 0;

            while (diagonalRow < matrix.GetLength(0) && diagonalCol < matrix.GetLength(1))
            {
                if (matrix[row, col] == matrix[diagonalRow, diagonalCol])
                {
                    diagonalRow++;
                    diagonalCol++;
                    sameValuesInDiagonalCount++;
                }
                else
                {
                    break;
                }
            }

            return sameValuesInDiagonalCount;
        }

        // Searching same values for in a row- basically like same logic.
        private static int GetSameValuesInRowCount(string[,] matrix, int row, int col)
        {
            string currentValue = matrix[row, col];
            int sameValuesInRowCount = 0;
            int nextCol = col + 1;
            while (nextCol < matrix.GetLength(1))
            {
                if (matrix[row, nextCol] == currentValue)
                {
                    sameValuesInRowCount++;
                    nextCol++;
                }
                else
                {
                    break;
                }
            }

            return sameValuesInRowCount;
        }

        // Iterates through every column for the current col if the value below(below in matrix, AKA row + 1) is the same
        // increments a counter but if the next value is different it exits the loop.
        private static int GetSameValuesInAColCount(string[,] matrix, int row, int col)
        {
            int sameValuesInColumnCount = 0;
            string currentValue = matrix[row, col];
            int nextRow = row + 1;
            while (nextRow < matrix.GetLength(0))
            {
                if (matrix[nextRow, col] == currentValue)
                {
                    sameValuesInColumnCount++;
                    nextRow++;
                }
                else
                {
                    break;
                }
            }
            
            return sameValuesInColumnCount;
        }

        private static void PrintResult(int maxRepetitionCount, string repeatedValue)
        {
            if (maxRepetitionCount != 0)
            {
                string[] repeatativeArray = new string[maxRepetitionCount + 1];
                for (int i = 0; i < repeatativeArray.Length; i++)
                {
                    repeatativeArray[i] = repeatedValue;
                }

                Console.WriteLine(string.Join(", ", repeatativeArray));
            }
        }
    }
}
