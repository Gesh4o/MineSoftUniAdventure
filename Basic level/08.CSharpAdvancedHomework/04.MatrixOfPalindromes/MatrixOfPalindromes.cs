using System;

class MatrixOfPalindromes
{
    static void Main()
    {
        Console.Write("Please insert rows r= ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("Please unsert collums c= ");
        int cols = int.Parse(Console.ReadLine());

        char a = 'a';
        char b = 'b';
        char c = 'c';

        string[,] matrix = new string[rows,cols];
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (row == 0)
                {
                    matrix[row, col] = (Convert.ToString(a)+ Convert.ToChar(a+col)+ a);
                }
                if (row == 1)
                {
                    matrix[row, col] = (Convert.ToString(b) + Convert.ToChar(b + col) + b);
                }
                if (row == 2)
                {
                    matrix[row, col] = (Convert.ToString(c) + Convert.ToChar(c + col) + c);
                }
            }
        }

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write(matrix[row,col] + "  ");
            }
            Console.WriteLine();
        }
    }
}