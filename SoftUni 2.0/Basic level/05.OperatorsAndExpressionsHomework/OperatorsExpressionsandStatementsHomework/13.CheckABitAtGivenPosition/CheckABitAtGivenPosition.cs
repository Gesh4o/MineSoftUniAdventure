using System;

namespace _13.CheckABitAtGivenPosition
{
    class CheckABitAtGivenPosition
    {
        /* Write a Boolean expression 
        that returns if the bit at position p (counting from 0, starting from the right) 
        in given integer number n has value of 1.*/
        static void Main()
        {
            Console.WriteLine("Enter from what number you want to find a bit:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter at what index you want to find a bit:");
            int p = int.Parse(Console.ReadLine());
            bool checker = false;

            int bit = n >> p;
            bit = bit & 1;
            if (bit == 1) checker = true;

            Console.WriteLine(checker);
        }
    }
}
