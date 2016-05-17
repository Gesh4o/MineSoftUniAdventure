namespace _01.BasicOperationsTest.Tests
{
    using System;
    using System.Diagnostics;
    using System.Text;

    /// <summary>
    /// This class is used for speed testing for Int32.
    /// </summary>
    public static class IntTest
    {
        // If only I could generic these tests :((((
        private static int repeatingCount;

        /// <summary>
        /// Class used to perform test.
        /// </summary>
        /// <param name="repeatingCounter">
        /// It used as a counter of actions to be performed in every Int32 test.
        /// </param>
        /// <param name="numberToTest"></param>
        /// <param name="actionNumber"></param>
        public static string PerformTests(int repeatingCounter, int numberToTest, int actionNumber)
        {
            StringBuilder testResult = new StringBuilder();
            repeatingCount = repeatingCounter; // Partially anti-HQC.
            testResult.AppendFormat(
                "Test Int32 performed with {0} repetitions. Number used {1} for prime operations (++/+=1) and {2} for secondary operations( +, *, etc).{3}",
                repeatingCount,
                numberToTest,
                actionNumber,
                Environment.NewLine);

            string testInfo = TestInt(numberToTest, actionNumber);
            testResult.Append(testInfo);
            return testResult.ToString();
        }

        private static string TestInt(int numberToTest, int actionNumber)
        {
            // TODO: Reorder variables here.
            StringBuilder wholeTestResult = new StringBuilder();
            string testSumInfo = TestSum(numberToTest, actionNumber);
            wholeTestResult.AppendLine(testSumInfo);
            wholeTestResult.AppendLine(TestSubstraction(numberToTest, actionNumber));
            wholeTestResult.AppendLine(TestPrefix(numberToTest));
            wholeTestResult.AppendLine(TestPostfix(numberToTest));
            wholeTestResult.AppendLine(TestAddOne(numberToTest));
            wholeTestResult.AppendLine(TestPartition(numberToTest, actionNumber));
            wholeTestResult.AppendLine(TestMultiplying(numberToTest, actionNumber));
            wholeTestResult.AppendLine();

            return wholeTestResult.ToString();
        }

        private static string TestSum(int numberToTest, int actionNumber)
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

        private static string TestSubstraction(int numberToTest, int actionNumber)
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

        private static string TestPrefix(int numberToTest)
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

        private static string TestPostfix(int numberToTest)
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

        private static string TestAddOne(int numberToTest)
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

        private static string TestMultiplying(int numberToTest, int actionNumber)
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

        private static string TestPartition(int numberToTest, int actionNumber)
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
