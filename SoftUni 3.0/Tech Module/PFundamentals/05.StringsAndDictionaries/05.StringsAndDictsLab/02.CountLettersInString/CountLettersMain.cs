namespace _02.CountLettersInString
{
    using System;
    using System.Linq;

    public class CountLettersMain
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var info = input.ToLower().GroupBy(i => i).OrderBy(c => c.Key).ToArray();
            foreach (IGrouping<char, char> grouping in info)
            {
                Console.WriteLine("{0} -> {1}", grouping.Key, grouping.Count());
            }
        }
    }
}
