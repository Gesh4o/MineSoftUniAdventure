using System;

class HalfSum
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int firstSum = 0;
        for (int i = 0; i < n; i++)
        {
            int firstNumbers = int.Parse(Console.ReadLine());
            firstSum += firstNumbers;
        }
        int secondSum = 0;
        for (int i = 0; i < n; i++)
        {
            int secondNumbers = int.Parse(Console.ReadLine());
            secondSum += secondNumbers;
        }
        if (firstSum==secondSum)
        {
            Console.WriteLine("Yes, sum={0}", firstSum);
        }
        else
        {
            Console.WriteLine("No, diff={0}", Math.Abs(firstSum - secondSum));
        }
    }
}