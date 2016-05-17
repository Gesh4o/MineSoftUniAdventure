namespace ReplaceTag
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;

    // I have tried multiple regexes :
    // (<a)(.+)\.[a-z]{2,}(>)?(.*)(<\/a>)
    // (<a)(.+)\.bg(>)?(.*)(<\/a>)
    // (<a|<\\/a>|\.bg>)
    // (<a|<\/a>|(?<=\.[\w+]{2})(>))
    // But still couldnt replace the closing diamond parenthesis...
    public class ReplaceTagMain
    {
        public static void Main(string[] args)
        {
            Regex regex = new Regex("(<a)(.*)(<\\/a>)");

            string input;

            using (StreamReader streamReader = new StreamReader("text.txt"))
            {
                input = streamReader.ReadToEnd();
            }

            input = input.Replace("\"", string.Empty);

            var matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                input = input.Replace(match.Groups[1].Value, "[URL");
                input = input.Replace(match.Groups[3].Value, "[\\URL]");
            }

            Regex secondRegex = new Regex("(?<=\\.[\\w]{2})(>)");

            var secondMatches = secondRegex.Matches(input);

            foreach (Match match in secondMatches)
            {
                input = input.Replace(match.Groups[1].Value, "]");
            }

            // Still replaces all '>'. :(
            Console.WriteLine(input);
        }
    }
}
