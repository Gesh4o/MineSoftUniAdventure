namespace _04.TextFilter
{
    using System;

    public class TextFilter

    {
        public static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            string inputText = Console.ReadLine();

            for (int i = 0; i < bannedWords.Length; i++)
            {
                inputText = inputText.Replace(bannedWords[i], new string('*', bannedWords[i].Length));
            }

            Console.WriteLine(inputText);
        }
    }
}
