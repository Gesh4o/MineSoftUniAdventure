namespace _18.PrintName
{
    using System;

    public class PrintNameMain
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            PrintInputName(name);
        }

        private static void PrintInputName(string name)
        {
            Console.WriteLine("Hello, {0}!", name);
        }
    }
}
