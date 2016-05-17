namespace _14.TextGravity
{
    using System;
    using System.Security;

    public class TextGravityMain
    {
        public static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int rowCount = GetRowCount(input, length);

            string[,] matrix = new string[rowCount, length];
            InitializeMatrix(matrix, input);

            GravitateText(matrix);

            EscapeMatrix(matrix);

            PrintMatrix(matrix);
        }

        private static int GetRowCount(string input, int length)
        {
            double possibleRowCount = input.Length / (length * 1.0);
            int rowCount = (int)possibleRowCount;

            if (possibleRowCount != (int)possibleRowCount)
            {
                rowCount = (int)possibleRowCount + 1;
            }

            return rowCount;
        }

        private static void InitializeMatrix(string[,] matrix, string input)
        {
            int inputCharCount = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (inputCharCount < input.Length)
                    {
                        matrix[row, col] = input[inputCharCount].ToString();
                        inputCharCount++;
                    }
                    else
                    {
                        matrix[row, col] = " ";
                    }
                }
            }
        }

        private static void GravitateText(string[,] matrix)
        {
            for (int row = matrix.GetLength(0) - 2; row >= 0; row--)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    int spaceRowCount = 1;
                    while (row + spaceRowCount < matrix.GetLength(0) - 1 && matrix[row + spaceRowCount, col] == " ")
                    {
                        spaceRowCount++;
                    }

                    if (spaceRowCount != 1)
                    {
                        spaceRowCount--;
                    }

                    if (matrix[row + spaceRowCount, col] == " ")
                    {
                        matrix[row + spaceRowCount, col] = matrix[row, col];
                        matrix[row, col] = " ";
                    }
                }
            }
        }

        private static void EscapeMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = SecurityElement.Escape(matrix[row, col]);
                }
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            Console.Write("<table>");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.Write("<tr>");
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("<td>");
                    Console.Write(matrix[row, col]);
                    Console.Write("</td>");
                }

                Console.Write("</tr>");
            }

            Console.WriteLine("</table>");
        }
    }
}
