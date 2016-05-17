namespace InheritanceAndPolymorphism.Entities
{
    using System;
    using System.Text;
    using Contracts;

    public class Student : IStudent
    {
        private string firstName;
        private string lastName;

        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format($"{nameof(this.FirstName)} cannot be null or empty!"));
                }

                if (value.Length < 3 )
                {
                    throw new ArgumentException(string.Format($"{nameof(this.FirstName)} is too short!"));
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
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format($"{nameof(this.LastName)} cannot be null or empty!"));
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException(string.Format($"{nameof(this.LastName)} is too short!"));
                }

                this.lastName = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat($"{this.firstName} {this.lastName}");

            return result.ToString();
        }
    }
}
