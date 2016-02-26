
namespace _16.LittleJohn
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class LittleJohnMain
    {
        public static void Main(string[] args)
        {
            StringBuilder input = new StringBuilder();
            const int InputLinesCount = 4;
            for (int row = 0; row < InputLinesCount; row++)
            {
                input.AppendLine(Console.ReadLine());
            }

            Regex biggestArrowRegex = new Regex("((>>>----->>))");
            int largeArrowsCount = biggestArrowRegex.Matches(input.ToString()).Count;
            string result = biggestArrowRegex.Replace(input.ToString(), "|");

            Regex mediumArrowRegex = new Regex("((>>----->))");
            int mediumArrowsCount = mediumArrowRegex.Matches(result).Count;
            result = mediumArrowRegex.Replace(result, "|");

            Regex smallArrowRegex = new Regex("((>----->))");
            int smallArrowsCount = smallArrowRegex.Matches(result).Count;


            string initialNumber = string.Empty + smallArrowsCount + string.Empty + mediumArrowsCount + string.Empty + largeArrowsCount;
            string initialNumberToBinary = Convert.ToString(int.Parse(initialNumber), 2);
            string initialNumberToBinaryReversed = string.Join(
                string.Empty,
                initialNumberToBinary.ToCharArray().Reverse().ToList());
            string endResultInBinary = initialNumberToBinary + initialNumberToBinaryReversed;
            Console.WriteLine(Convert.ToInt32(endResultInBinary, 2));
        }
    }
}
