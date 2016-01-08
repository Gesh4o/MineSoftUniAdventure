using System;

class MultiplationSign
{
    static void Main()
    {
        Console.Write("Insert number a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Insert number b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Insert number c: ");
        double c = double.Parse(Console.ReadLine());

        if (a>0 && b>0 && c>0)
        {
            Console.WriteLine("+");
        }
        else if (a > 0 && b < 0 && c < 0)
        {
            Console.WriteLine("+");
        }
        else if (a < 0 && b < 0 && c > 0)
        {
            Console.WriteLine("+");
        }
        else if (a < 0 && b > 0 && c < 0)
        {
            Console.WriteLine("+");
        }
        else if (a==0||b==0||c==0)
        {
            Console.WriteLine("0");
        }

        else
        {
            Console.WriteLine("-");
        }
    }
}