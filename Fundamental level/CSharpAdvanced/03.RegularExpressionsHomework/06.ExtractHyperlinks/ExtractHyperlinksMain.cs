namespace _06.ExtractHyperlinks
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class ExtractHyperlinksMain
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder wholeText = new StringBuilder();

            while (input != "END")
            {
                wholeText.AppendLine(input);
                input = Console.ReadLine();
            }

            Regex regex = new Regex("<a([.*?\n]+)*(.*?)(href)([\\s])*=([\\s])*(\"(.*?)\")*(\'(.*?)\')*");

            var result = regex.Matches(wholeText.ToString());
            foreach (Match match in result)
            {
                Console.WriteLine(match.Groups[7].ToString().Trim());
            }
        }
    }
}
