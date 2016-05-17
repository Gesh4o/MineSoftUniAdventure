namespace _11.CouplesFrequency
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CouplesFrequencyMain
    {
        public static void Main(string[] args)
        {
            int[] array =
                Console.ReadLine()
                    .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            Dictionary<int[], int> couples = new Dictionary<int[], int>();

            FindAllCuplesAndDuplicates(array, couples);

            foreach (KeyValuePair<int[], int> coupleByOccurrence in couples)
            {
                Console.WriteLine("{0} {1} -> {2:F2}%", coupleByOccurrence.Key[0], coupleByOccurrence.Key[1], (coupleByOccurrence.Value * 1.0 / (array.Length - 1))* 100.00);
            }
        }

        private static void FindAllCuplesAndDuplicates(int[] array, Dictionary<int[], int> couples)
        {
            for (int currentIndex = 0; currentIndex < array.Length - 1; currentIndex++)
            {
                int currentCoupleFirstElement = array[currentIndex];
                int currentCoupleSecondElement = array[currentIndex + 1];

                if (couples.Any(c => c.Key[0] == currentCoupleFirstElement && c.Key[1] == currentCoupleSecondElement))
                {
                    continue;
                }
                else
                {
                    couples.Add(new[] { currentCoupleFirstElement, currentCoupleSecondElement }, 1);
                }

                FindDuplicates(array, couples, currentIndex, currentCoupleFirstElement, currentCoupleSecondElement);
            }
        }

        private static void FindDuplicates(
            int[] array,
            Dictionary<int[], int> couples,
            int currentIndex,
            int currentCoupleFirstElement,
            int currentCoupleSecondElement)
        {
            for (int nextIndex = currentIndex + 1; nextIndex < array.Length - 1; nextIndex++)
            {
                int nextCoupleFirstElement = array[nextIndex];
                int nextCoupleSecondElement = array[nextIndex + 1];

                if (currentCoupleFirstElement == nextCoupleFirstElement && currentCoupleSecondElement == nextCoupleSecondElement)
                {
                    if (couples.Any(c => c.Key[0] == currentCoupleFirstElement && c.Key[1] == currentCoupleSecondElement))
                    {
                        var couple =
                            couples.First(c => c.Key[0] == currentCoupleFirstElement && c.Key[1] == currentCoupleSecondElement);
                        couples[couple.Key]++;
                    }
                }
            }
        }
    }
}
