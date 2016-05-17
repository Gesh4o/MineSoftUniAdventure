namespace _05.UnicodeCharacters
{
    using System;
    using System.Text;

    public class UnicodeCharactersMain
    {
        public static void Main()
        {
            char[] input = Console.ReadLine().ToCharArray();

            StringBuilder result = new StringBuilder();

            foreach (char c in input)
            {
                result.AppendFormat("\\u{0:x4}", (int)c);
            }

            Console.WriteLine(result.ToString());
        }
    }
}
