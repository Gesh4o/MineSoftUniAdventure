using System;

namespace BitExchangeAdvanced
{
    class BitExchangeAdvanced
    {
        static void Main()
        {
            Console.Write("Enter the number you want:");
            long n = long.Parse(Console.ReadLine());
            Console.Write("Enter the position:");
            int p = int.Parse(Console.ReadLine());
            Console.Write("Enter q:");
            int q = int.Parse(Console.ReadLine());
            Console.Write("Enter k:");
            int k = int.Parse(Console.ReadLine());


            if (p + k >= 32)
            {
                Console.WriteLine("Parameters are invalid");
            }
            else
            {
                for (int i = 0; i < k; i++)
                {
                    int maskOne = (int)(n & (1 << p)) >> p; // Find the bit you want to change
                    int maskTwo = (int)(n & (1 << q)) >> q;

                    if (maskOne == 0)
                    {
                        n = n & (~(1 << q));
                    }
                    else if (maskOne == 1)
                    {
                        n = n | (1 << q);
                    }

                    if (maskTwo == 0)
                    {
                        n = n & (~(1 << p));
                    }
                    else if (maskTwo == 1)
                    {
                        n = n | (1 << p);
                    }

                    p++;
                    q++;
                }

                Console.WriteLine(n);
            }
        }
    }
}