namespace _09.ReversedChars
{
    using System;

    public class ReversedCharsMain
    {
        public static void Main(string[] args)
        {
            char[] array = new char[3];
            for (int i = 0; i < 3; i++)
            {
                array[i] = Console.ReadLine()[0];
            }

            Array.Reverse(array);
            Console.WriteLine(string.Join(string.Empty, array));
        }
    }
}
