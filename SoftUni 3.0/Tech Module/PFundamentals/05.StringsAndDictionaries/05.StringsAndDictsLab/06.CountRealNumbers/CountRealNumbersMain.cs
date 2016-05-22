namespace _06.CountRealNumbers
{
    using System;
    using System.Linq;

    public class CountRealNumbersMain
    {
        public static void Main(string[] args)
        {
            double[] sequence = Console.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            var group = sequence.GroupBy(num => num).OrderBy(g => g.Key).ToArray();

            foreach (IGrouping<double, double> grouping in group)
            {
                Console.WriteLine("{0} -> {1}", grouping.Key, grouping.Count());
            }
        }
    }
}
