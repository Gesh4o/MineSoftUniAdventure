using System;

namespace _15.BitsExchange
{
    class BitsExchange
    {
        /* Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.  
           |          n |          binary representation of n |                       binary result |     result |
           | 1140867093 | 01000100 00000000 01000000 00010101 | 01000010 00000000 01000000 00100101 | 1107312677 | */
        static void Main()
        {
            Console.WriteLine("Enter an unsigned integer that you want to exchange the bits of:");
            uint n = uint.Parse(Console.ReadLine());
            uint thirdBit = n >> 3;
            uint fourthBit = n >> 4;
            uint fifthBit = n >> 5;
            uint bit24 = n >> 24;
            uint bit25 = n >> 25;
            uint bit26 = n >> 26;
            
            // assigns values to the bits
            thirdBit = thirdBit & 1;
            fourthBit = fourthBit & 1;
            fifthBit = fifthBit & 1;
            bit24 = bit24 & 1;
            bit25 = bit25 & 1;
            bit26 = bit26 & 1;

            // exchanges the bits using the method I built
            n = Exchanger(bit24, 3, n);           
            n = Exchanger(bit25, 4, n);
            n = Exchanger(bit26, 5, n);
            n = Exchanger(thirdBit, 24, n);
            n = Exchanger(fourthBit, 25, n);
            n = Exchanger(fifthBit, 26, n);

            Console.WriteLine(n);
            
            
        }
        public static uint Exchanger(uint v, int pos, uint n) // v is for the bit, pos is the position and n is the number where you put it
        {
            // puts the bit in position 'pos'
            int bit = 1 << pos;

            if (v == 1)
            {
                n = (uint)bit | n;
            }
            else if (v == 0)
            {
                bit = ~bit;
                n = (uint)bit & n;
            }
            return n;
            
        }
    }
}
