using System;

class ExtractBit3
{
    static void Main()
    {
        Console.Write("Please insert an integer- ");
        uint n = uint.Parse(Console.ReadLine());
        uint mask = n>>3;
        uint result = 1 & mask;
        Console.WriteLine("The third bit is: " + result);
    }
}