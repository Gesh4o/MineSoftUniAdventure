namespace _02.FractionCalculator
{
    using System;
    using System.Numerics;

    public struct Fraction
    {
        private long numerator;
        private long denominator;

        public Fraction(long numerator, long denominator) : this()
        {
            this.Numerator = numerator;
            this.denominator = denominator;
        }

        public long Numerator
        {
            get
            {
                return this.numerator;
            }

            set
            {
                if (!this.CheckLegitimacy(value))
                {
                    throw new ArgumentOutOfRangeException(string.Format("Numarator must be in range [{0},{1}]", long.MinValue, long.MaxValue));
                }

                this.numerator = value;
            }
        }

        public long Denominator
        {
            get
            {
                return this.denominator;
            }

            set
            {
                bool isZero = value == 0;
                if (!this.CheckLegitimacy(value) || isZero)
                {
                    if (isZero)
                    {
                        throw new InvalidOperationException("Cannot devide by 0!");
                    }

                    throw new ArgumentOutOfRangeException(string.Format("denominator must be in range [{0},0)(0,{1}]!", long.MinValue, long.MaxValue));
                }

                this.denominator = value;
            }
        }

        public static Fraction operator +(Fraction frac1, Fraction frac2)
        {
            // Code is left so it can values be calculate and probably used later on.
            // Or I could start with validation then continuing with logic.
            BigInteger lcm = FindLCM(frac1.denominator, frac2.denominator);
            BigInteger firstNumerator = frac1.numerator * (lcm / frac1.denominator);
            BigInteger secondNumerator = frac2.numerator * (lcm / frac2.denominator);
            BigInteger sum = firstNumerator + secondNumerator;
            if (sum > long.MaxValue || sum < long.MinValue || lcm > long.MaxValue || lcm < long.MinValue)
            {
                throw new ArgumentOutOfRangeException("Fractions' numerators or denominators are either too big or too small!");
            }

            Fraction result = new Fraction((long)sum, (long)lcm);
            return result;
        }

        public override string ToString()
        {
            return (this.numerator / (this.denominator*1.0M)).ToString();
        }

        private static BigInteger FindLCM(long a, long b)
        {
            long num1 = a;
            long num2 = b;
            if (a < b)
            {
                long num = a;
                a = b;
                b = num;
            }

            for (long i = 1; i <= num2; i++)
            {
                BigInteger possibleLCM = num1 * i;
                if (possibleLCM % num2 == 0)
                {
                    return possibleLCM;
                }
            }

            return num2;
        }

        private bool CheckLegitimacy(long currentValue)
        {
            if (currentValue < long.MinValue || currentValue > long.MaxValue)
            {
                return false;
            }

            return true;
        }
    }
}
