namespace _02.ReverseString
{
    using System;
    using System.Linq;

    public class ReverseMain
    {
        public static void Main(string[] args)
        {
            string text = Console.ReadLine();

            text = string.Join(string.Empty, text.ToCharArray().Reverse());
            Console.WriteLine(text);
        }
    }
}
