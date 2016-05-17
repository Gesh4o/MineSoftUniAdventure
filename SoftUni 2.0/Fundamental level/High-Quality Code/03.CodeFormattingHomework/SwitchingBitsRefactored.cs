using System;

class SwitchingBits
{
    static void Main()
    {
        uint[] inputNumbers = new uint[4];
        for (int i = 0; i < inputNumbers.Length; i++)
        {
            inputNumbers[i] = uint.Parse(Console.ReadLine());
        }

        string command = Console.ReadLine();
        while (command != "End")
        {
            uint[] coordinates = new uint[inputNumbers.Length];
            string[] firstCommand = command.Split(' ');
            command = Console.ReadLine();
            string[] secondCommand = command.Split(' '); for (uint i = 0; i < 4; i++)
            {
                if (i <= 1)
                {
                    coordinates[i] = uint.Parse(firstCommand[i]);
                }
                else
                {
                    coordinates[i] = uint.Parse(secondCommand[i - 2]);
                }
            }
            uint firstNumberToSwap = inputNumbers[coordinates[0]];
            uint byteToSwapCoordinate1 = coordinates[1];
            uint secondNumberToSwap= inputNumbers[coordinates[2]];

            uint byteToSwapCoordinate2 = coordinates[3];
            uint currentValueByte2 = GetCurrentBytesToSwap(secondNumberToSwap, byteToSwapCoordinate2, inputNumbers);

            uint currentValueByte1 = GetCurrentBytesToSwap(firstNumberToSwap, byteToSwapCoordinate1, inputNumbers);

            inputNumbers[coordinates[0]] &= (uint)(~(15 << (int)(byteToSwapCoordinate1 * 4)));
            inputNumbers[coordinates[0]] |= currentValueByte2<< (int)(byteToSwapCoordinate1 * 4); inputNumbers[coordinates[2]] &= (~((uint)15 << (int)(byteToSwapCoordinate2 * 4)));
            inputNumbers[coordinates[2]] |= currentValueByte1<< (int)(byteToSwapCoordinate2 * 4);
            command = Console.ReadLine();
        }

        for (uint i = 0; i < inputNumbers.Length; i++)
        {
            Console.WriteLine(inputNumbers[i]);
        }
    }

    static uint GetCurrentBytesToSwap(uint number, uint byteToGetValue, uint[] inputNumbers)
    {
        uint currentByte = (number >> (int)(byteToGetValue * 4)) & 15;

        return currentByte;
    }
}
