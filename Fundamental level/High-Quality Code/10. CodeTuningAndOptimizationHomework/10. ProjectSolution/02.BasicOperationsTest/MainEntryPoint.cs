namespace _01.BasicOperationsTest
{
    using System.IO;

    using _01.BasicOperationsTest.Tests;

    /// <summary>
    /// This program is made to perform and write down the result of different number types.
    /// The results can be found in the \solutionfolder\bin\Debug\text.txt.
    /// </summary>
    public class MainEntryPoint
    {
        // The program itself break the DRY principle(Do not repeat yourself). 
        // There are available optimal options for generalization but making the test methods generic directly through interface sadly is not supported.
        // See also: http://stackoverflow.com/questions/32664/is-there-a-constraint-that-restricts-my-generic-method-to-numeric-types
        public static void Main()
        {
            // First block parameters
            const int PrimeOperationsNumber = 500;
            const int SecondaryOperationsNumber = 2;

            const int FirstCountOfRepeats = 100;
            const int SecondCountOfRepeats = 500;
            const int ThirdCountOfRepeats = 1000;

            using (StreamWriter streamWriter = new StreamWriter(@"Basic operations test information.txt", false))
            {
                // n=100
                streamWriter.Write(
                    IntTest.PerformTests(FirstCountOfRepeats, PrimeOperationsNumber, SecondaryOperationsNumber));
                streamWriter.Write(
                    LongTest.PerformTests(FirstCountOfRepeats, PrimeOperationsNumber, SecondaryOperationsNumber));
                streamWriter.Write(
                    DoubleTest.PerformTests(FirstCountOfRepeats, PrimeOperationsNumber, SecondaryOperationsNumber));
                streamWriter.Write(
                    FloatTest.PerformTests(FirstCountOfRepeats, PrimeOperationsNumber, SecondaryOperationsNumber));

                // n = 500
                streamWriter.Write(
                    IntTest.PerformTests(SecondCountOfRepeats, PrimeOperationsNumber, SecondaryOperationsNumber));
                streamWriter.Write(
                    LongTest.PerformTests(SecondCountOfRepeats, PrimeOperationsNumber, SecondaryOperationsNumber));
                streamWriter.Write(
                    DoubleTest.PerformTests(SecondCountOfRepeats, PrimeOperationsNumber, SecondaryOperationsNumber));
                streamWriter.Write(
                    FloatTest.PerformTests(SecondCountOfRepeats, PrimeOperationsNumber, SecondaryOperationsNumber));

                // n = 1000
                streamWriter.Write(
                    IntTest.PerformTests(ThirdCountOfRepeats, PrimeOperationsNumber, SecondaryOperationsNumber));
                streamWriter.Write(
                    LongTest.PerformTests(ThirdCountOfRepeats, PrimeOperationsNumber, SecondaryOperationsNumber));
                streamWriter.Write(
                    DoubleTest.PerformTests(ThirdCountOfRepeats, PrimeOperationsNumber, SecondaryOperationsNumber));
                streamWriter.Write(
                    FloatTest.PerformTests(ThirdCountOfRepeats, PrimeOperationsNumber, SecondaryOperationsNumber));
            }
        }
    }
}
