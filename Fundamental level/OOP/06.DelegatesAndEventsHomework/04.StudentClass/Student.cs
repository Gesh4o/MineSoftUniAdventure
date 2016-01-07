namespace _04.StudentClass
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Student
    {
        public event StudentParamChanged OnStudentParamsChanged;

        private const int bottomBoundary = 0;
        private const int upperBoundary = 120;

        private int age;
        private string name;

        public Student(string name, int age)
        {
            this.name = name;
            this.age = age;
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

                this.OnStudentParamsChanged(this, new StudentParamChangedEventAgs(this.name, value, nameof(this.name)));
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
                if (value < bottomBoundary || value > upperBoundary)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Age must be in boundaries [{0},{1}]", bottomBoundary, upperBoundary));
                }

                this.OnStudentParamsChanged(this, new StudentParamChangedEventAgs(this.age, value, nameof(age).ToString()));

                this.age = value;
            }
        }
    }
}
