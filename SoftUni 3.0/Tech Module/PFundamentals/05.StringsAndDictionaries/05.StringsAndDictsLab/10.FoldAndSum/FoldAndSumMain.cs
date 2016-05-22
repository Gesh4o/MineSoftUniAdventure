namespace _10.FoldAndSum
{
    using System;
    using System.Linq;

    public class FoldAndSumMain
    {
        public static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int k = array.Length / 4;

            int[] leftPart = array.Take(k).Reverse().ToArray();
            int[] middlePart = array.Skip(k).Take(2 * k).ToArray();
            int[] rightPart = array.Reverse().Take(k).ToArray();

            for (int i = 0; i < leftPart.Length; i++)
            {
                middlePart[i] += leftPart[i];
            }

            for (int i = 0; i < rightPart.Length; i++)
            {
                middlePart[k + i] += rightPart[i];
            }

            Console.WriteLine(string.Join(" ", middlePart));
        }
    }
}