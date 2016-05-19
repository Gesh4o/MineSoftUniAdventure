namespace _04.TripleSum
{
    using System;
    using System.Linq;

    public class TripleSumMain
    {
        public static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            bool isAny = false;
            for (int i = 0; i < numbers.Length; i++)
            {
                int a = numbers[i];
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (i != j)
                    {
                        int b = numbers[j];
                        int sum = a + b;
                        if (numbers.Contains(sum))
                        {
                            Console.WriteLine($"{a} + {b} == {sum}");
                            isAny = true;
                        }
                    }
                }
            }

            if (!isAny)
            {
                Console.WriteLine("No");
            }
        }
    }
}
