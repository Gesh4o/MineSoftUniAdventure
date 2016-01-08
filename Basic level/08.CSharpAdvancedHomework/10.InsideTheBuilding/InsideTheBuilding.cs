using System;

class InsideTheBuilding
{
    static void Main()
    {
        //Reading the block size h and intializing bool array.
        //The array will be used to store information about if the point is in or out the building.
        int blockSize = int.Parse(Console.ReadLine());
        bool[] isInside = new bool[5];
        for (int i = 0; i < 5; i++)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            //Splitting the building into two parts: lower part and middle(upper) part.
            //Checking if the coordinates match the building's parameters. If true- inside , if false - outside.
            if (((x >= 0 && x <= 3 * blockSize) && (y >= 0 && y <= blockSize)) || ((x >= blockSize && x <= 2 * blockSize) && (y >= blockSize && y <= 4 * blockSize)))
            {
                isInside[i] = true;
            }
            else
            {
                isInside[i] = false;
            }
        }
        for (int i = 0; i < isInside.Length; i++)
        {
            if (isInside[i] == true)
            {
                Console.WriteLine("inside");
            }
            else
            {
                Console.WriteLine("outside");
            }
        }
    }
}
