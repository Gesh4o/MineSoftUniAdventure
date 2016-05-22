namespace _04.SquaresInMatrix
{
    using System;
    using System.Linq;

    public class SquareInMatrixMain
    {
        public static void Main(string[] args)
        {
            int[] rowAndCol = Console.ReadLine()
                            .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            char[,] matrix = new char[rowAndCol[0], rowAndCol[1]];

            for (int row = 0; row < rowAndCol[0]; row++)
            {
                string rowAsString = string.Join(string.Empty, Console.ReadLine().Split(' '));
                for (int col = 0; col < rowAndCol[1]; col++)
                {
                    matrix[row, col] = rowAsString[col];
                }
            }

            int count = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] &&
                        matrix[row, col] == matrix[row + 1, col] &&
                        matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);

        }
    }
}
