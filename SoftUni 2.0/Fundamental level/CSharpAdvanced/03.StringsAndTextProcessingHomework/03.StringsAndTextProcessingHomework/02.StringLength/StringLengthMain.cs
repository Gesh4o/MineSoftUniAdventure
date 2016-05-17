namespace _02.StringLength
{
    using System;

    public class StringLengthMain
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            if (input.Length < 20)
            {
                Console.WriteLine(input.PadRight(20, '*'));
            }
            else
            {
                input = input.Remove(20);
                Console.WriteLine(input);
            }
        }
    }
}
