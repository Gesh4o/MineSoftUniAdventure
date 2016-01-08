using System;

class Trapezoids
{
    static void Main()
    {
        Console.Write("Please insert side a: ");
        double aSide = double.Parse(Console.ReadLine());
        Console.Write("Please insert side b: ");
        double bSide = double.Parse(Console.ReadLine());
        Console.Write("Please insert side h: ");
        double hSide = double.Parse(Console.ReadLine());
        double area = (aSide + bSide) * hSide / 2;
        Console.WriteLine("The trapezoid's area is {0}",area);

    }
}