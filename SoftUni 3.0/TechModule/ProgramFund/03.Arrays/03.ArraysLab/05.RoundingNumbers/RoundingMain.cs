namespace _05.RoundingNumbers
{
    using System;
    using System.Linq;

    public class RoundingMain
    {
        public static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            foreach (var number in numbers)
            {
                Console.WriteLine("{0} => {1}", number, (int)Math.Round(number, MidpointRounding.AwayFromZero));
            }
        }
    }
}
