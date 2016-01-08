using System;
using System.Collections.Generic;

class RemoveNames
{
    static void Main()
    {
        string[] firstList = Console.ReadLine().Split(' ');
        string[] secondList = Console.ReadLine().Split(' ');
        bool isOnly = true;

        List<string> reworkedList = new List<string>();
        for (int firstListPos = 0; firstListPos < firstList.Length; firstListPos++)
        {
            for (int secondListPos = 0; secondListPos < secondList.Length; secondListPos++)
            {
                if (firstList[firstListPos] != secondList[secondListPos])
                {
                    isOnly = true;
                }
                else
                {
                    isOnly = false;
                    break ;
                }
            }
            if (isOnly)
            {
                reworkedList.Add(firstList[firstListPos]);
            }
            else
            {
                continue;
            }
        }
        for (int count = 0; count < reworkedList.Count; count++)
        {
            Console.Write(reworkedList[count] + " ");
        }
        Console.WriteLine();
        
    }
}
