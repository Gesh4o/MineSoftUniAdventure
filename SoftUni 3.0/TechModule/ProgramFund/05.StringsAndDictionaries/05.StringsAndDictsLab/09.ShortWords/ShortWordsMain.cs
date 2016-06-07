namespace _09.ShortWords
{
    using System;
    using System.Linq;

    public class ShortWordsMain
    {
        public static void Main(string[] args)
        {
            string[] shortWords =
                Console.ReadLine()
                    .ToLower()
                    .Split(new[] { ',', '.', ':', ';', '!', '?', ' ', '\'', '(', ')', '[', ']', '\"' }, StringSplitOptions.RemoveEmptyEntries)
                    .Where(w => w.Length < 5)
                    .OrderBy(word => word)
                    .Distinct()
                    .ToArray();

            Console.WriteLine(string.Join(", ", shortWords));
        }
    }
}
