using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());
        int number;
        for (int i = 0; i < n; i++)
        {
            number = int.Parse(Console.ReadLine());
            string number0 = Convert.ToString(number, 2);
            Console.WriteLine(number0);
        }
    }
}