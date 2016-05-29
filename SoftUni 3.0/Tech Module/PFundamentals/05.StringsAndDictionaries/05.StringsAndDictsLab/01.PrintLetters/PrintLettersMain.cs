namespace _01.PrintLetters
{
    using System;

    public class PrintLettersMain
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            for (int index = 0; index < input.Length; index++)
            {
                Console.WriteLine("str[{0}] -> \'{1}\'", index, input[index]);
            }
        }
    }
}