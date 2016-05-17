using System;
using System.Collections.Generic;
using System.Linq;


namespace _04.SULS
{
    class MainClass
    {
        static void Main()
        {
            List<Person> person = new List<Person>();

            List<Trainer> trainer = new List<Trainer>();
            List<Student> student = new List<Student>();

            List<JuniorTrainer> juniorTrainer = new List<JuniorTrainer>();
            List<SeniorTrainer> seniorTrainer = new List<SeniorTrainer>();

            List<GraduateStudent> graduateStudent = new List<GraduateStudent>();
            List<CurrentStudent> currentStudent = new List<CurrentStudent>();
            List<DropoutStudent> dropoutStudent = new List<DropoutStudent>();

            List<OnsiteStudent> onsiteStudent = new List<OnsiteStudent>();
            List<OnlineStudent> onlineStudent = new List<OnlineStudent>();

            Person Gosho = new Person("Georgi", "Borimechkov", 59);
            //Person Pesho = new Person("Petur", "Petrov", 3); //Here will throw ArgumentOutOfRangeException
            Person Peshka = new Person("Petur", "Petrov", 23);


            person.Add(Gosho);
            person.Add(Peshka);

            OnsiteStudent Tosho = new OnsiteStudent("Tihomir", "Dikov", 44, 333333, 5.33d, "Fundamentals", 40);
            OnsiteStudent Misho = new OnsiteStudent("Mihail", "Dimov", 15, 131313, 5.85d, "C# Basics", 8);

            //OnlineStudent Daniela = new OnlineStudent("Daniela", "Bumbarova", 3, 100003, 3.21d, "Back-end"); 
            //Here will throw the same ArgumentOutOfRangeException
            OnlineStudent Lilly = new OnlineStudent("Lilly", "Dimitrova", 34, 414344, 4.21d, "Back-end");
            OnlineStudent Bobi = new OnlineStudent("Borislav", "Bobcho", 24, 132414, 4.94d, "Front-end");


            //Adding them in and sorting the list.
            currentStudent.Add(Tosho);
            currentStudent.Add(Misho);
            currentStudent.Add(Lilly);
            currentStudent.Add(Bobi);

            List<CurrentStudent> currentStudentSorted = currentStudent.OrderBy(p => p.AvarageGrade).ToList();

            foreach (var stud in currentStudentSorted)
            {
                Console.WriteLine(stud);
            }

        }
    }
}
