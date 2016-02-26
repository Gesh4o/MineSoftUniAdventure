namespace _06.NumberCalculations.SetUtilities
{
    public static class IntSetUtilities
    {
        public static int GetMaxElement(int[] sequence)
        {
            int maxElement = int.MinValue;

            foreach (int element in sequence)
            {
                if (element > maxElement)
                {
                    maxElement = element;
                }
            }

            return maxElement;
        }

        public static int GetMinElement(int[] sequence)
        {
            int minElement = int.MaxValue;

            foreach (int element in sequence)
            {
                if (element < minElement)
                {
                    minElement = element;
                }
            }

            return minElement;
        }

        public static int GetSum(int[] sequence)
        {
            int sequenceSum = 0;
            checked
            {
                foreach (int element in sequence)
                {
                    sequenceSum += element;
                }

                return sequenceSum;
            }
        }

        public static int GetProduct(int[] sequence)
        {
            int sequenceProduct = 1;
            checked
            {
                foreach (int element in sequence)
                {
                    sequenceProduct *= element;
                }

                return sequenceProduct;
            }
        }

        public static int GetAvarage(int[] sequence)
        {
            int sequenceSum = GetSum(sequence);
            int elementsCount = sequence.Length;

            int result = sequenceSum / elementsCount;

            return result;
        }
    }
}
