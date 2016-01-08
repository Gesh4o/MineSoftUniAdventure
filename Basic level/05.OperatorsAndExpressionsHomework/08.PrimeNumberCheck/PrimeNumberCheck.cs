using System;

class PrimeNumberCheck
{
    static void Main()
    {
        int n;
        int maxDevider;
        int minDevider = 2;
        Console.Write("Please insert an integer: ");
        n = int.Parse(Console.ReadLine());
        if (n <= 0 || n >= 100)
        {
            Console.WriteLine("Invalid input - the number must be below 100 and positive (e.g. 0<n<100)!");
            return;
        }
        maxDevider = (int)Math.Sqrt(n);
        bool prime = true;
        if(n==1)
        {
            Console.WriteLine("Your integer is prime - False !");
            return;
        }
        while (minDevider <= maxDevider)
        {
            if (n % minDevider == 0)
            {
                prime = false;
            }
            else
            {
                prime = true;
            }
            minDevider++;
        }
        Console.WriteLine("Your integer is prime - {0} !", prime);
    }
}
    