namespace _02.ComparingDataStructures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Person
    {
        public Person(string name, string phoneNumber)
        {
            this.Name = name;
            this.PhoneNumber = phoneNumber;
        }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Name: " + this.Name);
            result.AppendLine("Number :" + this.PhoneNumber);
            return result.ToString().Trim();
        }
    }
}
