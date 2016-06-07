namespace _11.SumReversed
{
    using System;
    using System.Linq;

    public class SumMain
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Console.ReadLine().Split(' ').Select(s => s.ToCharArray().Reverse()).Select(s => long.Parse(string.Join(string.Empty, s))).Sum());
        }
    }
}
