using System;

namespace _12.ExtractBitFromInteger
{
    class ExtractBitFromInteger
    {
        // Write an expression that extracts from given integer n the value of given bit at index p. 
        static void Main()
        {
            Console.WriteLine("Enter from what number you want to find a bit:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter at what index you want to find a bit:");
            int p = int.Parse(Console.ReadLine());

            int bit = n >> p;
            bit = bit & 1;
            Console.WriteLine("The bit you're looking for is: {0}", bit);
        }
    }
}
