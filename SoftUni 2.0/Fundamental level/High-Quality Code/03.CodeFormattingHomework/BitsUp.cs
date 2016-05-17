using System;
using System.Numerics;

class BitsUp
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());
        int index = 0;
        for (int i = 0; i < n; i++)
        {
            int num = int.Parse(Console.ReadLine());
            for (int bit = 7; bit >= 0; bit--)
            {
                if ((index % step == 1) || (step == 1 && index > 0))
                {
                    num = num | (1 << bit);
                }
                index++;
            }
            Console.WriteLine(num);
        }
        return;
        int bytesCount = int.Parse(Console.ReadLine());

        //int step = int.Parse(Console.ReadLine());

        string[] numbers = new string[bytesCount];

        for (int i = 0; i < bytesCount; i++)
        {
            int number = int.Parse(Console.ReadLine());
            numbers[i] = Convert.ToString(number, 2).PadLeft(8,'0');
        }
        string connectedNumber = string.Join("", numbers);

        //long convertedDecimalNumber = Convert.ToInt64(connectedNumber, 2);
        BigInteger largeNumber = BigInteger.Parse(connectedNumber);
        string convertedNum = largeNumber.ToString();
        long convertedDecimalNumber = long.Parse(convertedNum);

        for (int i = 1; i < bytesCount*8;)
        {
            convertedDecimalNumber = convertedDecimalNumber | ((long)1 << (bytesCount*8 - i)-1);
            i += step;
        }
        string answer = (Convert.ToString(convertedDecimalNumber,2).PadLeft(bytesCount*8,'0'));

        string finalAnswer = string.Empty;

        for (int i = 0; i < bytesCount*8; i+=8)
        {
            finalAnswer = string.Empty;
            for (int j = i; j < i+8; j++)
            {
                finalAnswer+= answer[j];
            }
            Console.WriteLine(Convert.ToInt32(finalAnswer,2).ToString());
        }
    }
}