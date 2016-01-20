namespace _02.ComplexOperationsTest
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using _02.ComplexOperationsTest.Test;

    public class MainEntryPoint
    {
        public static void Main(string[] args)
        {
            // First block parameters
            const int PrimeOperationsNumber = 500;

            const int FirstCountOfRepeats = 100;
            const int SecondCountOfRepeats = 500;
            const int ThirdCountOfRepeats = 1000;

            using (StreamWriter streamWriter = new StreamWriter(@"Complex operations test information.txt", false))
            {
                // n = 100
                streamWriter.Write(
                    DoubleNumberTest.PerformTests(PrimeOperationsNumber, FirstCountOfRepeats));
                streamWriter.Write(
                    DecimalNumberTest.PerformTests(PrimeOperationsNumber, FirstCountOfRepeats));

                // n = 500
                streamWriter.Write(
                    DoubleNumberTest.PerformTests(PrimeOperationsNumber, SecondCountOfRepeats));
                streamWriter.Write(
                    DecimalNumberTest.PerformTests(PrimeOperationsNumber, SecondCountOfRepeats));

                // n = 1000
                streamWriter.Write(
                    DoubleNumberTest.PerformTests(PrimeOperationsNumber, ThirdCountOfRepeats));
                streamWriter.Write(
                    DecimalNumberTest.PerformTests(PrimeOperationsNumber, ThirdCountOfRepeats));
            }
        }
    }
}
