using System;

namespace _07.PointInACircle
{
   /* Write an expression that checks if given point (x,  y) is inside a circle K({0, 0}, 2) */
    class PointInACircle
    {
        static void Main()
        {
            Console.WriteLine("Enter \'x\':");
            double x = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter \'y\':");
            double y = double.Parse(Console.ReadLine());

            Console.WriteLine(x * x + y * y <= 2 * 2);
        }
    }
}
