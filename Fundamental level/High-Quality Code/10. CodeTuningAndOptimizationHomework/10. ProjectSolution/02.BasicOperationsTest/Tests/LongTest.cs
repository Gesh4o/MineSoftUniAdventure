namespace _01.BasicOperationsTest.Tests
{
    using System;
    using System.Diagnostics;
    using System.Text;

    /// <summary>
    /// This class is used for speed testing for long64.
    /// </summary>
    public static class LongTest
    {
        private static long repeatingCount;

        /// <summary>
        /// Class used to perform test.
        /// </summary>
        /// <param name="repeatingCounter">
        /// It used as a counter of actions to be performed in every long64 test.
        /// </param>
        /// <param name="numberToTest">Used for prime operations.</param>
        /// <param name="actionNumber">Used for secondary operations.</param>
        public static string PerformTests(long repeatingCounter, long numberToTest, long actionNumber)
        {
            StringBuilder testResult = new StringBuilder();
            repeatingCount = repeatingCounter;
            testResult.AppendFormat(
                "Test with Long64 number performed with {0} repetitions. Number used {1} for prime operations (++/+=1) and {2} for secondary operations( +, *, etc).{3}",
                repeatingCount,
                numberToTest,
                actionNumber,
                Environment.NewLine);
            string testInfo = TestLong(numberToTest, actionNumber);
            testResult.Append(testInfo);
            return testResult.ToString();
        }

        private static string TestLong(long numberToTest, long actionNumber)
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

        private static string TestSum(long numberToTest, long actionNumber)
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

        private static string TestSubstraction(long numberToTest, long actionNumber)
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

        private static string TestPrefix(long numberToTest)
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

        private static string TestPostfix(long numberToTest)
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

        private static string TestAddOne(long numberToTest)
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

        private static string TestMultiplying(long numberToTest, long actionNumber)
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

        private static string TestPartition(long numberToTest, long actionNumber)
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
