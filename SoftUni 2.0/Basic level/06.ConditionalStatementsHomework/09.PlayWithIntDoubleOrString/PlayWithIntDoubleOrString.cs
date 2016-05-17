using System;

class ChoicableData
{
    static void Main()
    {
        Console.WriteLine("Please select one of these data types you want to work with: ");
        Console.WriteLine("For integer pick - 1");
        Console.WriteLine("For number pick - 2");
        Console.WriteLine("For integer pick - 3");
        Console.Write("Please insert your pick: ");
        int pick = int.Parse(Console.ReadLine());
        switch (pick)
        {
            case 1:
                Console.Write("Please insert an integer: ");
                int number0 = int.Parse(Console.ReadLine());
                Console.WriteLine(number0+1);
                break;
            case 2:
                Console.Write("Please insert a number: ");

                double number1 = int.Parse(Console.ReadLine());
                Console.WriteLine(number1 + 1);
                break;
            case 3:
                Console.Write("Please insert a text: ");
                string input = Console.ReadLine();
                Console.WriteLine(input+"*");
                break;
            default:
                break;
        }

    }
}