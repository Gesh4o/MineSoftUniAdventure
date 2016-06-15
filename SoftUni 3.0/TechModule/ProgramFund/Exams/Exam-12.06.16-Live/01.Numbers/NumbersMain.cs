namespace _01.Numbers
{
    using System;
    using System.Linq;

    public class NumbersMain
    {
        public static void Main(string[] args)
        {
            int[] sequence =
                Console.ReadLine()
                    .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            int[] array = sequence.Where(n => n > sequence.Average()).OrderByDescending(n => n).Take(5).ToArray();

            if (array.Length == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine(string.Join(" ", array));
            }
        }
    }
}
