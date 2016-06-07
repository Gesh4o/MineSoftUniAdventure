namespace _04.CountOccurrences
{
    using System;

    public class CountMain
    {
        public static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();
            string word = Console.ReadLine().ToLower();
            int count = 0, offset = -1;
            while (true)
            {
                offset = text.IndexOf(word, offset + 1, StringComparison.Ordinal);
                if (offset == -1)
                {
                    break; // No more occurrences
                }
                count++;
            }

            Console.WriteLine($"{count}");
        }
    }
}
