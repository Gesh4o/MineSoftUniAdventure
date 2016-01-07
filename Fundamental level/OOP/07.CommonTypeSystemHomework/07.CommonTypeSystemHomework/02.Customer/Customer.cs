namespace _02.Customer
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Customer : ICustomer, ICloneable, IComparable
    {
        private IList<IPayment> payments;

        public Customer(
            string firstName,
            string middleName,
            string lastName,
            string id,
            string mobilePhone,
            string address,
            string email,
            CustomerTypes customerType)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.ID = id;
            this.MobilePhone = mobilePhone;
            this.Address = address;
            this.Email = email;
            this.CustomerType = customerType;
            this.payments = new List<IPayment>();
        }

        public string Address { get; }

        public CustomerTypes CustomerType { get; }

        public string Email { get; }

        public string FirstName { get; }

        public string ID { get; }

        public string LastName { get; }

        public string MiddleName { get; }

        public string MobilePhone { get; }

        public IEnumerable<IPayment> Payments { get { return this.payments; } }

        public override string ToString()
        {
            StringBuilder customerInfo = new StringBuilder();
            customerInfo.AppendFormat($"Customer: {this.FirstName} {this.MiddleName} {this.LastName} {Environment.NewLine}");
            customerInfo.AppendLine("Additional information:");
            customerInfo.AppendLine($"ID: {this.ID}");
            customerInfo.AppendLine($"Mobile phone: {this.MobilePhone}");
            customerInfo.AppendLine($"Address: {this.Address}");
            customerInfo.Append($"E-mail: {this.Email}");

            return customerInfo.ToString();
        }

        public override bool Equals(object obj)
        {
            ICustomer customer = obj as Customer;
            if (customer == null)
            {
                return false;
            }

            if (!Object.Equals(this.ID,customer.ID))
            {
                return false;
            }

            if (this.ID == customer.ID)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() ^ this.ID.GetHashCode();
        }

        public object Clone()
        {
            ICustomer clonedCustomer = new Customer(
                this.FirstName,
                this.MiddleName,
                this.LastName,
                this.ID,
                this.MobilePhone,
                this.Address,
                this.Email,
                this.CustomerType);
            return clonedCustomer;
        }

        public int CompareTo(object obj)
        {
            Customer customer = obj as Customer;
            if (customer == null)
            {
                return -1;
            }
            
            if (String.Compare(this.FirstName,customer.FirstName)==0 
                && String.Compare(this.MiddleName, customer.MiddleName) == 0 
                && String.Compare(this.LastName, customer.LastName) == 0
                && String.Compare(this.ID, customer.ID) == 0)
            {
                if (String.Compare(this.ID, customer.ID) == 0)
                {
                    return 0;
                }

                return String.Compare(this.ID, customer.ID);
                // Well I guess this is what is supposed to happen. (NO idea, man.)
            }
            else if (String.Compare(this.FirstName, customer.FirstName) == 0
                && String.Compare(this.MiddleName, customer.MiddleName) == 0
                && String.Compare(this.LastName, customer.LastName) == 0)
            {
                return String.Compare(this.ID, customer.ID);
            }
            else if (String.Compare(this.FirstName, customer.FirstName) == 0
                && String.Compare(this.MiddleName, customer.MiddleName) == 0)
            {
                return String.Compare(this.LastName, customer.LastName);
            }
            else if (String.Compare(this.FirstName, customer.FirstName) == 0)
            {
                return String.Compare(this.MiddleName, customer.MiddleName);
            }
            if (String.Compare(this.FirstName,customer.FirstName) == -1 
                || String.Compare(this.MiddleName, customer.MiddleName) == - 1
                || String.Compare(this.LastName, customer.LastName) == -1)
            {
                return -1;
            }
            // If the full name is equal, then id will be deciding what to comparing,
            // if any of the names are -1 - the answer will be -1,
            // else is to be 1.

            if (String.Compare(this.FirstName, customer.FirstName) == 1
                && String.Compare(this.MiddleName, customer.MiddleName) == 1
                && String.Compare(this.LastName, customer.LastName) == 1)
            {
                return String.Compare(this.ID, customer.ID);
            }
            else if (String.Compare(this.FirstName, customer.FirstName) == 1
                && String.Compare(this.MiddleName, customer.MiddleName) == 1)
            {
                return String.Compare(this.LastName, customer.LastName);
            }
            else if (String.Compare(this.FirstName, customer.FirstName) == 1)
            {
                return String.Compare(this.MiddleName, customer.MiddleName);
            }
            return 1;
        }

        public static bool operator == (Customer customer0, Customer customer1)
        {
            return customer0.Equals(customer1);
        }

        public static bool operator != (Customer customer0, Customer customer1)
        {
            return !(customer0.Equals(customer0));
        }
    }
}
