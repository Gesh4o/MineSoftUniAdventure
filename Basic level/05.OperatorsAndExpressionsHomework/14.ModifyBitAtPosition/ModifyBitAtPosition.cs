using System;

class ModifyBitAtPosition
{
    static void Main()
    {
        Console.Write("Please insert an integer: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Please insert a position: ");
        int p = int.Parse(Console.ReadLine());
        Console.Write("Please insert a digit (0 or 1): ");
        int v = int.Parse(Console.ReadLine());
        int mask = v << p;
        n = n & (~(1 << p));
        int result = n | mask;
        Console.WriteLine("The answer is: {0}",result);
    }
}
