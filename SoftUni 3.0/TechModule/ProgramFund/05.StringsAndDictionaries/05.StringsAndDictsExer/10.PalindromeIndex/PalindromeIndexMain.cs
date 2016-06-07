namespace _10.PalindromeIndex
{
    using System;

    public class PalindromeIndexMain
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (IsPalindrome(input))
            {
                Console.WriteLine(-1);
            }
            else
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (IsPalindrome(input.Remove(i, 1)))
                    {
                        Console.WriteLine(i);
                        break;
                    }
                }
            }
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
