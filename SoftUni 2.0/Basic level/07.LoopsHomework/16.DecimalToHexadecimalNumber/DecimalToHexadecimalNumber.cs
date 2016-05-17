using System;
using System.Collections.Generic;


class DecimalToHexadecimalNumber
{
    static void Main()
    {
        //The same logic here.
        Console.Write("Please insert number in decimal numberal system: ");
        long inputNumber = long.Parse(Console.ReadLine());

        bool isDone = false;
        List<string> outputNumber = new List<string>();

        for (int i = 0; !isDone; i++)
        {
            long hexadecimalNumber = inputNumber % 16;
            inputNumber /= 16;
            switch (hexadecimalNumber)
            {
                case 0:
                    outputNumber.Add("0");
                    break;
                case 1:
                    outputNumber.Add("1");
                    break;
                case 2:
                    outputNumber.Add("2");
                    break;
                case 3:
                    outputNumber.Add("3");
                    break;
                case 4:
                    outputNumber.Add("4");
                    break;
                case 5:
                    outputNumber.Add("5");
                    break;
                case 6:
                    outputNumber.Add("6");
                    break;
                case 7:
                    outputNumber.Add("7");
                    break;
                case 8:
                    outputNumber.Add("8");
                    break;
                case 9:
                    outputNumber.Add("9");
                    break;
                case 10:
                    outputNumber.Add("A");
                    break;
                case 11:
                    outputNumber.Add("B"); 
                    break;
                case 12:
                    outputNumber.Add("C");
                    break;
                case 13:
                    outputNumber.Add("D");
                    break;
                case 14:
                    outputNumber.Add("E");
                    break;
                case 15:
                    outputNumber.Add("F");
                    break;
                default:
                    Console.WriteLine("Invalid input!");
                    return;
            }
            if (inputNumber ==0)
            {
                isDone = true;
            }
        }
        Console.Write("The hexadecimal representation: ");
        for (int i = outputNumber.Count - 1; i >= 0; i--)
        {
            Console.Write(outputNumber[i]);
        }
        Console.WriteLine();
    }
}