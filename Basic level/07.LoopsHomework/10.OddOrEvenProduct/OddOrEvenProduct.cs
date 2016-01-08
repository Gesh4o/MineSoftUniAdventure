using System;


class OddAndEvenProduct
{
    static void Main()
    {
        Console.WriteLine("Please insert the numbers separated by \" \": ");
        bool isDone = false;
        int evenProduct = 1;
        int oddProduct = 1;
        int number = 0;
        int counter = 0;

        string[] input = Console.ReadLine().Split();
        if (input.Length <4)
        {
            Console.WriteLine("Invalid input!");
            return;
        }
        for (int i = 1; i <= input.Length; i++)
        {
            isDone = !(int.TryParse(input[counter], out number));
            if (i % 2 == 0)
            {
                evenProduct *= number;
            }
            else if (i % 2 == 1)
            {
                oddProduct *= number;
            }
            counter++;
        }
        bool isEven = evenProduct == oddProduct;
        if (isEven)
        {
            Console.WriteLine("yes");
            Console.WriteLine(evenProduct);
        }
        else
        {
            Console.WriteLine("no");
            Console.WriteLine("Odd product= " + oddProduct);
            Console.WriteLine("Even product = " + evenProduct);
        }

    }
}