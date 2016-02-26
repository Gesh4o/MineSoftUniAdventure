namespace _01.ReverseString
{
    using System;

    public class ReverseStringMain
    {
        public static void Main()
        {
            char[] inputAsChars = Console.ReadLine().ToCharArray();

            for (int i = 0; i < inputAsChars.Length - (inputAsChars.Length / 2); i++)
            {
                char oldValue = inputAsChars[i];
                inputAsChars[i] = inputAsChars[inputAsChars.Length - 1 - i];
                inputAsChars[inputAsChars.Length - 1 - i] = oldValue;
            }

            string reversedInput = string.Join(string.Empty, inputAsChars);
            Console.WriteLine(reversedInput);
        }
    }
}
