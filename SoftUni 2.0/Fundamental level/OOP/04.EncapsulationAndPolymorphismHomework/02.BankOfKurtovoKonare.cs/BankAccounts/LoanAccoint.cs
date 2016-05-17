namespace BankOfKurtovoKonare.cs.BankAccounts
{
    using Customers;

    class LoanAccoint :BankAccount
    {
        public LoanAccoint(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {

        }
        public override decimal CalculateInterest(int months)
        {
            int loanAccountCondition = 3;

            if (this.Customer is CompanyCustomer)
            {
                 loanAccountCondition = 2;
            }
            return base.CalculateInterest(months - loanAccountCondition);
        }
    }
}
