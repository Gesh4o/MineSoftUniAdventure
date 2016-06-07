namespace _06.ReverseArray
{
    using System;
    using System.Linq;

    public class ReverseArrayMain
    {
        public static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Console.WriteLine(string.Join(" ", numbers.Reverse()));
        }
    }
}
