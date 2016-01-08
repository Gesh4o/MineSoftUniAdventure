using System;

namespace _11.BitwiseExtractBit
{
    class BitwiseExtractBit
    {
        /* Using bitwise operators, write an expression for finding the value of the bit #3 of a given unsigned integer. 
        The bits are counted from right to left, starting from bit #0. The result of the expression should be either 1 or 0 */
        static void Main()
        {
            uint n = uint.Parse(Console.ReadLine());

            uint bit = n >> 3;
            bit = bit & 1;
            Console.WriteLine(bit);
        }
    }
}
