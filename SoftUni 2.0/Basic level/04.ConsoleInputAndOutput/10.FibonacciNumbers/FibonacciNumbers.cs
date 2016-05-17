using System;

class FibonacciNumbers
{
    static void Main()
    {
        Console.WriteLine("Please insert number \"n\"!");
        int n = int.Parse(Console.ReadLine());
        int number0 = 0;
        int number1 =1;
        int number2 = 0;
        if( n==1 )
        {
            Console.WriteLine(0);
        }
        Console.Write(number0 + ", ");
        Console.Write(number1 + ", ");
        for (int i = 3; i <= n; i++)
        {
            number2 = number0 + number1;
            Console.Write(number2 + ", ");
            number0 = number1;
            number1 = number2;
        }
        Console.WriteLine();
    }
}