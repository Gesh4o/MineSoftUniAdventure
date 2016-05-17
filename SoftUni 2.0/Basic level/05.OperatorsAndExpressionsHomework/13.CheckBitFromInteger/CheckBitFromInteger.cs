using System;

class CheckBitFromInteger
{
    static void Main()
    {
        Console.Write("Please insert an integer");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Please insert a poisition: ");
        int p = int.Parse(Console.ReadLine());
        int mask = n >> p;
        int result = 1 & mask;
        bool check = 1 == result;
        Console.WriteLine("Your digit at given position is 1: {0} ", check ? true : false);
    }
}