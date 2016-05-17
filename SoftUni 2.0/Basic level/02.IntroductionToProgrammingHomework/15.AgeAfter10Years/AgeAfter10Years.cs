using System;

class AgeAfter10Years
{
    static void Main()
    {
        while (true)
        //While is inserted for the ease of the users- to check if the program is giving the right answers.
        {
            Console.Write("Enter your birth date: ");
            DateTime birthDay = DateTime.Parse(Console.ReadLine());
            int age = (int)((DateTime.Now - birthDay).TotalDays / 365.242199);
            Console.WriteLine("You are " + age + " year(s) old!");
            Console.WriteLine("After ten years you will be at the age of " + (age + 10) + "!");
            Console.WriteLine("");
            Console.WriteLine("Do you want to try another one? If else type \"exit\" on the next line to end the program! ");
            string line = Console.ReadLine();
            if (line == "exit")
            {
                break;
            }
        }
    }
}