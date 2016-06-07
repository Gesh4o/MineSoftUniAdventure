namespace _02.MatrixOfPalindromes
{
    using System;
    using System.Linq;

    public class MatrixOfPalindromesMain
    {
        public static void Main(string[] args)
        {
            int[] rowAndCol = Console.ReadLine()
                            .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();
            for (int row = 'a'; row < 'a' + rowAndCol[0]; row++)
            {
                for (int col = row; col < row + rowAndCol[1]; col++)
                {
                    Console.Write("{0}{1}{0} ", (char)row, (char)col);
                }

                Console.WriteLine();
            }
        }
    }
}
