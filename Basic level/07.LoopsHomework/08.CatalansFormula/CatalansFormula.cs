using System;
using System.Numerics;

class CatalansFormula
{
    static void Main()
    {
        Console.Write("Please insert integer N: ");
        int n = int.Parse(Console.ReadLine());
        BigInteger devidend = 1;
        BigInteger devisor = 1;
        if (n==0)
        {
            Console.WriteLine("The result from (2N)!/((N+1)!*(N!))= 1");
            return;
        }

        for (int index = 2*n ; index > n + 1; index--)
        {
            devidend *= index;
        }
        for (int i = n ; i > 0; i--)
        {
            devisor *= i;
        }
        Console.WriteLine("The result from (2N)!/((N+1)!*(N!))= {0}", devidend/devisor);
    }
}