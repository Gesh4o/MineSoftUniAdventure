using System;

class CalculateGSD
{
    static void Main()
    {
        Console.Write("Insert number a: ");
        int a = int.Parse(Console.ReadLine());


        Console.Write("Insert number b: ");
        int b = int.Parse(Console.ReadLine());

        while (a!=0)
        {
            int temp = a;
            a = b % a;
            b = temp;
        }
        Console.WriteLine("The GSD between a and b is: " +b);
    }
}