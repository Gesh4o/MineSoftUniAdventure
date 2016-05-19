namespace _08.ExtractMiddle
{
    using System;
    using System.Linq;

    public class ExtractMiddleMain
    {
        public static void Main(string[] args)
        {

            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            if (array.Length == 1)
            {
                Console.Write("{ ");
                Console.Write($"{array[0]}");
                Console.WriteLine(" }");
            }
            else if (array.Length % 2 == 0)
            {
                Console.Write("{ ");
                Console.Write($"{array[(array.Length / 2  - 1)]}, {array[(array.Length / 2)]}");
                Console.WriteLine(" }");
            }
            else
            {
                Console.Write("{ ");
                Console.Write($"{array[(array.Length / 2) - 1]}, {array[(array.Length / 2)]}, {array[(array.Length / 2) + 1]}");
                Console.WriteLine(" }");
            }
        }
    }
}
