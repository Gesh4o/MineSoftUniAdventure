using System;
using System.Collections.Generic;

class JoinLists
{
    static void Main()
    {
        //Reading the input as string then turning it into integer array
        string[] firstInput = Console.ReadLine().Split(' ');
        int[] firstList = new int[firstInput.Length];
        for (int i = 0; i < firstInput.Length; i++)
        {
            firstList[i] = int.Parse(firstInput[i]);
        }

        string[] secondInput = Console.ReadLine().Split(' ');
        int[] secondList = new int[secondInput.Length];
        for (int i = 0; i < secondInput.Length; i++)
        {
            secondList[i] = int.Parse(secondInput[i]);
        }

        //Creating list which gathers the first and second string.
        List<int> combinedList = new List<int>();
        for (int i = 0; i < firstInput.Length; i++)
        {
            combinedList.Add(firstList[i]);
        }
        for (int i = 0; i < secondInput.Length; i++)
        {
            combinedList.Add(secondList[i]);
        }
        bool isOnly = true;
        //Removing the repeatative elements and adding them into new list
        List<int> combinedListNoRepeat = new List<int>();
        for (int startPos = 0; startPos < combinedList.Count; startPos++)
        {
            for (int comparedPos = startPos + 1; comparedPos < combinedList.Count; comparedPos++)
            {
                if (combinedList[startPos] == combinedList[comparedPos])
                {
                    isOnly = false;
                    break;
                }
                else
                {
                    isOnly = true;
                    continue;
                }
            }
            if (isOnly == true)
            {
                combinedListNoRepeat.Add(combinedList[startPos]);
            }
            //If the inputs have only one value it should be added through this logic.
            if (combinedListNoRepeat.Count == 0)
            {
                combinedListNoRepeat.Add(combinedList[startPos]);
            }
        }
        combinedListNoRepeat.Sort();
        for (int i = 0; i < combinedListNoRepeat.Count; i++)
        {
            Console.Write(combinedListNoRepeat[i]+"  ");
        }
        Console.WriteLine();
    }
}