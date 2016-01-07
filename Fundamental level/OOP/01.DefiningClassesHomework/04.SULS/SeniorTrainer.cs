using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SULS
{
    public class SeniorTrainer: Trainer
    {
        public void DeleteCourse(SeniorTrainer trainer, string courseName)
        {
            string wholeName = trainer.FirstName + " " + trainer.LastName;
            Console.WriteLine("The trainer {0} has deleted the course {1}.", wholeName, courseName);
        }

        public SeniorTrainer(string firstName,string lastName, byte age)
            : base(firstName, lastName, age)
        {

        }
    }
}
