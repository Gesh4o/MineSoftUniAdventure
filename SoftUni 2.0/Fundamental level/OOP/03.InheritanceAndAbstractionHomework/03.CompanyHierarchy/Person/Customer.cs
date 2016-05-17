namespace _03.CompanyHierarchy
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Customer : Person, ICustomer
    {
        private decimal moneySpent;

        public Customer(string id, string firstName, string lastName, decimal moneySpent) 
            :base(id, firstName, lastName)
        {
            this.MoneySpent = moneySpent;
        }

        public decimal MoneySpent
        {
            get
            {
                return this.moneySpent;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Money spent cannot be negative!");
                }

                this.moneySpent = value;
            }
        }

        public override string ToString()
        {
            string result = string.Format("Name-ID: {0} {1} - {2} \nMoney spent: {3:.##} lv.", this.FirstName, this.LastName, this.ID, this.moneySpent);
            return result;
        }
    }
}
