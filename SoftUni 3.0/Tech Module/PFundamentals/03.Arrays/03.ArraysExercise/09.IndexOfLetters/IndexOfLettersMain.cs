namespace _09.IndexOfLetters
{
    using System;

    public class IndexOfLettersMain
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            foreach (char letter in input)
            {
                if (char.IsLetter(letter))
                {
                    char smallLetter = letter.ToString().ToLower()[0];
                    Console.WriteLine($"{letter} -> {(smallLetter - 97)}");
                }
            }
        }
    }
}
