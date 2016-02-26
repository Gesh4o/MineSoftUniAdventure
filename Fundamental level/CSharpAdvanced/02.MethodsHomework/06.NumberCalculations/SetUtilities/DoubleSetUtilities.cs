namespace _06.NumberCalculations.SetUtilities
{
    public static class DoubleSetUtilities
    {
        public static double GetMaxElement(double[] sequence)
        {
            double maxElement = double.MinValue;

            foreach (double element in sequence)
            {
                if (element > maxElement)
                {
                    maxElement = element;
                }
            }

            return maxElement;
        }

        public static double GetMinElement(double[] sequence)
        {
            double minElement = double.MaxValue;

            foreach (double element in sequence)
            {
                if (element < minElement)
                {
                    minElement = element;
                }
            }

            return minElement;
        }

        public static double GetSum(double[] sequence)
        {
            double sequenceSum = 0;
            checked
            {
                foreach (double element in sequence)
                {
                    sequenceSum += element;
                }

                return sequenceSum;
            }
        }

        public static double GetProduct(double[] sequence)
        {
            double sequenceProduct = 1;
            checked
            {
                foreach (double element in sequence)
                {
                    sequenceProduct *= element;
                }

                return sequenceProduct;
            }
        }

        public static double GetAvarage(double[] sequence)
        {
            double sequenceSum = GetSum(sequence);
            double elementsCount = sequence.Length;

            double result = sequenceSum / elementsCount;

            return result;
        }
    }
}
