namespace _06.TriplesLetters
{
    using System;

    public class TriplesOfLetters
    {
        private const char StartChar = 'a';

        private static readonly char[] Array = new char[3];

        private static char endChar;

        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            // endChar = (char)(n + StartChar - 1);
            // int startIndex = 0;
            // PrintAllVariationsRecursive(startIndex);
            PrintAllVariationsIterative(n);
        }

        private static void PrintAllVariationsRecursive(int index)
        {
            if (index >= Array.Length)
            {
                Console.WriteLine(string.Join(string.Empty, Array));
            }
            else
            {
                for (int currentChar = 'a'; currentChar <= endChar; currentChar++)
                {
                    Array[index] = (char)currentChar;
                    PrintAllVariationsRecursive(index + 1);
                }
            }
        }

        private static void PrintAllVariationsIterative(int n)
        {
            for (int i = 'a'; i < 'a' + n; i++)
            {
                for (int j = 'a'; j < 'a' + n; j++)
                {
                    for (int k = 'a'; k < 'a' + n; k++)
                    {
                        Console.WriteLine(((char)i).ToString() + (char)j + (char)k);
                    }
                }
            }
        }
    }
}
