using System;
using System.Collections.Generic;

class HexadecimalToDecimalNumber
{
    static void Main()
    {
        //Reading the input as a string.
        //Turning it in a char array.
        //Then putting every character as integer, through using switch-case, in a list.
        Console.Write("Please insert number in hexadecimal numeral system: ");
        string inputNumber=Console.ReadLine();
        char[] arrayNumbers = inputNumber.ToCharArray();
        List<int> numbers = new List<int>();

        for (int i = 0; i <arrayNumbers.Length; i++)
        {
            switch (arrayNumbers[i])
            {
                case '0':
                numbers.Add(0);
                    break;
                case '1':
                numbers.Add(1);
                    break;
                case '2':
                    numbers.Add(2);
                    break;
                case '3':
                    numbers.Add(3);
                    break;
                case '4':
                    numbers.Add(4);
                    break;
                case '5':
                    numbers.Add(5);
                    break;
                case '6':
                    numbers.Add(6);
                    break;
                case '7':
                    numbers.Add(7);
                    break;
                case '8':
                    numbers.Add(8);
                    break;
                case '9':
                    numbers.Add(9);
                    break;
                case 'A':
                    numbers.Add(10);
                    break;
                case 'B':
                    numbers.Add(11);
                    break;
                case 'C':
                    numbers.Add(12);
                    break;
                case 'D':
                    numbers.Add(13);
                    break;
                case 'E':
                    numbers.Add(14);
                    break;
                case 'F':
                    numbers.Add(15);
                    break;
                default:
                    Console.WriteLine("Invalid input!(Put your caps lock ON !)");
                    return;
            }
        }
        long poweredNumber = 1;
        long decimalNumber = 0;

        //Using a for-loop to power the foundament number(основа - 16) and sum it in end variable- decimalNumber. 
        for (int index = 0; index < numbers.Count; index++)
        {
            if (index != numbers.Count-1)
            {
                poweredNumber = 1;
                for (int POW = numbers.Count -1 -index; POW > 0; POW--)
                {
                    poweredNumber *= 16;
                }
                decimalNumber += poweredNumber*numbers[index];
            }
            else
            {
                poweredNumber = 1;
                decimalNumber += poweredNumber * numbers[index];
            }
        }
        Console.WriteLine("The decimal representation of this {0} is: {1} !", inputNumber, decimalNumber);
       
    }
}  