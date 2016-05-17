namespace _01.Persons
{
    using System;

    public class Person
    {
        // Creating fields
        private string name;
        private int age;
        private string email;

        public Person(string name, int age) 
        {
            this.Name = name;
            this.Age = age;
        }

        public Person(string name, int age, string email) : this(name, age)
        {
            this.Email = email;
        }

        // Creating and validating the properties
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The name could not be empty!");
                }
                this.name = value;
            }
        }
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 1 || value > 101) 
                {
                    throw new ArgumentOutOfRangeException("The age is not in the possible boundaries.");
                }
                this.age = value;
            }
        }
        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                if (value == null || value.Contains("@"))
                {
                    this.email = value;
                }
                else
                {
                    throw new Exception("Not a valid email!");
                }
            }
        }

        public override string ToString()
        {
            return "This is " + this.name + "which is currently " + this.age + " year(s) old. His email is : " + (this.email ?? "[currently not avaible]") + ".";
        }
    }
}
