using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SULS
{
    public class DropoutStudent: Student
    {
        private string dropoutReason;

        public DropoutStudent(string firstName, string lastName, byte age , 
            uint studentNumber, double avarageGrade, string dropoutReason) : base(firstName, lastName, age, studentNumber, avarageGrade)
        {
            this.dropoutReason = dropoutReason;
        }

        public string DropoutReason
        {
            get { return this.dropoutReason; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("There must be a reason to be dropped out!");
                }
                dropoutReason = value;
            }
        }

        public void Reapply()
        {
            string studentInfo = 
                String.Format("Name: {0} {1} \nAge: {2} \nStudent number: {3} \nAvarage grade: {4} \nDropout reason: {5} ", 
                this.FirstName, this.LastName, this.Age, this.StudentNumber, this.AvarageGrade, this.dropoutReason);
            Console.WriteLine(studentInfo);
        }

    }
}
