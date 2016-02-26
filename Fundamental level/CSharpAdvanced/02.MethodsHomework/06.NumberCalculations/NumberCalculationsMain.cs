namespace _06.NumberCalculations
{
    using System;

    using _06.NumberCalculations.SetUtilities;

    public class NumberCalculationsMain
    {
        public static void Main(string[] args)
        {
            int[] intSet = { 100, 200, 300, 400, 500 };
            double[] doubleSet = { 1.1, 1.2, 1.3, 1.4, 1.5 };
            decimal[] decimalSet = { 10.00000000000000000001M, 20.00000000000000000001M, 30.00000000000000000001M, 40.00000000000000000001M };

            ////Console.WriteLine(IntSetUtilities.GetSum(intSet));
            ////Console.WriteLine(IntSetUtilities.GetAvarage(intSet));
            ////try
            ////{
            ////    Console.WriteLine(IntSetUtilities.GetProduct(intSet));
            ////}
            ////catch (OverflowException oe)
            ////{
            ////    Console.WriteLine(oe.Message);
            ////}

            ////Console.WriteLine(DoubleSetUtilities.GetSum(doubleSet));
            ////Console.WriteLine(DoubleSetUtilities.GetAvarage(doubleSet));
            ////Console.WriteLine(DoubleSetUtilities.GetProduct(doubleSet));

            Console.WriteLine(DecimalSetUtilities.GetSum(decimalSet));
            Console.WriteLine(DecimalSetUtilities.GetAvarage(decimalSet));
            Console.WriteLine(DecimalSetUtilities.GetProduct(decimalSet));
        }
    }
}
