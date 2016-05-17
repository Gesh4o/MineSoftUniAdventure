using System;

namespace _09.Trapezoids
{
    class Trapezoids
    {
        /* Write an expression that calculates trapezoid's area by given sides a and b and height h. */
        static void Main()
        {
            Console.WriteLine("Enter the side a:");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the side b:");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the height h:");
            double h = double.Parse(Console.ReadLine());

            Console.WriteLine("The area of the trapezoid is: {0}", ((a + b) / 2) * h);
        }
    }
}
