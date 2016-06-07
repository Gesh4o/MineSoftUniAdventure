namespace _21.NumberReversed
{
    using System;
    using System.Linq;

    public class NumberReversedMain
    {
        public static void Main(string[] args)
        {
            char[] array = Console.ReadLine().ToCharArray().Reverse().ToArray();
            Console.WriteLine(string.Join(string.Empty, array));
        }
    }
}
