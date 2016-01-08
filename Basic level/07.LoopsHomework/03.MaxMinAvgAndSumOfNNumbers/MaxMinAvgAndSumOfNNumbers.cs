using System;

class MaxMinAvgAndSumOfNNumbers
{
    static void Main()
    {
        Console.Write("Please insert how many numbers will be read: ");
        int numbersCount = int.Parse(Console.ReadLine());
        int max = int.MinValue;
        int min = int.MaxValue;
        int sum = 0;
        double avg = 0;
        double sumAvg = 0;

        for (int count = 0; count < numbersCount; count++)
        {
            if (count ==0)
            {
                Console.Write("Insert the 1st one: ");
            }
            else if (count != 0)
            {
                Console.Write("Insert the {0}th one: ",count +1);
            }
            int number = int.Parse(Console.ReadLine());
            max = Math.Max(number, max);
            min = Math.Min(number, min);
            sum += number;
            avg = (double)number / (double)numbersCount;
            sumAvg += avg;
        }
        Console.WriteLine("The max value is: {0} !\nThe min value is: {1} !\nTHe sum is: {2} !\nThe avarage is: {3:F2}",max,min,sum,sumAvg);
    }
}