namespace _06.ReverseWords
{
    using System;
    using System.Linq;

    public class ReverseWordsMain
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] allWords = input.Split(new[] { ' ', '.', ',', '!', ':', ';', '?', '(', ')', '[', ']', '\\', '/', '\"', '\'', '&' }, StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray();
            char[] allWordChars = string.Join(string.Empty, allWords).ToCharArray();
            string[] allSeperators = input.Split(allWordChars, StringSplitOptions.RemoveEmptyEntries);

            for (int index = 0; index < allWords.Length; index++)
            {
                Console.Write(allWords[index]);
                Console.Write(allSeperators[index]);
            }

            Console.WriteLine();
        }
    }
}
