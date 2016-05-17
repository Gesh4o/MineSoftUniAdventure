namespace _01.FillTheMatrix
{
    using System;

    public class FillTheMatrixMain
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n,n];

            //matrix = RotateTopToBottom(matrix);
            matrix = RotateTopToBottomBottomToTop(matrix);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + ", ");
                }

                Console.WriteLine();
            }
        }

        private static int[,] RotateTopToBottomBottomToTop(int[,] matrix)
        {
            int counter = 1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row % 2 == 1)
                    {
                        matrix[matrix.GetLength(0) - 1 - col, row] = counter;
                    }
                    else
                    {
                        matrix[col, row] = counter;
                    }

                    counter++;
                }
            }

            return matrix;
        }

        private static int[,] RotateTopToBottom(int[,] matrix)
        {
            int counter = 1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[col, row] = counter;
                    counter++;
                }
            }

            return matrix;
        }
    }
}
