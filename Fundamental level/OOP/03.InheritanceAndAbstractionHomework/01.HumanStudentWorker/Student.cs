namespace _01.HumanStudentWorker
{
    using System;

    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber) 
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get { return this.facultyNumber; }
            set
            {
                int minLenght = 5;
                int maxLenght = 10;
                if (value.Length < minLenght || value.Length > minLenght)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Faculty number's lenght must be in range [{0},{1}]", minLenght, maxLenght));
                }

                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            string result = string.Format("Student name: {0} {1} \nFaculty number: {2}", this.FirstName, this.LastName, this.facultyNumber);
            return result;
        }
    }
}
