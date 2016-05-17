namespace _02.InterestCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class InterestCalculator
    {
        private decimal sum;
        private double persantageInterest;
        private byte years;
        private const int upperBoundary = 20;

        public InterestCalculator(decimal sum, double persantageInterest, byte years, InterestCalculationDelegate del)
        {
            this.Sum = sum;
            this.PersantageInterest = persantageInterest;
            this.Years = years;
            this.Del = del; 
        }

        public decimal Sum
        {
            get
            {
                return this.sum;
            }

            set
            {
                Validation.CheckIsNumberNotNegative(value, nameof(sum));

                this.sum = value;
            }
        }

        public double PersantageInterest
        {
            get
            {
                return this.persantageInterest;
            }

            set
            {
                Validation.CheckIsNumberNotNegative(value, nameof(persantageInterest));

                this.persantageInterest = value;
            }
        }

        public byte Years
        {
            get
            {
                return this.years;
            }

            set
            {
                if (value > upperBoundary)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Years cannot be above {0}",upperBoundary));
                }

                this.years = value;
            }
        }

        public InterestCalculationDelegate Del { get; set; }

        public string CalculateInterest()
        {
            switch (this.Del)
            {
                case InterestCalculationDelegate.SimpleInterestCalculation:
                    CalculateInterest simpleInterestCalculation = new CalculateInterest(GetSimpleInterest);

                    return simpleInterestCalculation(this.Sum, this.PersantageInterest, this.Years);
                case InterestCalculationDelegate.CompundInterestCalculation:
                    CalculateInterest compoundInterestCalculation = new CalculateInterest(GetCompoundInterest);
                    return compoundInterestCalculation(this.Sum, this.PersantageInterest, this.Years);
                default:
                    return "Delegate not recognised!";
            }
        }
        public static string GetSimpleInterest(decimal sum, double interestPersantage, byte years)
        {
            decimal simpleInterest = sum * (1.0M + (((decimal)interestPersantage / 100M) * (decimal)years));
            string result = string.Format("{0:F4}", simpleInterest);
            return result;
        }

        public static string GetCompoundInterest(decimal sum, double interestPersantage, byte years)
        {
            const double nCoef = 12;
            double firstPart = (1 + (interestPersantage / (100 * nCoef)));
            decimal result = sum * (decimal)(Math.Pow(firstPart, years * nCoef));
            string output = string.Format("{0:F4}", result);
            return output;
        }


    }
}
