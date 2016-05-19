namespace _01.LargestCommonEnd
{
    using System;

    public class LargestCommonEndMain
    {
        public static void Main()
        {
            string[] firstArray = Console.ReadLine().Split(' ');
            string[] secondArray = Console.ReadLine().Split(' ');

            int leftRepetitions = CalculateLeftRepetitions(firstArray, secondArray);
            int rightRepetitions = CalculateRightRepetitions(firstArray, secondArray);

            Console.WriteLine(Math.Max(leftRepetitions, rightRepetitions));
        }

        private static int CalculateRightRepetitions(string[] firstArray, string[] secondArray)
        {
            int count = 0;
            int secondIndex = secondArray.Length - 1;
            for (int i = firstArray.Length - 1; i >= 0; i--)
            {
                if (secondIndex < 0)
                {
                    return count;
                }

                if (firstArray[i] != secondArray[secondIndex])
                {
                    return count;
                }

                count++;
                secondIndex--;
            }

            return count;
        }

        private static int CalculateLeftRepetitions(string[] firstArray, string[] secondArray)
        {
            int count = 0;
            for (int i = 0; i < firstArray.Length; i++)
            {
                if (i >= secondArray.Length)
                {
                    return count;
                }

                if (firstArray[i] != secondArray[i])
                {
                    return count;
                }

                count++;
            }

            return count;
        }
    }
}
