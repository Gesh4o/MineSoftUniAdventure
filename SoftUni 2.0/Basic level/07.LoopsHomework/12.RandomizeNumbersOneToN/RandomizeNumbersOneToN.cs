using System;

class Program
{
    static void Main()
    {
        Console.Write("Please insert integer N: ");
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];
        Random positions = new Random();

        for (int pos = 0; pos < n; pos++)
        {
            numbers[pos] = pos + 1;
        }
        for (int i = 0; i < n; i++)
        {
            int indexOne = positions.Next(n);
            int indexTwo = positions.Next(n);
            int temp = numbers[indexOne];
            numbers[indexOne] = numbers[indexTwo];
            numbers[indexTwo] = temp;
        }
        for (int index = 0; index < n; index++)
        {
            Console.Write(numbers[index] + "  ");
        }
        Console.WriteLine();
    }
}