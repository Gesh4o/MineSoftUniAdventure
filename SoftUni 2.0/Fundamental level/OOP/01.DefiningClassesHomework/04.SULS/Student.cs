using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SULS
{
    public class Student : Person
    {
        private uint studentNumber;
        private double avarageGrade;

        public Student(string firstName, string lastName, byte age, uint studentNumber, double avarageGrade) 
            : base(firstName, lastName, age)
        {
            this.StudentNumber = studentNumber;
            this.avarageGrade = avarageGrade;
        }

        public uint StudentNumber
        {
            get {return this.studentNumber; }
            set { studentNumber = value ; }
        }

        public double AvarageGrade
        {
            get { return this.avarageGrade; }
            set
            {
                if (value < 2.00 || value > 6.00)
                {
                    double minValue = 2.00d;
                    double maxValue = 6.00d;
                    string errorMessage = String.Format("Avarage grade must be between [{0},{1}]", minValue, maxValue);
                    throw new ArgumentOutOfRangeException(errorMessage);
                }
            }

        }


    }
}
