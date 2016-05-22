namespace _01.MaxSeqOfEqualElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MaxElementsMain
    {
        public static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                            .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            int maxNumber = 0;
            int maxCount = -1;
            HashSet<int> numbers = new HashSet<int>(array);
            foreach (int number in numbers)
            {
                int repetitionCount = array.Count(num => num == number);
                if (repetitionCount > maxCount)
                {
                    maxCount = repetitionCount;
                    maxNumber = number;
                }
            }

            for (int i = 0; i < maxCount; i++)
            { 
                Console.Write(maxNumber + " ");
            }

            Console.WriteLine();
        }
    }
}
