namespace _04.SplitByWordsCasing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SplitByWordsCasingMain
    {
        public static void Main(string[] args)
        {
            string[] inputArgs =
                Console.ReadLine().Split(new[] { ',', ':', '.', ';', '!', '(', ')', '!', '\'', '\\', '\"', ']', '[', ' ', '/' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> lowerCaseWords = new List<string>();
            List<string> mixedCaseWords = new List<string>();
            List<string> upperCaseWords = new List<string>();

            foreach (string word in inputArgs)
            {
                bool areAllLowercase = word.All(char.IsLower);
                bool areAllUppercase = word.All(char.IsUpper);
                if (areAllLowercase)
                {
                    lowerCaseWords.Add(word);
                }
                else if (areAllUppercase)
                {
                    upperCaseWords.Add(word);
                }
                else
                {
                    mixedCaseWords.Add(word);
                }
            }

            Console.WriteLine("Lower-case: {0}", string.Join(", ", lowerCaseWords));
            Console.WriteLine("Mixed-case: {0}", string.Join(", ", mixedCaseWords));
            Console.WriteLine("Upper-case: {0}", string.Join(", ", upperCaseWords));
        }
    }
}
