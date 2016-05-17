namespace _09.StuckNumbers
{
    using System;
    /* Notes: As starter I should say that I have no idea how I managed to solve this task.
    The idea is: Initially I read the input from the console and if passed elements count is below 4
    it ends the program with message: "No" (by default we should have 4 different elements).
    There are four nested for-loops which logic is: get me comparer couple(first stuck numbers)(first set of two loops)
    compare them with another couple(second stuck numbers)(second set of two loops). If no match is found print message.
    Basically remember that the first two loops will genarate all possible comparer couples but only in right direction(-->)
    (i.e. we have { 1, 2, 3, 4 } - it will generate: 
        12, 13, 14, 
        23, 24,
        34
    )
    Next couple is made through iterating through all possible couples and when there is a repetition in indexing- 
    trying to generate same or partially same couple continue command is passed in the for loop. In the core in this
    nested madness there are two comaparing conditions: if first couple matches current couple or if reversed first
    couple matches the current one.
    Through all this process  bool variable is passed which define if match is found or not.
    */
    public class StuckNumbersMain
    {
        public static void Main()
        {
            const int MinimalStuckNumbersCount = 4;

            int n = int.Parse(Console.ReadLine());

            string[] sequence = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (n < MinimalStuckNumbersCount)
            {
                Console.WriteLine("No");
                return;
            }

            bool areOccurrencesFound = FindOccurrences(sequence);

            if (!areOccurrencesFound)
            {
                Console.WriteLine("No");
            }
        }

        private static bool FindOccurrences(string[] sequence)
        {
            bool isFound = false;
            for (int firstSequenceIndex = 0; firstSequenceIndex < sequence.Length - 1; firstSequenceIndex++)
            {
                for (int secondSequenceIndex = firstSequenceIndex + 1;
                     secondSequenceIndex < sequence.Length;
                     secondSequenceIndex++)
                {
                    string firstStuckNumbers = sequence[firstSequenceIndex] + sequence[secondSequenceIndex];
                    string swappedFirstStuckNumbers = sequence[secondSequenceIndex] + sequence[firstSequenceIndex];

                    for (int currentIndexToCheck = 0;
                         currentIndexToCheck < sequence.Length;
                         currentIndexToCheck++)
                    {
                        for (int nextIndex = 0; nextIndex < sequence.Length; nextIndex++)
                        {
                            string stuckNumbers = sequence[currentIndexToCheck] + sequence[nextIndex];

                            if (currentIndexToCheck == secondSequenceIndex ||
                                currentIndexToCheck == firstSequenceIndex ||
                                nextIndex == firstSequenceIndex ||
                                nextIndex == secondSequenceIndex ||
                                currentIndexToCheck == nextIndex)
                            {
                                continue;
                            }

                            if (firstStuckNumbers == stuckNumbers)
                            {
                                isFound = true;
                                Console.WriteLine(
                                    "{0}|{1}=={2}|{3}",
                                    sequence[firstSequenceIndex],
                                    sequence[secondSequenceIndex],
                                    sequence[currentIndexToCheck],
                                    sequence[nextIndex]);
                            }
                            else if (swappedFirstStuckNumbers == stuckNumbers)
                            {
                                isFound = true;
                                Console.WriteLine(
                                    "{0}|{1}=={2}|{3}",
                                    sequence[secondSequenceIndex],
                                    sequence[firstSequenceIndex],
                                    sequence[currentIndexToCheck],
                                    sequence[nextIndex]);
                            }
                        }
                    }
                }
            }

            return isFound;
        }
    }
}
