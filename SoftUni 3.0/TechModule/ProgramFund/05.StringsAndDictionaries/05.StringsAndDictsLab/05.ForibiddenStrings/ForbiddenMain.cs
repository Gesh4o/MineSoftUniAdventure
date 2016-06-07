namespace _05.ForbiddenStrings
{
    using System;
    using System.Linq;

    public class ForbiddenMain
    {
        public static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string[] words = Console.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            text = words.Aggregate(text, (current, word) => current.Replace(word, new string('*', word.Length)));

            Console.WriteLine(text);

        }
    }
}
