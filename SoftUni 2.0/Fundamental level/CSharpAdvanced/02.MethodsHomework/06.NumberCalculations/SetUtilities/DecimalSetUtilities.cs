namespace _06.NumberCalculations.SetUtilities
{
    public static class DecimalSetUtilities
    {
        public static decimal GetMaxElement(decimal[] sequence)
        {
            decimal maxElement = decimal.MinValue;

            foreach (decimal element in sequence)
            {
                if (element > maxElement)
                {
                    maxElement = element;
                }
            }

            return maxElement;
        }

        public static decimal GetMinElement(decimal[] sequence)
        {
            decimal minElement = decimal.MaxValue;

            foreach (decimal element in sequence)
            {
                if (element < minElement)
                {
                    minElement = element;
                }
            }

            return minElement;
        }

        public static decimal GetSum(decimal[] sequence)
        {
            decimal sequenceSum = 0;
            checked
            {
                foreach (decimal element in sequence)
                {
                    sequenceSum += element;
                }

                return sequenceSum;
            }
        }

        public static decimal GetProduct(decimal[] sequence)
        {
            decimal sequenceProduct = 1;
            checked
            {
                foreach (decimal element in sequence)
                {
                    sequenceProduct *= element;
                }

                return sequenceProduct;
            }
        }

        public static decimal GetAvarage(decimal[] sequence)
        {
            decimal sequenceSum = GetSum(sequence);
            decimal elementsCount = sequence.Length;

            decimal result = sequenceSum / elementsCount;

            return result;
        }
    }
}
