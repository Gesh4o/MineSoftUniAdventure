namespace _05.ValidUsernames
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class ValidUsernamesMain
    {
        public static void Main()
        {
            string[] usernames = Console.ReadLine()
                .Split(new[] { ' ', '(', ')', '\\', '/' }, StringSplitOptions.RemoveEmptyEntries);

            Regex regex = new Regex("(^[a-zA-Z][\\w]{2,25}$)");

            List<string> validUsernames = new List<string>();

            for (int index = 0; index < usernames.Length; index++)
            {
                bool isMatch = regex.IsMatch(usernames[index]);
                if (isMatch)
                {
                    validUsernames.Add(usernames[index]);
                }
            }

            var startIndex = GetFirstIndexOfTheLongestUsernames(validUsernames);

            Console.WriteLine(validUsernames[startIndex]);
            Console.WriteLine(validUsernames[startIndex + 1]);
        }

        private static int GetFirstIndexOfTheLongestUsernames(List<string> validUsernames)
        {
            int maxLength = 0;
            int startIndex = 0;
            for (int index = 0; index < validUsernames.Count - 1; index++)
            {
                int currentLength = validUsernames[index].Length + validUsernames[index + 1].Length;
                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    startIndex = index;
                }
            }

            return startIndex;
        }
    }
}
