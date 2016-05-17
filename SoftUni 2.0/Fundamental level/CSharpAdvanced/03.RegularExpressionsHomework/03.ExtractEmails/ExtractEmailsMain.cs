namespace _03.ExtractEmails
{
    using System;
    using System.Text.RegularExpressions;

    public class ExtractEmailsMain
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = "[a-z0-9._-]+@[a-z.-]+[a-z]{2,}";
            Regex regex = new Regex(pattern);               

            var matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.ToString());
            }
        }
    }
}
