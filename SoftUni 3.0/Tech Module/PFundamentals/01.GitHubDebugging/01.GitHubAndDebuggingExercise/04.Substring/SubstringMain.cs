namespace _04.Substring
{
    using System;

    public class SubstringMain
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            int stepCount = int.Parse(Console.ReadLine());

            const char Search = 'p';
            bool hasMatch = false;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == Search)
                {
                    hasMatch = true;

                    int endIndex = Math.Min(i + stepCount, text.Length - 1);

                    string matchedString = text.Substring(i, endIndex - i + 1);
                    Console.WriteLine(matchedString);
                    i += stepCount;
                }
            }

            if (!hasMatch)
            {
                Console.WriteLine("no");
            }
        }
    }
}
