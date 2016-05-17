using System;
using System.Collections.Generic;

class DecimalToBinaryNumber
{
    static void Main()
    {
        Console.Write("Please insert number in decimal numeral system: ");
        long inputNumber = long.Parse(Console.ReadLine());
        bool isNotDone = !(inputNumber==0);
        List<string> binaryNumbers = new List<string>();

        if (inputNumber == 0)
        {
            Console.WriteLine("0");
            return;
        }
        while (isNotDone)
        {
            int number = (int)inputNumber % 2;
            inputNumber /= 2;
            if (number == 1)
            {
                binaryNumbers.Add("1");
            }
            else if (number == 0)
            {
                binaryNumbers.Add("0");
            }
            if (inputNumber == 0)
            {
                isNotDone = false;
            }
        }
        Console.Write("Binary representation: ");
        for (int i = binaryNumbers.Count-1; i>=0 ; i--)
        {
            Console.Write(binaryNumbers[i]);
        }
        Console.WriteLine();
      
    }
}