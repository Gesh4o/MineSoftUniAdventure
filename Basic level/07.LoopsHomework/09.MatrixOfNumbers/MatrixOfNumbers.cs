using System;

class MatrixOfNumbers
{
    static void Main()
    {
        Console.Write("Please insert number N: ");
        int n = int.Parse(Console.ReadLine());

        for (int rows = 0; rows < n; rows++)
        {
            for (int cols = rows; cols < n + rows; cols++)
            {
                Console.Write("{0,3 }",cols +1);
            }
            Console.WriteLine();
        }
    }
}