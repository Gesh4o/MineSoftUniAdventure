using System;

class OddAndEvenElements
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] inputNumbers = input.Split(' ');
        double[] numbers = new double [inputNumbers.Length];

        double evenMax = double.MinValue;
        double evenMin = double.MaxValue;
        double evenSum = 0;

        double oddMax = double.MinValue;
        double oddMin = double.MaxValue;
        double oddSum = 0;

        bool isPossible = true;
        string no = "No";


        for (int i = 0; i < inputNumbers.Length; i++)
        {
            numbers[i] = double.Parse(inputNumbers[i]);
        }

        for (int i = 0; i < numbers.Length; i++)
        {
            if ((i+1) % 2 == 1)
            {
                oddMax = Math.Max(oddMax, numbers[i]);
                oddMin = Math.Min(oddMin, numbers[i]);
                oddSum += numbers[i];
            }
            else
            {
                evenMax = Math.Max(evenMax, numbers[i]);
                evenMin = Math.Min(evenMin, numbers[i]);
                evenSum += numbers[i];
            }
        }
        if (evenMax == double.MinValue && evenMin == double.MaxValue)
        {
            isPossible = false;
        }
        Console.Write("OddSum={0:#.##}, OddMin={1:#.##}, OddMax={2:#.##},", oddSum , oddMin, oddMax);
        if (isPossible)
        {
            Console.Write(" EvenSum={0:#.##}, EvenMin={1:#.##}, EvenMax={2:#.##}", evenSum, evenMin, evenMax);
        }
        else
        {
            Console.Write(" EvenSum={0}, EvenMin={0}, EvenMax={0}", no);
        }
        Console.WriteLine();
    }
}