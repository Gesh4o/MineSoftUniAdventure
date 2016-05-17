using System;

class ExchangeBitsAdvanced
{
    static void Main()
    {
        //Reading the input from the console
        Console.Write("Enter number: ");
        uint number = uint.Parse(Console.ReadLine());
        Console.Write("Enter p: ");
        int p = int.Parse(Console.ReadLine());
        Console.Write("Enter q: ");
        int q = int.Parse(Console.ReadLine());
        Console.Write("Enter k: ");
        int k = int.Parse(Console.ReadLine());

        //Catching exeptions for overflow and overlap
        if (Math.Max(p, q) + k > 32)
        {
            Console.WriteLine("Out of range");
            return;
        }
        else if(Math.Min(p, q) + k > Math.Max(p, q))
        {
            Console.WriteLine("Overlapping");
            return;
        }

        int counter = q;
        for(int i = p; i<=p+k-1;i++)
        {

            uint firstBits = (uint)((1 << i) & number) >> i;//Get bit p

            uint secondBits = (uint)((1 << counter) & number) >> counter;//Get bit q

            number = (uint)(number & ~(1 << i));//Convert bit p to 0

            number = (uint)(number & ~(1 << counter));//Convert bit q to 0

            number = number | (secondBits << i);//Replace bit p with q

            number = number | (firstBits << counter);//Replace bit q with p

            counter++;
        }
        Console.WriteLine(number);

    }
}