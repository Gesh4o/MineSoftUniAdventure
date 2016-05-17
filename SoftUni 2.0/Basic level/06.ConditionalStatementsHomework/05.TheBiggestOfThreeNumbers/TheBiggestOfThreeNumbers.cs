using System;

class 
    TheBiggestOfThreeNumbers
{
    static void Main()
    {
        Console.Write("Insert number a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Insert number b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Insert number c: ");
        double c = double.Parse(Console.ReadLine());

        double newNumber = Math.Max(a, b);
        Console.WriteLine("The biggest number is {0} .", Math.Max(c,newNumber));

    }
}