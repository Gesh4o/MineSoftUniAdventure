using System;

class ExtractBitFromInteger
{
    static void Main()
    {
        Console.Write("Please insert an integer: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Please insert a poisition: ");
        int p = int.Parse(Console.ReadLine());
        int mask = n >> p;
        int result = 1 & mask;
        Console.WriteLine("Your digit at given position is: {0} " ,result);
    }
}