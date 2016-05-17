using System;

namespace Rectangles
{
    class Rectangles
    {
        static void Main()
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            Console.WriteLine("Perimeter is {0}.", width * 2 + height * 2);
            Console.WriteLine("Area is {0}.", width * height);
        }
    }
}
