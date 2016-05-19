namespace _19.Max
{
    using System;

    public class MaxMain
    {
        public static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());

            Console.WriteLine(Math.Max(a, Math.Max(b, c)));
        }
    }
}