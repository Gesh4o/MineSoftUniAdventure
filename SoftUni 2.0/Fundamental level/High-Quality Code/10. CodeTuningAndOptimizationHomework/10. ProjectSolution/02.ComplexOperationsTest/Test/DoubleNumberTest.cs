namespace _02.ComplexOperationsTest.Test
{
    using System;
    using System.Diagnostics;
    using System.Text;

    public static class DoubleNumberTest
    {
        public static string PerformTests(double number, int count)
        {
            StringBuilder wholeTestInformation = new StringBuilder();
            wholeTestInformation.AppendFormat(
                "Test performed with double integer type-used variables:{2}{0} for calculation operations and {1} for count of number of operations to be done in each individual test.{2}{3}{2}",
                number,
                count,
                Environment.NewLine,
                new string('-', 20));

            string squareRootTestInformation = CalculateSquareRootTest(number, count);
            wholeTestInformation.Append(squareRootTestInformation);

            string logarithmTestInformation = LogarithmTest(number, count);
            wholeTestInformation.Append(logarithmTestInformation);

            string sineTestInformation = SineTest(number, count);
            wholeTestInformation.Append(sineTestInformation);

            wholeTestInformation.AppendLine();
            return wholeTestInformation.ToString();
        }

        private static string SineTest(double number, int count)
        {
            StringBuilder testInfo = new StringBuilder();
            testInfo.Append("Sine: ");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < count; i++)
            {
                double result = Math.Log(number);
            }

            stopwatch.Stop();
            testInfo.AppendLine(stopwatch.Elapsed.ToString());

            return testInfo.ToString();
        }

        private static string LogarithmTest(double number, int count)
        {
            StringBuilder testInfo = new StringBuilder();
            testInfo.Append("Logarithm: ");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < count; i++)
            {
                double result = Math.Log(number);
            }

            stopwatch.Stop();
            testInfo.AppendLine(stopwatch.Elapsed.ToString());

            return testInfo.ToString();
        }

        private static string CalculateSquareRootTest(double number, int count)
        {
            StringBuilder testInfo = new StringBuilder();
            testInfo.Append("Square root: ");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < count; i++)
            {
                double result = Math.Sqrt(number);
            }

            stopwatch.Stop();
            testInfo.AppendLine(stopwatch.Elapsed.ToString());

            return testInfo.ToString();
        }
    }
}
