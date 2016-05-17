using System;

class Program
{
    static void Main()
    {
        int input = int.Parse(Console.ReadLine());
        for (int rows = 0; rows < input; rows++)
        {
            if (rows == 0 || rows == input - 1)
            {
                Console.WriteLine("{0}{1}{2}", "".PadLeft(input * 2, '*'), "".PadLeft(input, ' '), "".PadLeft(input * 2, '*'));
            }
            else if (rows == (input / 2))
            {
                Console.Write("*{0}*", "".PadLeft((input * 2) - 2, '/'));
                Console.Write("".PadLeft(input, '|'));
                Console.WriteLine("*{0}*", "".PadLeft((input * 2) - 2, '/'));
            }
            else
            {
                Console.Write("*{0}*", "".PadLeft((input * 2) - 2, '/'));
                Console.Write("".PadLeft(input, ' '));
                Console.WriteLine("*{0}*", "".PadLeft((input * 2) - 2, '/'));
            }
        }
    }
}