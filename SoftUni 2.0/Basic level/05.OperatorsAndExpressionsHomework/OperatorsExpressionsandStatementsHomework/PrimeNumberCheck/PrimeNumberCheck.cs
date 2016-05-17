using System;

namespace PrimeNumberCheck
{
    class PrimeNumberCheck
    {
        /* Write an expression that checks if given positive integer number n (n ≤ 100) 
        is prime (i.e. it is divisible without remainder only to itself and 1) */
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            bool isPrime = false;

            if (n > 100 || n <= 1)
            {
                isPrime = false;
            }
            else if (n == 2) isPrime = true; // makes an exception for the number 2, which is a prime but cannot be calculated properly by my for loop
            else
            {
                    for (int i = n - 1; i > 1; i--) // divides it from every number to check if it has a remainder
                    {
                        if (n % i == 0) // if we find that it doesn't have a remainder, it is not a prime number
                        {
                            isPrime = false;
                            break; // this is very crucial, when this line executes it ends the for statement
                        }
                        else
                        {
                            isPrime = true;
                        }
                    }
            }
            Console.WriteLine(isPrime);
        }
    }
}
