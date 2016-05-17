using System;

class ProgrammerDNA
{
    static void Main()
    {
        //Used help from "Авторско решение" for this one.
        int height = int.Parse(Console.ReadLine());
        char startingChar = char.Parse(Console.ReadLine());

        int diff = 0;
        int diffCount = 0;
        int midpoint = 7 / 2;
        int blockSize = 7;
        char point = '.';

        for (int rows = 0; rows < height; rows++)
        {
            for (int i = 0; i < blockSize; i++)
            {
                if (i >= midpoint - diff && i <= midpoint + diff)
                {
                    Console.Write(startingChar);
                    if (startingChar == 'G')
                    {
                        startingChar = ('A');
                    }
                    else
                    {
                        startingChar++;
                    }
                }

                else
                {
                    Console.Write(point);
                }
            }
            if (diffCount >= midpoint)
            {
                diff--;
            }
            else
            {
                diff++;
            }
            diffCount++;
            if (diffCount == blockSize)
            {
                diffCount = 0;
                diff++;
            }
            Console.WriteLine();
        }
    }
}