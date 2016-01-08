using System;

class CalculateSequence
{
    static void Main()
    {
        Console.Write("Please insert integer n: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Please insert integer x: ");
        int x = int.Parse(Console.ReadLine());
        int nFactorial = 1;
        int poweredX = 1;
        double sum = 1;

        Console.Write("Тhe sum of: 1 ");
        for (int i = 1; i <= n; i++)
        {
            nFactorial *= i;
            poweredX *= x;
            Console.Write(" + {0}/{1}", nFactorial, poweredX);
            sum += (double)nFactorial / (double)poweredX;
        }
        Console.Write(" = {0:F5}",sum);
        Console.WriteLine();
        
    }
}