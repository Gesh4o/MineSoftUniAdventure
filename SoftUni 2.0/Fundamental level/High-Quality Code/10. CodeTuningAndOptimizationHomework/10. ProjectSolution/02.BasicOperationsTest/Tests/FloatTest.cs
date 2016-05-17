namespace _01.BasicOperationsTest.Tests
{
    using System;
    using System.Diagnostics;
    using System.Text;

    /// <summary>
    /// This class is used for speed testing for float64.
    /// </summary>
    public static class FloatTest
    {
        private static float repeatingCount;

        /// <summary>
        /// Class used to perform test.
        /// </summary>
        /// <param name="repeatingCounter">
        /// It used as a counter of actions to be performed in every float64 test.
        /// </param>
        /// <param name="numberToTest">Used for prime operations.</param>
        /// <param name="actionNumber">Used for secondary operations.</param>
        public static string PerformTests(float repeatingCounter, float numberToTest, float actionNumber)
        {
            StringBuilder testResult = new StringBuilder();
            repeatingCount = repeatingCounter;
            testResult.AppendFormat(
                "Test with floating type number- float performed with {0} repetitions. Number used {1} for prime operations (++/+=1) and {2} for secondary operations( +, *, etc).{3}",
                repeatingCount,
                numberToTest,
                actionNumber,
                Environment.NewLine);
            string testInfo = TestFloat(numberToTest, actionNumber);
            testResult.Append(testInfo);
            return testResult.ToString();
        }

        private static string TestFloat(float numberToTest, float actionNumber)
        {
            StringBuilder wholeTestResult = new StringBuilder();
            wholeTestResult.AppendLine(TestSum(numberToTest, actionNumber));
            wholeTestResult.AppendLine(TestSubstraction(numberToTest, actionNumber));
            wholeTestResult.AppendLine(TestPrefix(numberToTest));
            wholeTestResult.AppendLine(TestPostfix(numberToTest));
            wholeTestResult.AppendLine(TestAddOne(numberToTest));
            wholeTestResult.AppendLine(TestPartition(numberToTest, actionNumber));
            wholeTestResult.AppendLine(TestMultiplying(numberToTest, actionNumber));
            wholeTestResult.AppendLine();

            return wholeTestResult.ToString();
        }

        private static string TestSum(float numberToTest, float actionNumber)
        {
            StringBuilder partialTestResult = new StringBuilder();
            Stopwatch stopwatch = new Stopwatch();
            partialTestResult.Append("Summing: ");
            stopwatch.Start();
            for (int i = 0; i < repeatingCount; i++)
            {
                numberToTest = numberToTest + actionNumber;
            }

            stopwatch.Stop();
            partialTestResult.Append(stopwatch.Elapsed);

            return partialTestResult.ToString();
        }

        private static string TestSubstraction(float numberToTest, float actionNumber)
        {
            Stopwatch stopwatch = new Stopwatch();
            StringBuilder partialTestResult = new StringBuilder();
            partialTestResult.Append("Substraction: ");
            stopwatch.Start();
            for (int i = 0; i < repeatingCount; i++)
            {
                numberToTest = numberToTest + actionNumber;
            }

            stopwatch.Stop();
            partialTestResult.Append(stopwatch.Elapsed);

            return partialTestResult.ToString();
        }

        private static string TestPrefix(float numberToTest)
        {
            Stopwatch stopwatch = new Stopwatch();
            StringBuilder partialTestResult = new StringBuilder();
            partialTestResult.Append("Prefixing: ");
            stopwatch.Start();
            for (int i = 0; i < repeatingCount; i++)
            {
                ++numberToTest;
            }

            stopwatch.Stop();
            partialTestResult.Append(stopwatch.Elapsed);

            return partialTestResult.ToString();
        }

        private static string TestPostfix(float numberToTest)
        {
            Stopwatch stopwatch = new Stopwatch();
            StringBuilder partialTestResult = new StringBuilder();
            partialTestResult.Append("Postfixing: ");
            stopwatch.Start();
            for (int i = 0; i < repeatingCount; i++)
            {
                numberToTest++;
            }

            stopwatch.Stop();
            partialTestResult.Append(stopwatch.Elapsed);

            return partialTestResult.ToString();
        }

        private static string TestAddOne(float numberToTest)
        {
            Stopwatch stopwatch = new Stopwatch();
            StringBuilder partialTestResult = new StringBuilder();
            partialTestResult.Append("Adding one: ");
            stopwatch.Start();
            for (int i = 0; i < repeatingCount; i++)
            {
                numberToTest += 1;
            }

            stopwatch.Stop();
            partialTestResult.Append(stopwatch.Elapsed);

            return partialTestResult.ToString();
        }

        private static string TestMultiplying(float numberToTest, float actionNumber)
        {
            Stopwatch stopwatch = new Stopwatch();
            StringBuilder partialTestResult = new StringBuilder();
            partialTestResult.Append("Multiplying: ");
            stopwatch.Start();
            for (int i = 0; i < repeatingCount; i++)
            {
                numberToTest = numberToTest * actionNumber;
            }

            stopwatch.Stop();
            partialTestResult.Append(stopwatch.Elapsed);

            return partialTestResult.ToString();
        }

        private static string TestPartition(float numberToTest, float actionNumber)
        {
            Stopwatch stopwatch = new Stopwatch();
            StringBuilder partialTestResult = new StringBuilder();
            partialTestResult.Append("Partition: ");
            stopwatch.Start();
            for (int i = 0; i < repeatingCount; i++)
            {
                numberToTest = numberToTest / actionNumber;
            }

            stopwatch.Stop();
            partialTestResult.Append(stopwatch.Elapsed);

            return partialTestResult.ToString();
        }
    }
}
