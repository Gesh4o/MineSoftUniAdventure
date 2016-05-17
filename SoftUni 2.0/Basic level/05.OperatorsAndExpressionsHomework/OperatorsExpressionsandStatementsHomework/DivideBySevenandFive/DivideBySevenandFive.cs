using System;

namespace DivideBySevenandFive
{
    class DivideBySevenandFive
    {
        /* Write a Boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 in the same time.  */
        static void Main()
        {
            Console.WriteLine("Write an integer to check if it can be divided by 7 and 5:");
            int n = int.Parse(Console.ReadLine());
            bool dividable = false;
            if (((n % 5 == 0) && (n % 7 == 0)) && n != 0) // the boolean expression checks if both numbers have no remainder and makes sure 'n' isnt 0
            {
                dividable = true;
            }
            Console.WriteLine(dividable);
        }
    }
}
