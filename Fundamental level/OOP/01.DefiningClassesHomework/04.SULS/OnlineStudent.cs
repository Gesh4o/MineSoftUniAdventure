using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SULS
{
    public class OnlineStudent : CurrentStudent
    {
        public OnlineStudent(string firstName,string lastName, byte age,
            uint studentNumber, double avarageGrade, string currentCourse ) 
            :base(firstName, lastName, age, studentNumber, avarageGrade, currentCourse)
        {

        }
    }
}
