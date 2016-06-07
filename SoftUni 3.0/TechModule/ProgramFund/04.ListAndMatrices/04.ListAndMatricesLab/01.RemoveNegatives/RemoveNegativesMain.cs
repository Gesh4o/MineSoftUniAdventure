namespace _01.RemoveNegatives
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RemoveNegativesMain
    {
        public static void Main(string[] args)
        {
            List<int> sequence =
                Console.ReadLine()
                    .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .Where(num => num >= 0)
                    .Reverse()
                    .ToList();

            if (sequence.Count != 0)
            {
                Console.WriteLine(string.Join(" ", sequence));
            }
            else
            {
                Console.WriteLine("empty");
            }
        }
    }
}
