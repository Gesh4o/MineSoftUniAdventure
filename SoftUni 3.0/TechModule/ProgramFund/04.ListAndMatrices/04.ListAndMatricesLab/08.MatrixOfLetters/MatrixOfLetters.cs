namespace _08.MatrixOfLetters
{
    using System;

    public class MatrixOfLetters
    {
        public static void Main(string[] args)
        {
            int inputRow = int.Parse(Console.ReadLine());
            int inputCol = int.Parse(Console.ReadLine());

            char[,] matrix = new char[inputRow, inputCol];
            char startChar = 'A';
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(startChar + " ");
                    matrix[row, col] = startChar;
                    startChar++;
                }

                Console.WriteLine();
            }
        }
    }
}
