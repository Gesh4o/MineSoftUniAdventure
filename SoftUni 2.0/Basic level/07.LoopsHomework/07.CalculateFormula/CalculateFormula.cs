using System;
using System.Numerics;

class CalculateFormula
{
    static void Main()
    {
        Console.Write("Please insert integer N: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Please insert integer K: ");
        int k = int.Parse(Console.ReadLine());

        BigInteger firstOperation = 1;
        BigInteger secondOperation = 1;

        for (int i = k+1; i <= n; i++)
        {
            firstOperation *= i;
        }

        for (int i = n-k; i > 0; i--)
        {
            secondOperation *= i;
        }

        Console.Write("The result from N!/(K!(N-K)!)= {0} !", firstOperation/secondOperation);
        Console.WriteLine();
    }
}