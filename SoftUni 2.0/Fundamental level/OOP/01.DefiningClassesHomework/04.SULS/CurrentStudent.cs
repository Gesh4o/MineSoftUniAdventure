using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SULS
{
    public class CurrentStudent : Student
    {
        private string currentCourse;

        public CurrentStudent(string firstName,string lastName, byte age,
            uint studentNumber, double avarageGrade,string currentCourse) : base(firstName,lastName, age, studentNumber, avarageGrade)
        {
            this.CurrentCourse = currentCourse;
        }

        public string CurrentCourse
        {
            get {return this.currentCourse; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Course can't be null");
                }
                this.currentCourse = value;
            }
        }

        public override string ToString()
        {
            string studentInfo =
                String.Format("Name: {0} {1} \nAge: {2} \nStudent number: {3} \nAvarage grade: {4}",
                this.FirstName, this.LastName, this.Age, this.StudentNumber, this.AvarageGrade );
            return studentInfo;
        }

    }
}
