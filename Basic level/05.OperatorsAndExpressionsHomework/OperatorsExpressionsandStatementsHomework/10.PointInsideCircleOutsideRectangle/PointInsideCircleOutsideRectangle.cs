using System;

namespace _10.PointInsideCircleOutsideRectangle
{
    class PointInsideCircleOutsideRectangle
    {
        /* Write an expression that checks for
        given point (x, y) if it is within the circle K({1, 1}, 1.5) 
        and out of the rectangle R(top=1, left=-1, width=6, height=2).*/
        static void Main()
        {
            Console.WriteLine("Enter x:");
            double x = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter y:");
            double y = double.Parse(Console.ReadLine());

            double distance = Math.Sqrt(((x - 1) * (x - 1)) + ((y - 1) * (y - 1)));
            if (distance <= 1.5 && y > 1)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
