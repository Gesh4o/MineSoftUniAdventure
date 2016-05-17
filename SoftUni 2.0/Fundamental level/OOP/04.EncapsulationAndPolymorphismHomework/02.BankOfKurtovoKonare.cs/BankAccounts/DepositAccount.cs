namespace BankOfKurtovoKonare.cs.BankAccounts
{
    using Interfaces;

    public class DepositAccount :BankAccount,IWithdraw
    {
        public DepositAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer,balance,interestRate)
        {

        }

        public override decimal CalculateInterest(int months)
        {
            if (this.Balance<1000)
            {
                return 0;
            }
            return base.CalculateInterest(months);
        }

        public void WithdrawMoney(decimal money)
        {
            this.Balance -= money;
        }

    }
}
