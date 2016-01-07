namespace BankOfKurtovoKonare.cs
{
    using Interfaces;
    using System;

    public abstract class BankAccount : IDeposit
    {
        private Customer customer;
        private decimal balance;
        private decimal interestRate;

        // The setters have access modifiers ""protected" so for the user cannot change the value externally.

        public BankAccount(Customer customer, decimal balance,decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public Customer Customer
        {
            get { return this.customer; }
            protected set { this.customer = value; }
        }

        public decimal Balance
        {
            get { return this.balance; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Balance can't be negative!");
                }

                this.balance = value;
            }

        }

        public decimal InterestRate
        {
            get { return this.interestRate; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Interest rate must be above 0!");
                }

                this.interestRate = value;
            }
        }

        public virtual decimal CalculateInterest(int months)
        {
            decimal interest = this.balance * (this.interestRate * months);
            return interest;
        }

        public void DepositMoney(decimal money)
        {
            this.Balance += money;
        }

        public override string ToString()
        {
            string result = string.Format("Name: {0}\nBalance{1}\nInterest rate: {2}", this.Customer.Name, this.balance, this.interestRate);
            return base.ToString(); 
        }
    }
}
