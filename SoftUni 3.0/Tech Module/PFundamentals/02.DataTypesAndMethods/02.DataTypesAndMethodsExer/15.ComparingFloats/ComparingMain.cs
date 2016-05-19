namespace _15.ComparingFloats
{
    using System;

    public class ComparingMain
    {
        public static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            if (Math.Abs(a - b) > 0.000001)
            {
                Console.WriteLine("False");
            }
            else
            {
                Console.WriteLine("True");
            }
        }
    }
}
