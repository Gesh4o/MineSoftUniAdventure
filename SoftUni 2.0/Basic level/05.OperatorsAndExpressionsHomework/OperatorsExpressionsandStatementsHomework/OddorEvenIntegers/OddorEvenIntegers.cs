using System;

namespace OddorEvenIntegers
{
    class OddorEvenIntegers
    {
        /* Write an expression that checks if given integer is odd or even. */
        static void Main()
        {
            Console.WriteLine("Please write an integer to see if it's odd or even: ");
            int givenInteger = int.Parse(Console.ReadLine());
            bool isOdd = false;

            if (givenInteger % 2 != 0)
            {
                isOdd = true;
                Console.WriteLine(isOdd);
            }
            else
            {
                isOdd = false;
                Console.WriteLine(isOdd);
            }
           
           
        }
    }
}
