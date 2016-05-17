namespace _02.BePositive
{
    using System;
    using System.Linq;

    public class BePositiveMain
    {
        public static void Main(string[] args)
        {
            int sequencesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < sequencesCount; i++)
            {
                int[] numbers =
                    Console.ReadLine()
                        .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                bool isFound = false;
                for (int number = 0; number < numbers.Length; number++)
                {
                    int currentNum = numbers[number];

                    if (currentNum >= 0)
                    {
                        isFound = true;
                        Console.Write(currentNum + " ");
                    }
                    else
                    {
                        if (number != numbers.Length - 1)
                        {
                            number++;
                            currentNum += numbers[number];
                        }

                        if (currentNum >= 0)
                        {
                            isFound = true;
                            Console.Write(currentNum + " ");
                        }
                    }
                }

                if (!isFound)
                {
                    Console.WriteLine("(empty)");
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
