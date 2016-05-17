namespace _01.CutomLinqExtensionMethods
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Student
    {
        private const int bottomBoundary = 2;
        private const int upperBoundary = 6;

        private double grade;
        private string name;

        public Student(string name, int grade)
        {
            this.Name = name;
            this.Grade = grade;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length <3)
                {
                    throw new ArgumentException("Name cannot be null or empty neither with two or less characters!");
                }

                this.name = value;
            }
        }

        public double Grade
        {
            get
            {
                return this.grade;
            }
            set
            {
                if (value < bottomBoundary || value > upperBoundary )
                {
                    throw new ArgumentOutOfRangeException(string.Format("Grade must be in boundaries [{0},{1}]", bottomBoundary, upperBoundary));
                }

                this.grade = value;
            }
        }
    }
}
