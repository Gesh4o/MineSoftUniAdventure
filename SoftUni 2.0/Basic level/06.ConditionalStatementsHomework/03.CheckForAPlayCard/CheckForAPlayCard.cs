using System;

class CheckForAPlayCard
{
    static void Main()
    {
        Console.Write("Insert a symbol to valide if it is card sign: ");
        string input = Console.ReadLine();
        string yes = "yes";
        switch (input)
        {
            case "2":
                Console.WriteLine(yes);
                break;
            case "3":
                Console.WriteLine(yes);
                break;
            case "4":
                Console.WriteLine(yes);
                break;
            case "5":
                Console.WriteLine(yes);
                break;
            case "6":
                Console.WriteLine(yes);
                break;
            case "7":
                Console.WriteLine(yes);
                break;
            case "8":
                Console.WriteLine(yes);
                break;
            case "9":
                Console.WriteLine(yes);
                break;
            case "10":
                Console.WriteLine(yes);
                break;
            case "J":
                Console.WriteLine(yes);
                break;
            case "Q":
                Console.WriteLine(yes);
                break;
            case "K":
                Console.WriteLine(yes);
                break;
            case "A":
                Console.WriteLine(yes);
                break;
            default:
                Console.WriteLine("no");
                break;
        }
    }
}