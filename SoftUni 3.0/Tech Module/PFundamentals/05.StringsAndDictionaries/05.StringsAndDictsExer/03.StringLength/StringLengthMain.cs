namespace _03.StringLength
{
    using System;
    using System.Linq;

    public class StringLengthMain
    {
        public static void Main(string[] args)
        {
            string text = Console.ReadLine().PadRight(20, '*');

            Console.WriteLine(string.Join(string.Empty, text.ToCharArray().Take(20)));
        }
    }
}
