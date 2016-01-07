using System;
using System.Collections.Generic;

namespace _02.EnterNumbers
{
    class EnterNumbers
    {
        static void Main()
        {
            try
            {
                Console.Write("Please insert start number: ");
                int startNumber = int.Parse(Console.ReadLine());

                Console.Write("Please insert end number: ");
                int endNumber = int.Parse(Console.ReadLine());
                int[] numbers = new int[10];
                Console.WriteLine("Please insert 10 numbers (each on a separate line): ");


                for (int i = 0; i < numbers.Length; i++)
                {
                    int number = int.Parse(Console.ReadLine());
                    //This check will be if the number is in proper range.
                    while (!(number > startNumber && number < endNumber))
                    {
                        Console.WriteLine("Invalid number, try again!");
                        number = int.Parse(Console.ReadLine());
                    }
                    if (i == 0)
                    {
                        numbers[i] = number;
                    }
                    else if (number > numbers[i - 1])
                    {
                        numbers[i] = number;
                    }
                    else //If the previous number is larger it will show this message and will return i-=1
                    {
                        Console.WriteLine("Invalid number, please try again!");
                        i--;
                    }
                }

                foreach (var item in numbers)
                {
                    Console.Write(item + " ");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number!");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Number out of range!");
            }
        }
    }
}
