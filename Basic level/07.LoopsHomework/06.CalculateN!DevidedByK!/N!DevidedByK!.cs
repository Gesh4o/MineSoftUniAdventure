using System;

class NDevidedByK
{
    static void Main()
    {
        Console.Write("Please insert integer N: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Please insert integer K: ");
        int k = int.Parse(Console.ReadLine());
        int result = 1;

        for (int index = k+1; index <= n; index++)
        {
            result *= index;
        }
        Console.WriteLine("N!/K!= " + result);
    }
}