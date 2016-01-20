namespace _01.ComparingSortAlgorithms
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Text;

    public class EntryPoint
    {
        public static void Main()
        {
            const int ArrayLength = 10000000;
            int[] originalArray = new int[ArrayLength];
            Random rnd = new Random();
            for (int i = 0; i < ArrayLength; i++)
            {
                originalArray[i] = rnd.Next(0, ArrayLength);
            }

            int[] firstCopy = originalArray;
            int[] secondCopy = originalArray;
            int[] thirdCopy = originalArray;

            Stopwatch stopwatch = new Stopwatch();
            StringBuilder data = new StringBuilder();
            data.AppendFormat(
                "Time to sort an array with {0} elements using Insertion sort algorithm:{1}",
                ArrayLength,
                Environment.NewLine);

            stopwatch.Start();
            SortingAlgorithms.PerformInsertionSort(firstCopy);
            stopwatch.Stop();

            data.AppendLine(stopwatch.Elapsed.ToString());
            stopwatch.Reset();

            ////data.AppendFormat(
            ////    "Time to sort an array with {0} elements using Selection sort algorithm:{1}",
            ////    ArrayLength,
            ////    Environment.NewLine);

            ////stopwatch.Start();
            ////SortingAlgorithms.PerformSelectSort(secondCopy);
            ////stopwatch.Stop();

            ////data.AppendLine(stopwatch.Elapsed.ToString());
            ////stopwatch.Reset();

            data.AppendFormat(
                "Time to sort an array with {0} elements using Merge sort algorithm:{1}",
                ArrayLength,
                Environment.NewLine);

            stopwatch.Start();
            SortingAlgorithms.PerformMergeSort(thirdCopy, 0, ArrayLength - 1);
            stopwatch.Stop();

            data.AppendLine(stopwatch.Elapsed.ToString());
            stopwatch.Reset();

            data.AppendFormat(
                "Time to sort an array with {0} elements using Quick sort algorithm:{1}",
                ArrayLength,
                Environment.NewLine);

            stopwatch.Start();
            SortingAlgorithms.PerformQuicksort(originalArray, 0, ArrayLength - 1);
            stopwatch.Stop();

            data.AppendLine(stopwatch.Elapsed.ToString());
            stopwatch.Reset();

            data.AppendLine(new string('-', 25));
            data.AppendLine();

            ValidateAlgorithmSort(firstCopy, secondCopy, thirdCopy, originalArray);
            using (StreamWriter streamWriter = new StreamWriter("Algorithm data.txt", true))
            {
                streamWriter.Write(data.ToString());
            }
        }

        private static void ValidateAlgorithmSort(int[] firstCopy, int[] secondCopy, int[] thirdCopy, int[] originalArray)
        {
            int arrayLength = firstCopy.Length;

            for (int i = 0; i < arrayLength - 1; i++)
            {
                if (firstCopy[i] <= firstCopy[i + 1])
                {
                    continue;
                }

                Console.WriteLine("First copy not sorted!");
                break;
            }

            for (int i = 0; i < arrayLength - 1; i++)
            {
                if (secondCopy[i] <= secondCopy[i + 1])
                {
                    continue;
                }

                Console.WriteLine("Second copy not sorted!");
                break;
            }

            for (int i = 0; i < arrayLength - 1; i++)
            {
                if (thirdCopy[i] <= thirdCopy[i + 1])
                {
                    continue;
                }

                Console.WriteLine("Third copy not sorted!");
                break;
            }

            for (int i = 0; i < arrayLength - 1; i++)
            {
                if (originalArray[i] <= originalArray[i + 1])
                {
                    continue;
                }

                Console.WriteLine("Original array not sorted!");
                break;
            }
        }
    }
}
