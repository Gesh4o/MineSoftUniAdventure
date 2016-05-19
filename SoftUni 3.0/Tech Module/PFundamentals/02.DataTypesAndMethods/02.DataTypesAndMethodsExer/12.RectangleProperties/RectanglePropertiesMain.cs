namespace _12.RectangleProperties
{
    using System;

    public class RectanglePropertiesMain
    {
        public static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            Console.WriteLine((height + width) * 2);
            Console.WriteLine(height * width);
            Console.WriteLine(Math.Sqrt((height * height) + (width * width)));
        }
    }
}
