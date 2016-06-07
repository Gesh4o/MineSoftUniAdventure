namespace _11.EqualElements
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class EqualMain
    {
        public static void Main(string[] args)
        {
            BigInteger[] sequence = Console.ReadLine()
                   .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(BigInteger.Parse)
                   .ToArray();

            int index = -1;

            if (sequence.Length == 1)
            {
                Console.WriteLine(0);
            }
            else
            {
                for (int numberIndex = 1; numberIndex < sequence.Length; numberIndex++)
                {
                    BigInteger leftSum = 0;
                    for (int leftIndex = numberIndex - 1; leftIndex >= 0; leftIndex--)
                    {
                        leftSum += sequence[leftIndex];    
                    }

                    BigInteger rightSum = 0;
                    for (int rightIndex = numberIndex + 1; rightIndex < sequence.Length; rightIndex++)
                    {
                        rightSum += sequence[rightIndex];
                    }

                    if (rightSum == leftSum)
                    {
                        index = numberIndex;
                        break;
                    }
                }

                if (index != -1)
                {
                    Console.WriteLine(index);
                }
                else
                {
                    Console.WriteLine("no");
                }
            }
        }
    }
}
