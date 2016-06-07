namespace _08.LargestThreeNumbers
{
    using System;
    using System.Linq;

    public class LargestMain
    {
        public static void Main(string[] args)
        {
            double[] sequence =
                Console.ReadLine()
                    .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .OrderByDescending(num => num)
                    .ToArray();

            Console.WriteLine(string.Join(" ", sequence.Take(3)));
        }
    }
}
