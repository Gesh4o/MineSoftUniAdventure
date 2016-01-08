using System;

class OddOrEvenSum
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int sum1 = 0;
        int sum2 = 0;
        for (int i = 0; i < 2*n; i++)
        {
            int number = int.Parse(Console.ReadLine());
            if(i % 2==0)
            {
                sum1 += number;
            }
            else
            {
                sum2 += number;
            }
        }
        if (sum1==sum2)
        {
            Console.WriteLine("Yes, sum={0}",sum2);
        }
        else
        {
            Console.WriteLine("No, diff={0}",Math.Abs(sum1-sum2));
        }
    }
}