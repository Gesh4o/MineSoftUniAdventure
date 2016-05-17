using System;
using System.Collections.Generic;
using System.Linq;


class StudentCables
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int joinedDifference = 0;

        List<int> cables = new List<int>();
        for (int i = 0; i < n; i++)
        {
            int partCableLength = int.Parse(Console.ReadLine());
            string partCableMeasure = Console.ReadLine();
            if (partCableMeasure == "centimeters" && partCableLength <20)
            {
                continue;
            }
            else if (partCableMeasure == "meters")
            {
                cables.Add(partCableLength * 100);
            }
            else
            {
                cables.Add(partCableLength);
            }
            joinedDifference++;
        }
        int cableSum = cables.Sum() - (joinedDifference-1)*3;
        int studentCables = cableSum / 504;
        int leftOver = cableSum - (studentCables * 504);

        Console.WriteLine(studentCables);
        Console.WriteLine(leftOver);


    }
}