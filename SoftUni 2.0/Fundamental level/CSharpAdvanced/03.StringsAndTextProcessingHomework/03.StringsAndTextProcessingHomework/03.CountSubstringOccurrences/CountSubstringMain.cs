namespace _03.CountSubstringOccurrences
{
    using System;

    public class CountSubstringMain
    {
        public static void Main()
        {
            char[] inputText = Console.ReadLine().ToLower().ToCharArray();
            char[] inputSearchedString = Console.ReadLine().ToLower().ToCharArray();

            int repeatCount = 0;

            for (int i = 0; i <= inputText.Length - inputSearchedString.Length; i++)
            {
                bool areDifferent = false;
                for (int j = 0; j < inputSearchedString.Length; j++)
                {
                    if (inputText[i + j] != inputSearchedString[j])
                    {
                        areDifferent = true;
                    }
                }

                if (!areDifferent)
                {
                    repeatCount++;
                }
            }

            Console.WriteLine(repeatCount);
        }
    }
}
