using System;
using System.Numerics;

class TracingZeroesInN
{
    static void Main()
    {
        //Mine simple way.
        /*
        Console.Write("Please insert integer N: ");
        uint n = uint.Parse(Console.ReadLine());
        BigInteger result = 1;

        for (uint i = n; i >1 ; i--)
        {
            result *= i;
        }
        Console.WriteLine("The N!= " + result);
        uint count = 0;
        bool isDone = false;
        for (uint i = 0; !isDone; i++)
        {
            BigInteger lastZero = result % 10;
            result /= 10;
            if (lastZero!=0)
            {
                isDone = true;
            }
            count++;
        }
        Console.WriteLine(count -1); */

        Console.Write("Please insert N: ");
        int n = int.Parse(Console.ReadLine());
        int five = 5;
        int sum = 0;
        int deviding = 1;
        while (deviding > 0)
        {
            sum += (n / five);
            deviding = n / five;
            five *= 5;
        }

        Console.WriteLine("The {0}! have {1} zero (s) in the end ! ", n, sum);
    }
}