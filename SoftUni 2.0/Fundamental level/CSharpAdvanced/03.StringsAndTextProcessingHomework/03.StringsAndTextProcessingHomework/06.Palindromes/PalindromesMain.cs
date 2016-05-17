namespace _06.Palindromes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class PalindromesMain
    {
        public static void Main()
        {
            Regex regex = new Regex("[a-zA-Z]+");
            MatchCollection matches = regex.Matches(Console.ReadLine());
            List<string> result = new List<string>();

            for (int i = 0; i < matches.Count; i++)
            {
                char[] currentMatchAsChars = matches[i].ToString().ToCharArray();
                bool isPalindrome = true;
                for (int j = 0; j < currentMatchAsChars.Length / 2; j++)
                {
                    if (currentMatchAsChars[j] != currentMatchAsChars[currentMatchAsChars.Length - 1 - j])
                    {
                        isPalindrome = false;
                    }
                }

                if (isPalindrome)
                {
                    result.Add(matches[i].ToString());
                }
            }

            result = result.Distinct().OrderBy(w => w).ToList();

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
