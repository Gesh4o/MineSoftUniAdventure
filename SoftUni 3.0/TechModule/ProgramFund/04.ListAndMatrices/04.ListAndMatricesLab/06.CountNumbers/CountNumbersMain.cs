namespace _06.CountNumbers
{
    using System;
    using System.Linq;

    public class CountNumbersMain
    {
        public static void Main(string[] args)
        {
            var sequence =
                Console.ReadLine()
                    .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .OrderBy(a => a)
                    .ToArray();

            foreach (int number in sequence.Distinct())
            {
                Console.WriteLine("{0} -> {1}", number, sequence.Count(num => num.Equals(number)));
            }
        }
    }
}
