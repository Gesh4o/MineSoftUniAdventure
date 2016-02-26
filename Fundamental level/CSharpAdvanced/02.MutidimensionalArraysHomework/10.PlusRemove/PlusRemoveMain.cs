namespace _10.PlusRemove
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PlusRemoveMain
    {
        public static void Main(string[] args)
        {
            var allChars = new List<char[]>();
            string input = Console.ReadLine();
            List<int[]> positionsToRemove = new List<int[]>();

            ReadInput(input, allChars);

            for (int row = 0; row < allChars.Count - 2; row++)
            {
                for (int col = 0; col < allChars[row].Length; col++)
                {
                    var canBeTopOfPlus = CheckIfCanBeTopOfPlus(allChars, row, col);

                    if (canBeTopOfPlus)
                    {
                        char currentChar = allChars[row][col];
                        if (char.IsLetter(currentChar))
                        {
                            bool isPlus;
                            if (char.IsLower(currentChar))
                            {
                                isPlus = CheIfLetterIsPlus(allChars, row, col, -32);
                            }
                            else
                            {
                                isPlus = CheIfLetterIsPlus(allChars, row, col, 32);
                            }

                            if (isPlus)
                            {
                                AddPositions(positionsToRemove, row, col);
                            }
                        }
                        else
                        {
                            var isPlus = CheckIfIsPlus(allChars, row, col);

                            if (isPlus)
                            {
                                AddPositions(positionsToRemove, row, col);
                            }
                        }
                    }
                }
            }

            positionsToRemove = positionsToRemove.Distinct().ToList(); 
            var result = CreateNonPlusOutput(allChars, positionsToRemove);

            PrintResult(result);
        }

        private static void ReadInput(string input, List<char[]> allChars)
        {
            while (input != "END")
            {
                char[] splittedInput = input.ToCharArray();
                allChars.Add(splittedInput);
                input = Console.ReadLine();
            }
        }

        private static bool CheckIfCanBeTopOfPlus(List<char[]> allChars, int row, int col)
        {
            bool isLeftPartAvailable = allChars[row + 1].Length > col - 1 && col >= 1;
            bool areCenterAndRightPartAvailable = allChars[row + 1].Length - 1 > col;
            bool isBottomPartAvailable = allChars[row + 2].Length > col;
            bool canBeTopOfPlus = isLeftPartAvailable && areCenterAndRightPartAvailable && isBottomPartAvailable;
            return canBeTopOfPlus;
        }

        private static bool CheIfLetterIsPlus(List<char[]> allChars, int row, int col, int letterCaseDifference)
        {
            bool isPlus;
            char currentChar = allChars[row][col];
            bool isLeftPartEqual = allChars[row + 1][col - 1] == currentChar || allChars[row + 1][col - 1] == currentChar + letterCaseDifference;
            bool isCenterPartEqual = allChars[row + 1][col] == currentChar || allChars[row + 1][col] == currentChar + letterCaseDifference;
            bool isRightPartEqual = allChars[row + 1][col + 1] == currentChar || allChars[row + 1][col + 1] == currentChar + letterCaseDifference;
            bool isBottomPartEqual = allChars[row + 2][col] == currentChar || allChars[row + 2][col] == currentChar + letterCaseDifference;
            isPlus = isLeftPartEqual && isCenterPartEqual && isRightPartEqual && isBottomPartEqual;
            return isPlus;
        }

        private static bool CheckIfIsPlus(List<char[]> allChars, int row, int col)
        {
            char currentChar = allChars[row][col];
            bool isLeftPartEqual = allChars[row + 1][col - 1] == currentChar;
            bool isCenterPartEqual = allChars[row + 1][col] == currentChar;
            bool isRightPartEqual = allChars[row + 1][col + 1] == currentChar;
            bool isBottomPartEqual = allChars[row + 2][col] == currentChar;
            bool isPlus = isLeftPartEqual && isCenterPartEqual && isRightPartEqual && isBottomPartEqual;
            return isPlus;
        }

        private static void AddPositions(List<int[]> positionsToRemove, int row, int col)
        {
            positionsToRemove.Add(new[] { row, col }); // Top part of the plus
            positionsToRemove.Add(new[] { row + 1, col - 1 }); // Left part of the plus
            positionsToRemove.Add(new[] { row + 1, col }); // Center part of the plus
            positionsToRemove.Add(new[] { row + 1, col + 1 }); // Right part of the plus
            positionsToRemove.Add(new[] { row + 2, col }); // Bottom part of the plus
        }

        private static List<List<char>> CreateNonPlusOutput(List<char[]> allChars, List<int[]> positionsToRemove)
        {
            var result = new List<List<char>>();
            for (int row = 0; row < allChars.Count; row++)
            {
                result.Add(new List<char>());
                for (int col = 0; col < allChars[row].Length; col++)
                {
                    if (!positionsToRemove.Any(a => a[0] == row && a[1] == col))
                    {
                        result[row].Add(allChars[row][col]);
                    }
                }
            }

            return result;
        }

        private static void PrintResult(List<List<char>> result)
        {
            foreach (List<char> charRow in result)
            {
                Console.WriteLine(string.Join(string.Empty, charRow));
            }
        }
    }
}
