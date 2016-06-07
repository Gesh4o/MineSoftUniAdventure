namespace _08.Palindromes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class PalindromesMain
    {
        public static void Main(string[] args)
        {
            Regex regex = new Regex("[a-zA-Z]+");
            MatchCollection matchCollection = regex.Matches(Console.ReadLine());

            SortedSet<string> set = new SortedSet<string>();
            foreach (Match match in matchCollection.Cast<Match>().Where(match => IsPalindrome(match.ToString())))
            {
                set.Add(match.ToString());
            }

            Console.WriteLine(string.Join(", ", set));
        }

        private static bool IsPalindrome(string word)
        {
            for (int i = 0; i < word.Length / 2; i++)
            {
                if (word[i] != word[word.Length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
