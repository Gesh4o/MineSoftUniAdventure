namespace _02.RotateAndSum
{
    using System;
    using System.Linq;

    public class RotateAndSumMain
    {
        public static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int k = int.Parse(Console.ReadLine());

            RotateArray(array);
            int[] resultArray = new int[array.Length];
            for (int i = 1; i <= k; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    resultArray[j] += array[j];
                }

                RotateArray(array);
            }

            Console.WriteLine(string.Join(" ", resultArray));
        }

        private static void RotateArray(int[] array)
        {
            int oldValue = array[array.Length - 1];
            for (int i = array.Length - 1; i > 0; i--)
            {
                array[i] = array[i - 1];
            }

            array[0] = oldValue;
        }
    }
}
