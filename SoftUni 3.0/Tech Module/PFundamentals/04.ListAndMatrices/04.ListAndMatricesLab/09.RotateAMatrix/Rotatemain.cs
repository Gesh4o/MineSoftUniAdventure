namespace _09.RotateAMatrix
{
    using System;
    using System.Linq;

    public class RotateMain
    {
        public static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            // Change here:
            var matrix = new string[rows, cols];
            var rotateMatrix = new string[cols, rows];

            // read matrix
            for (int row = 0; row < rows; row++)
            {
                var cells = Console.ReadLine().Split(' ').ToList();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = cells[col];
                }
            }

            // rotate matrix
            for (int r = 0; r < cols; r++)
            {
                for (int c = 0; c < rows; c++)
                {
                    // Change here:
                    rotateMatrix[r, c] = matrix[matrix.GetLength(0) - 1 - c, r];
                }
            }

            // print matrix
            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    Console.Write(rotateMatrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
