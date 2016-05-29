
namespace _05.UrlParser
{
    using System;
    using System.Text.RegularExpressions;

    public class UrlParserMain
    {
        public static void Main(string[] args)
        {
            Regex regex = new Regex("([a-z]+):\\/\\/([a-z\\.\\-]+)\\/([A-Z\\/a-z]+)");
            Match match = regex.Match(Console.ReadLine());

            Console.WriteLine($"[protocol]=\"{match.Groups[1]}\"");
            Console.WriteLine($"[server]=\"{match.Groups[2]}\"");
            Console.WriteLine($"[resource]=\"{match.Groups[3]}\"");
        }
    }
}
