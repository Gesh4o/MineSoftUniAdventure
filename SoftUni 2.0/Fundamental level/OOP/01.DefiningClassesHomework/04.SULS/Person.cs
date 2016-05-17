using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SULS
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private byte age;

        public Person(string firstName,string lastName, byte age)
        {  
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName
        {
            get {return this.firstName; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("First name cannot be empty or null!");
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Last name cannot be empty or null!");
                }
                this.lastName = value;
            }
        }

        public byte Age
        {
            get { return this.age; }
            set
            {
                int minValue = 15;
                int maxValue = 60;

                if (value <minValue || value >maxValue)
                {
                    string errorMessage = String.Format("Age should be in boundaries [{0},{1}]", minValue, maxValue);
                    throw new ArgumentOutOfRangeException(errorMessage);
                }
                this.age = value;
            }
        }

     
    }
}
