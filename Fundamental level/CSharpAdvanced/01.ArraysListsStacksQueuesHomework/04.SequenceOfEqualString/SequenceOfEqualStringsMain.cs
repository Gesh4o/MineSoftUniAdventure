namespace _04.SequenceOfEqualString
{
    using System;
    using System.Collections.Generic;

    public class SequenceOfEqualStringsMain
    {
        public static void Main(string[] args)
        {
            string[] stringArray = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var uniqueSequences = new List<string>();

            // Index use to iterate through every element in passed from the input strings.
            for (int uncheckedIndex = 0; uncheckedIndex < stringArray.Length; uncheckedIndex++)
            {
                if (uniqueSequences.Contains(stringArray[uncheckedIndex]))
                {
                    continue;
                }

                int repetitionsCount = 0;

                // Index used to iterate through every next element from the current unchecked one.
                for (int currentIndex = uncheckedIndex + 1; currentIndex < stringArray.Length; currentIndex++)
                {
                    if (stringArray[uncheckedIndex] == stringArray[currentIndex])
                    {
                        if (!uniqueSequences.Contains(stringArray[uncheckedIndex]))
                        {
                            uniqueSequences.Add(stringArray[uncheckedIndex]);
                            repetitionsCount++;
                        }
                        else
                        {
                            repetitionsCount++;
                        }
                    }
                }

                if (repetitionsCount == 0)
                {
                    Console.WriteLine(stringArray[uncheckedIndex]);
                }
                else
                {
                    for (int i = 0; i < repetitionsCount + 1; i++)
                    {
                        Console.Write(stringArray[uncheckedIndex] + " ");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
