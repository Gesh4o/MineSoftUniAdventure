namespace BankOfKurtovoKonare.cs.BankAccounts
{
    class MortgageAccount : BankAccount
    {
        public MortgageAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {

        }

        public override decimal CalculateInterest(int months)
        {
            if (this.Customer is IndividualCustomer)
            {
                int individualUpperBound = 6;
                if (months <= individualUpperBound)
                {
                    return 0;
                }
                else
                {
                    return base.CalculateInterest(months - individualUpperBound);
                }
            }
            else
            {
                const int upperBoundary = 12;
                if (months <= upperBoundary)
                {
                    return (base.CalculateInterest(months) / 2.0M);
                }
                else
                {
                    return ((base.CalculateInterest(upperBoundary)) / 2.0M) + base.CalculateInterest(months - upperBoundary);
                }
            }
        }
    }
}
