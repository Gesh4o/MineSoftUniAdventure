using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SULS
{
    public class OnsiteStudent: CurrentStudent
    {
        private int visitsCount;

        public OnsiteStudent(string firstName, string lastName, byte age, uint studentNumber,
            double avarageGrade, string currentCourse, int visitCount) 
            :base(firstName, lastName, age, studentNumber, avarageGrade, currentCourse)
        {
            this.VisitsCount = visitsCount;
        }

        public int VisitsCount
        {
            get {return this.visitsCount; }
            set
            {
                if (value <0)
                {
                    throw new ArgumentOutOfRangeException("Visits can't be negative count!");
                }
                visitsCount = value;    
            }
        }
    }
}
