using System;

class NumbersAsWords
{
    static void Main()
    {
        //Reading the input
        Console.Write("Please insert an integer [0;999]: ");
        int number = int.Parse(Console.ReadLine());
        
        //Getting the digit's value from right to left (e.g. 100 - thirdDigit == 1)
        int thirdDigit = number / 100;
        int secondAndFirstDigit = number % 100 ;
        int firstDigit = number % 10;

        //Checking the number's digits 
        bool isThreeDigit = (thirdDigit != 0);
        bool isTwoDigit = (secondAndFirstDigit > 9);
        bool isOnlyOneDigit = !isTwoDigit;

        //Logic is simple- while we have the count and the values of the number we can easily print our wanted input by having several switch and if-cases.

        if (isThreeDigit)
        {
            switch (thirdDigit)
            {
                case 1:
                    Console.Write("One hundred ");
                    break;
                case 2:
                    Console.Write("Two hundred ");
                    break;
                case 3:
                    Console.Write("Three hundred ");
                    break;
                case 4:
                    Console.Write("Four hundred ");
                    break;
                case 5:
                    Console.Write("Five hundred ");
                    break;
                case 6:
                    Console.Write("Six hundred ");
                    break;
                case 7:
                    Console.Write("Seven hundred ");
                    break;
                case 8:
                    Console.Write("Eight hundred ");
                    break;
                case 9:
                    Console.Write("Nine hundred ");
                    break;
                default:
                    Console.WriteLine("Invalid number!");
                    return;
            }
            // If the number's third digit is the only not equal to 0, print new line
            if (secondAndFirstDigit ==0)
            {
                Console.WriteLine();
            }
        }

        if ((isThreeDigit && isTwoDigit) || isTwoDigit)
        {
            if (isTwoDigit && isThreeDigit)
            {
                Console.Write("and ");
            }
            if (secondAndFirstDigit > 19 && secondAndFirstDigit < 100)
            {
                switch (secondAndFirstDigit / 10)
                {
                    case 2:
                        Console.Write("twenty ");
                        break;
                    case 3:
                        Console.Write("thirty ");
                        break;
                    case 4:
                        Console.Write("fourty ");
                        break;
                    case 5:
                        Console.Write("fifty ");
                        break;
                    case 6:
                        Console.Write("sixty ");
                        break;
                    case 7:
                        Console.Write("seventy ");
                        break;
                    case 8:
                        Console.Write("eighty ");
                        break;
                    case 9:
                        Console.Write("ninety ");
                        break;
                    default:
                        Console.WriteLine("Invalid number!");
                        return;
                }
                //If the first digit is equal to 0 print a new line.
                if (firstDigit == 0)
                {
                    Console.WriteLine();
                }
            }

            if (secondAndFirstDigit > 9 && secondAndFirstDigit < 20)
            {
                switch (secondAndFirstDigit % 10)
                {
                    case 0:
                        Console.WriteLine("ten");
                        break;
                    case 1:
                        Console.WriteLine("eleven");
                        break;
                    case 2:
                        Console.WriteLine("twelve");
                        break;
                    case 3:
                        Console.WriteLine("thirteen");
                        break;
                    case 4:
                        Console.WriteLine("fourteen");
                        break;
                    case 5:
                        Console.WriteLine("fifteen");
                        break;
                    case 6:
                        Console.WriteLine("sixteen");
                        break;
                    case 7:
                        Console.WriteLine("seventeen");
                        break;
                    case 8:
                        Console.WriteLine("eighteen");
                        break;
                    case 9:
                        Console.WriteLine("nineteen");
                        break;
                    default:
                        Console.WriteLine("Invalid number!");
                        return;
                }
            }
        }

        //Getting a new bool. Now checking if the number is not teen so can be printed properly without repeat.

        bool isNotTeen = !(secondAndFirstDigit > 9 && secondAndFirstDigit < 20);
        if ((isThreeDigit && isNotTeen) || (isTwoDigit && isNotTeen) || isOnlyOneDigit)
        {
            switch (number % 10)
            {
                case 0:
                    if (isOnlyOneDigit)
                    {
                        Console.WriteLine("Zero");
                    }
                    else
                    {
                        Console.WriteLine("");
                    }
                    break;
                case 1:
                    Console.WriteLine("one");
                    break;
                case 2:
                    Console.WriteLine("two");
                    break;
                case 3:
                    Console.WriteLine("three");
                    break;
                case 4:
                    Console.WriteLine("four");
                    break;
                case 5:
                    Console.WriteLine("five");
                    break;
                case 6:
                    Console.WriteLine("six");
                    break;
                case 7:
                    Console.WriteLine("seven");
                    break;
                case 8:
                    Console.WriteLine("eight");
                    break;
                case 9:
                    Console.WriteLine("nine");
                    break;
                default:
                    Console.WriteLine("Invalid number!");
                    return;
            }
        }
    }
}