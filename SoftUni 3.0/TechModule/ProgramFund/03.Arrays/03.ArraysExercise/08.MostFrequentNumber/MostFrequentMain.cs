namespace _08.MostFrequentNumber
{
    using System;
    using System.Linq;

    public class MostFrequentMain
    {
        public static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine()
                   .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();

            var grouping = sequence.GroupBy(num => num).OrderByDescending(n => n.Count()).ToArray();
            Console.WriteLine(grouping.First().Key);
        }
    }
}
