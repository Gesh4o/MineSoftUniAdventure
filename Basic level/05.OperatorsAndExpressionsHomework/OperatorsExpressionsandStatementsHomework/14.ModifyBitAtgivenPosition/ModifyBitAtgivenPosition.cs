using System;

namespace _14.ModifyBitAtgivenPosition
{
    class ModifyBitAtgivenPosition
    {
    /* We are given an integer number n, a bit value v (v=0 or 1) and a position p. 
    Write a sequence of operators (a few lines of C# code) 
    that modifies n to hold the value v at the position p from the 
    binary representation of n while preserving all other bits in n.*/
        static void Main()
        {
            Console.WriteLine("Enter an integer number:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the position of the bit you want to change:");
            int p = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter what you want to change the bit to (0 or 1):");
            int v = int.Parse(Console.ReadLine());

            int bit = 1 << p;
            
            if (v == 1)
            {
                n = bit | n;
            }
            else if (v == 0)
            {
                bit = ~bit;
                n = bit & n;
            }
            else { Console.WriteLine("Input cannot be different than 0 or 1."); }
            Console.WriteLine(n);
        }
    }
}
