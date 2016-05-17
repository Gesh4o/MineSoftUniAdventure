using System;
using System.Collections.Generic;

class LongestNonDecreasingSubsequence
{
    static void Main()
    {
        //Reading the input as a string array and turning it into a integer array.
        string[] inputSequence = Console.ReadLine().Split(new[] { ' ' });
        int[] inputNumbers = new int[inputSequence.Length];

        for (int i = 0; i < inputSequence.Length; i++)
        {
            inputNumbers[i] = int.Parse(inputSequence[i]);
        }

        //Creating list where sequence will be held.
        List<int> currentSequence = new List<int>();
        //List<int> longestSequence = new List<int>();

        List<int> tempCurrentList = new List<int>();
        List<int> finalCurrentList = new List<int>();
        List<int> finalFinalList = new List<int>();

        //Use nested for loops - the first one will be for the number's position
        //from which I will compare the number with the rest integers from the sequence.
        for (int startPos = 0; startPos < inputSequence.Length; startPos++)
        {
            currentSequence.Add(inputNumbers[startPos]); 
            //Everytime adding the start number to the new sequence.
            //Current sequence should held all numbers bigger than the start number.
            for (int comparePos = startPos + 1; comparePos < inputSequence.Length; comparePos++)
            {
                if (inputNumbers[startPos] < inputNumbers[comparePos])
                {
                    currentSequence.Add(inputNumbers[comparePos]);
                }
            }
            //Here we should have these values.
            //Now we have to get out the longest non-decreasing sequence from the above values.
            for (int index = 0; index < currentSequence.Count; index++)
            {
                tempCurrentList.Add(currentSequence[0]);
                int compareNumber = currentSequence[0];
                for (int i = 1; index + i < currentSequence.Count; i++)
                {
                    if (compareNumber < currentSequence[index + i])
                    {
                        tempCurrentList.Add(currentSequence[index + i]);
                        compareNumber = currentSequence[index + i];
                    }
                }
                //Now saving the longest sequence here.
                if (finalCurrentList.Count < tempCurrentList.Count)
                {
                    finalCurrentList.Clear();
                    foreach (var item in tempCurrentList)
                    {
                        finalCurrentList.Add(item);
                    }
                }
                tempCurrentList.Clear();
                //Resetting the sequence list so can other sequences can be obtain
            }
            currentSequence.Clear();
            //Resetting the main list of numbers bigger than the number with index start position.
        }
        if (finalCurrentList.Count < finalCurrentList.Count)
        {
            for (int i = 0; i < finalCurrentList.Count; i++)
            {
                finalCurrentList.Add(finalCurrentList[i]);
            }

            for (int i = 0; i < finalCurrentList.Count; i++)
            {
                Console.Write(finalCurrentList[i] + " ");
            }
            Console.WriteLine();
        }
    }
}