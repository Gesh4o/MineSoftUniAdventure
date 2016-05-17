using System;

class SortingNumbers
{
    static void Main()
    {
        Console.Write("Please insert how many numbers N will be sorted: ");
        int nCount = int.Parse(Console.ReadLine());

        int[] numbers = new int[nCount];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(numbers);
        Console.Write("The asceding order is: ");
        foreach (var number in numbers)
        {
            Console.Write( number + " ");
        }
        Console.WriteLine();
    }
}