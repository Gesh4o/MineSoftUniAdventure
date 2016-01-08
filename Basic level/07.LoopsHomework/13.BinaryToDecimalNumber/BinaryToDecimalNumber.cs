using System;
using System.Collections.Generic;

class BinaryToDecimalNumber
{
    static void Main()
    {
        //Reading the numbers and putting them in list using for-loop. Note that I use "49" and "48" - numbers for "1" and "0" in the ASCII table.
        Console.Write("Please insert number in binary: ");
        List<int> numbers = new List<int>();
        bool isNotDone = true;
        long decimalNumber = 0;

        for (int i = 0; isNotDone; i++)
        {
            int number = Console.Read();
            if (number != 49 && number != 48)
            {
                isNotDone = false;
            }
            else if (number == 49)
            {
                numbers.Add(1);
            }
            else if (number == 48)
            {
                numbers.Add(0);
            }
        }
        long poweredNumber = 1;

        //New for-loop to calculate the decimal's value.
        //I use numbers from the list and I power them n-times depending on their position in binary form(not the list's order)!
        for (int count = 0 ; count <numbers.Count ; count++ )
        {
            if (numbers[count] == 1)
            {
                if (count == numbers.Count -1)
                {
                    decimalNumber += 1;
                    continue;
                }
                poweredNumber = 1;
                for (int i = numbers.Count -1; i >count; i--)
                {
                    poweredNumber *= 2;
                }
                decimalNumber += poweredNumber;
            }
            else
            {
                continue;
            }
        }
        Console.WriteLine("It's decimal representation: " + decimalNumber);
    }
}