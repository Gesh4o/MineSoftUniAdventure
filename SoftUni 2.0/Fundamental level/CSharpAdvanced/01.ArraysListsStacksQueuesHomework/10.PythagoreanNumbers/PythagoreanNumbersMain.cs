namespace _10.PythagoreanNumbers
{
    using System;

    public class PythagoreanNumbersMain
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] intArray = new int[n];

            for (int i = 0; i < n; i++)
            {
                intArray[i] = int.Parse(Console.ReadLine());
            }

            bool isFound = false;
            for (int a = 0; a < intArray.Length; a++)
            {
                int poweredA = intArray[a] * intArray[a];
                for (int b = 0; b < intArray.Length; b++)
                {
                    int poweredB = intArray[b] * intArray[b];
                    for (int c = 0; c < intArray.Length; c++)
                    {
                        int poweredC = intArray[c] * intArray[c];
                        if (intArray[a] > intArray[b] || intArray[a] > intArray[c] || intArray[b] > intArray[c])
                        {
                            continue;
                        }

                        bool isMatch = poweredA + poweredB == poweredC;
                        if (isMatch)
                        {
                            Console.WriteLine("{0}*{0} + {1}*{1} = {2}*{2}", intArray[a], intArray[b], intArray[c]);
                            isFound = true;
                        }
                    }
                }
            }

            if (!isFound)
            {
                Console.WriteLine("No");
            }

        }
    }
}
