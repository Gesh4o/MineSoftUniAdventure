namespace _15.UppercaseWords
{
    using System;
    using System.Linq;
    using System.Security;
    using System.Text;
    using System.Text.RegularExpressions;

    public class UppercaseWordsMain
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            while (input != "END")
            {
                input = SecurityElement.Escape(input);

                Regex regex = new Regex("(?<![a-zA-Z])([A-Z]+)(?![a-zA-Z])");

                MatchEvaluator matchEvaluator = ReplaceUppercaseWords;

                MatchCollection match = regex.Matches(input);

                string output = regex.Replace(input, matchEvaluator);
                Console.WriteLine(output);

                input = Console.ReadLine();
            }
        }

        private static string ReplaceUppercaseWords(Match match)
        {
            string matchString = match.Groups[1].ToString();

            bool isPalindrome = CheckIsPalindrome(matchString);

            if (isPalindrome)
            {
                matchString = PerformPalindromeAction(matchString);
            }
            else
            {
                matchString = string.Join(string.Empty, matchString.ToCharArray().Reverse());
            }
            return matchString;
        }

        private static string PerformPalindromeAction(string matchString)
        {
            StringBuilder result = new StringBuilder();
            foreach (char @char in matchString)
            {
                result.Append(new string(@char, 2));
            }

            matchString = result.ToString();

            return matchString;
        }

        private static bool CheckIsPalindrome(string matchString)
        {
            bool isPalindrome = true;
            for (int index = 0; index < matchString.Length / 2; index++)
            {
                if (matchString[index] != matchString[matchString.Length - 1 - index])
                {
                    isPalindrome = false;
                }
            }

            return isPalindrome;
        }
    }
}
