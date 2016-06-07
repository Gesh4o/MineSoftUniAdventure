namespace _07.ToUpper
{
    using System;
    using System.Text.RegularExpressions;

    public class ToUpperMain
    {
        public static void Main(string[] args)
        {
            Regex regex = new Regex("<upcase>(.*?)<\\/upcase>");
            string input = Console.ReadLine();
            MatchCollection matchCollection = regex.Matches(input);

            foreach (Match match in matchCollection)
            {
                input = input.Replace(match.Groups[0].ToString(), match.Groups[1].ToString().ToUpper());
            }

            Console.WriteLine(input);
        }
    }
}
