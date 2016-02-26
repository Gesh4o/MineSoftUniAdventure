namespace _09.TerroristWin
{
    using System;

    public class TerroristWinMain
    {
        public static void Main()
        {
            char[] inputAsChars = Console.ReadLine().ToCharArray();

            for (int startIndex = 0; startIndex < inputAsChars.Length; startIndex++)
            {
                if (inputAsChars[startIndex] == '|')
                {
                    int sum = 0;
                    int endIndex = startIndex + 1;
                    while (inputAsChars[endIndex] != '|')
                    {
                        sum += inputAsChars[endIndex];
                        endIndex++;
                    }

                    var bombPower = sum % 10;

                    // Left from the bomb.
                    if (startIndex - 1 - bombPower < 0)
                    {
                        for (int leftIndex = 0; leftIndex < startIndex; leftIndex++)
                        {
                            inputAsChars[leftIndex] = '.';
                        }
                    }
                    else
                    {
                        for (int leftIndex = startIndex - 1; leftIndex > startIndex - bombPower - 1; leftIndex--)
                        {
                            inputAsChars[leftIndex] = '.';
                        }
                    }

                    // In the bomb.
                    for (int middleIndex = startIndex; middleIndex <= endIndex; middleIndex++)
                    {
                        inputAsChars[middleIndex] = '.';
                    }

                    // Right from the bomb.
                    if (endIndex + 1 + bombPower > inputAsChars.Length - 1)
                    {
                        for (int rightIndex = endIndex + 1; rightIndex < inputAsChars.Length; rightIndex++)
                        {
                            inputAsChars[rightIndex] = '.';
                        }
                    }
                    else
                    {
                        for (int rightIndex = endIndex; rightIndex <= endIndex + bombPower; rightIndex++)
                        {
                            inputAsChars[rightIndex] = '.';
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(string.Empty, inputAsChars));
        }
    }
}
