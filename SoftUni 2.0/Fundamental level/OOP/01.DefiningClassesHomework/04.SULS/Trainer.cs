using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SULS
{
    public class Trainer : Person
    {
        public void CreateCourse(Trainer trainer, string course)
        {
            string wholeName = trainer.FirstName + " " + trainer.LastName;
            Console.WriteLine("The trainer {0} has created the course {1}.",wholeName,course);
        }

        public Trainer(string firstName,string LastName,byte age) 
            :base(firstName, LastName, age)
        {

        }
    }
}
