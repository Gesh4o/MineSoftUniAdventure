namespace _02.Animals
{
    using System;
    using Interfaces;

    public abstract class Animals : ISoundProducible
    {
        private string name;
        private string gender;
        private int age;

        public Animals(string name, string gender, int age)
        {
            this.Name = name;
            this.Gender = gender;
            this.Age = age;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name must not be null or empty!");
                }

                this.name = value;
            }
        }

        public string Gender
        {
            get { return this.gender; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Gender must not be null or empty!");
                }

                this.gender = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Age must not be negative!");
                }

                this.age = value;
            }
        }

        public abstract void ProduceSound();

    }

}
