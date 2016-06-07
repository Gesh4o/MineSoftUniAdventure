namespace _04.ExtractSentences
{
    using System;
    using System.Text.RegularExpressions;

    public class ExtractMain
    {
        public static void Main(string[] args)
        {
            string word = Console.ReadLine();
            Regex regex = new Regex("[A-Za-z\\s]+\\b" + word + "\\b[A-Za-z\\s0-9]+\\.");
            MatchCollection matchCollection = regex.Matches(Console.ReadLine());
            foreach (Match match in matchCollection)
            {
                Console.WriteLine(match.ToString().Trim());
            }
        }
    }
}
