using System;

class ExchangeIfGreater
{
    static void Main()
    {
        Console.Write("Plese insert number a: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Plese insert number b: ");
        double b = double.Parse(Console.ReadLine());

        double number;

        if (a>b)
        {
            number = a;
            a = b;
            b = number;
            Console.WriteLine("{0} {1}", a, b);
        }
        else
        {
            Console.WriteLine("{0} {1}", a, b);
        }

    }
}