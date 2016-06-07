namespace _06.StringAndObjects
{
    using System;

    public class ObjectsMain
    {
        public static void Main(string[] args)
        {
            string firstPart = Console.ReadLine();
            string secondPart = Console.ReadLine();
            object wholePartObject = firstPart + " " + secondPart;
            Console.WriteLine((string)wholePartObject);
        }
    }
}
