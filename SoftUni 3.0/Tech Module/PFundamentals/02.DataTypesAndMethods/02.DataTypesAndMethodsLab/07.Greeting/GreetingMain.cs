namespace _07.Greeting
{
    using System;

    public class GreetingMain
    {
        private const string FormatMessage = "Hello, {0}. You are {1} years old.";

        public static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string secondName = Console.ReadLine();
            string wholeName = firstName + " " + secondName;
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine(FormatMessage, wholeName, age);
        }
    }
}
