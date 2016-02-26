namespace _01.SeriesOfLetters
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class SeriesOfLettersMain
    {
        public static void Main()
        {
            Regex regex = new Regex("[a-zA-Z]");
            string input = Console.ReadLine();

            var matches = regex.Matches(input).OfType<Match>().Select(m => m.Value).Distinct();

            foreach (var match in matches)
            {
                Console.Write(match);
            }
            Console.WriteLine();
        }
    }
}
