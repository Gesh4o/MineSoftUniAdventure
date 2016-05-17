namespace _08.LegoBlocks
{
    using System;
    using System.Linq;

    public class LegoBlocksMain
    {
        public static void Main()
        {
            int jaggedArrayRowsCount = int.Parse(Console.ReadLine());

            int[][] firstJaggedArray = new int[jaggedArrayRowsCount][];
            InitializeJaggedArrayRowsCount(jaggedArrayRowsCount, firstJaggedArray);

            int[][] secondJaggedArray = new int[jaggedArrayRowsCount][];
            InitializeJaggedArrayRowsCount(jaggedArrayRowsCount, secondJaggedArray);

            int firstRowCellCount = firstJaggedArray[0].Length + secondJaggedArray[0].Length;

            if (!CheckIfJaggedArraysFit(firstRowCellCount, firstJaggedArray, secondJaggedArray))
            {
                return;
            }

            ReverseJaggedArray(secondJaggedArray);

            int[][] mergedJaggedArray = new int[firstRowCellCount][];
            ConcatJaggedArrays(mergedJaggedArray, firstJaggedArray, secondJaggedArray);

            for (int i = 0; i < jaggedArrayRowsCount; i++)
            {
                Console.WriteLine("[{0}]", string.Join(", ", mergedJaggedArray[i]));
            }
        }

        private static void ConcatJaggedArrays(int[][] mergedJaggedArray, int[][] firstJaggedArray, int[][] secondJaggedArray)
        {
            for (int i = 0; i < firstJaggedArray.Length; i++)
            {
                mergedJaggedArray[i] = firstJaggedArray[i].Concat(secondJaggedArray[i]).ToArray();
            }
        }

        private static bool CheckIfJaggedArraysFit(
            int firstRowCellCount,
            int[][] firstJaggedArray,
            int[][] secondJaggedArray)
        {
            for (int i = 1; i < firstJaggedArray.Length; i++)
            {
                if (firstRowCellCount != firstJaggedArray[i].Length + secondJaggedArray[i].Length)
                {
                    int countOfCells = GetCellsCount(firstJaggedArray, secondJaggedArray);
                    Console.WriteLine("The total number of cells is: {0}", countOfCells);
                    return false;
                }
            }

            return true;
        }

        private static void InitializeJaggedArrayRowsCount(int jaggedArrayRowsCount, int[][] jaggedArray)
        {
            for (int rows = 0; rows < jaggedArrayRowsCount; rows++)
            {
                jaggedArray[rows] =
                    Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
            }
        }

        private static void ReverseJaggedArray(int[][] jaggedArray)
        {
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                int[] array = jaggedArray[i];
                int[] reversedArray = new int[array.Length];
                for (int index = 0; index < array.Length; index++)
                {
                    reversedArray[index] = array[array.Length - 1 - index];
                }

                jaggedArray[i] = reversedArray;
            }
        }

        private static int GetCellsCount(int[][] firstJaggedArray, int[][] secondJaggedArray)
        {
            int count = firstJaggedArray.Sum(array => array.Length);

            count += secondJaggedArray.Sum(array => array.Length);

            return count;
        }
    }
}
