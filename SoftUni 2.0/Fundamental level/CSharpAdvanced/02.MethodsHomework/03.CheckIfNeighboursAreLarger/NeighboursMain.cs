namespace _03.CheckIfNeighboursAreLarger
{
    using System;

    public class NeighboursMain
    {
        public static void Main()
        {
            int[] numbers = { 1, 3, 4, 5, 1, 0, 5 };

            for (int index = 0; index < numbers.Length; index++)
            {
                Console.WriteLine(IsLargerThenNeighbours(index, numbers));
            }
        }

        private static bool IsLargerThenNeighbours(int index, int[] numbers)
        {
            bool result;

            if (numbers.Length == 0)
            {
                return false;
            }

            if (numbers.Length == 1)
            {
                return true;
            }

            if (index == 0)
            {
                result = numbers[index] > numbers[index + 1];
            }
            else if (index == numbers.Length - 1)
            {
                result = numbers[index] > numbers[index - 1];
            }
            else
            {
                result = numbers[index] > numbers[index - 1] && numbers[index] > numbers[index + 1];
            }

            return result;
        }
    }
}
