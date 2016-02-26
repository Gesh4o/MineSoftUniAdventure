namespace _04.IndexOfFirstLargerThenNeighbours
{
    using System;

    public class FirstLargerMain
    {
        public static void Main(string[] args)
        {
            int[] firstSequence = { 1, 2, 3, 5, 0, 1, 5 };
            int[] secondSequence = { 1, 2, 3, 4, 5, 6, 6 };
            int[] thirdSequence = { 1, 1, 1 };

            Console.WriteLine(GetIndexOfFirstElementLargerThenNeighbours(firstSequence));
            Console.WriteLine(GetIndexOfFirstElementLargerThenNeighbours(secondSequence));
            Console.WriteLine(GetIndexOfFirstElementLargerThenNeighbours(thirdSequence));
        }

        private static int GetIndexOfFirstElementLargerThenNeighbours(int[] sequence)
        {
            for (int index = 0; index < sequence.Length; index++)
            {
                if (index == 0)
                {
                    if (sequence[index] > sequence[index + 1])
                    {
                        return index;
                    }
                }
                else if (index == sequence.Length - 1)
                {
                    if (sequence[index] > sequence[index - 1])
                    {
                        return index;
                    }
                }
                else
                {
                    if (sequence[index] > sequence[index - 1] && sequence[index] > sequence[index + 1])
                    {
                        return index;
                    }
                }
            }

            return -1;
        }
    }
}
