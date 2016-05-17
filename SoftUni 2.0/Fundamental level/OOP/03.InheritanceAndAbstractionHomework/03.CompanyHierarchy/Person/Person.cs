namespace _03.CompanyHierarchy
{
    using Interfaces;
    using System;

    public abstract class Person : IPerson
    {
        private string id;
        private string firstName;
        private string lastName;

        public Person(string id, string firstName, string lastName)
        {
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string ID
        {
            get
            {
                return this.id;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("ID must not be null or empty!");
                }

                this.id = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("First name must not be null or empty!");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Last name must not be null or empty!");
                }

                this.lastName = value;
            }
        }

        public override string ToString()
        {
            string result = string.Format("Name: {0} {1} \nID: {2}", this.firstName, this.lastName, this.id);
            return result;
        }
    }
}
