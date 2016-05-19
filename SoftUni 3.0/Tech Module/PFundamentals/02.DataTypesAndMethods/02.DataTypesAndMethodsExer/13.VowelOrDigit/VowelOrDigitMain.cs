namespace _14.VowelOrDigit
{
    using System;

    public class VowelOrDigitMain
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLowerInvariant();
            char @char = input[0];
            if (char.IsDigit(@char))
            {
                Console.WriteLine("digit");
            }
            else if (@char == 'a' || @char == 'e' || @char == 'i' || @char == 'o' || @char == 'u' || @char == 'y' || @char == 'а' || @char == 'e' || @char == 'о' || @char == 'и')
            {
                Console.WriteLine("vowel");
            }
            else
            {
                Console.WriteLine("It's another symbol");
            }
        }
    }
}
