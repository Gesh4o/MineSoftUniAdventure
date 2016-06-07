namespace _05.SortNumbers
{
    using System;
    using System.Linq;

    public class SortNumbersMain
    {
        public static void Main(string[] args)
        {
            var sequence =
                Console.ReadLine()
                    .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .OrderBy(a => a)
                    .ToArray();

            Console.WriteLine(string.Join(" ", sequence));
        }
    }
}
