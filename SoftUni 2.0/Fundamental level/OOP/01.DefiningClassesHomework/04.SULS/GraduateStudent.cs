using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SULS
{
    public class GraduateStudent : Student
    {
        public GraduateStudent(string firstName, string lastName, byte age , uint studentNumber, double avarageGrade)
            : base(firstName,lastName,age,studentNumber,avarageGrade)
        {

        }
    }
}
