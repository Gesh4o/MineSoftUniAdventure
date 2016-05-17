namespace _03.CategorizeNumber
{
    using System;
    using System.Linq;

    public class CategorizeNumberMain
    {
        public static void Main(string[] args)
        {
            double[] array =
                Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

            int[] intArray = array.Where(num => num == (int)num).Select(num => (int)num).ToArray();

            double[] floatingPointArray = array.Where(num => num != (int)num).ToArray();

            var intArrayString = BuildIntArrayString(intArray);

            var floatingPointArrayString = BuildFloatingPointArrayString(floatingPointArray);

            Console.WriteLine(floatingPointArrayString);
            Console.WriteLine();
            Console.WriteLine(intArrayString);
        }

        private static string BuildIntArrayString(int[] intArray)
        {
            string intArrayString = string.Format(
                "[{0}] -> min: {1}, max: {2}, sum: {3}, avg: {4}",
                string.Join(", ", intArray),
                intArray.Min(),
                intArray.Max(),
                intArray.Sum(),
                intArray.Average().ToString("f2"));
            return intArrayString;
        }

        private static string BuildFloatingPointArrayString(double[] floatingPointArray)
        {
            string floatingPointArrayString = string.Format(
                "[{0}] -> min: {1:F2}, max: {2:F2}, sum: {3:F2}, avg: {4:F2}",
                string.Join(", ", floatingPointArray),
                floatingPointArray.Min(),
                floatingPointArray.Max(),
                floatingPointArray.Sum(),
                floatingPointArray.Average());
            return floatingPointArrayString;
        }
    }
}
