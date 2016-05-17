namespace _04.SentenceExtractor
{
    using System;
    using System.Text.RegularExpressions;

    public class SentenceExtractorMain
    {
        public static void Main(string[] args)
        {
            string wordInText = Console.ReadLine();
            string text = Console.ReadLine();

            Regex regex = new Regex("[^ ][a-zA-z ]+ " + wordInText + " [a-zA-Z ]+[!.?$]");

            var matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.ToString());
            }
        }
    }
}
