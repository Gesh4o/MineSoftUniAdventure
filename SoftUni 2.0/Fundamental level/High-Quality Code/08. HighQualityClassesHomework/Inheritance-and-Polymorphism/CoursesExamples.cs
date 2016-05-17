namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Entities;
    using Entities.Courses;

    public class CoursesExamples
    {
        public static void Main()
        {
            ILocalCourse localCourse = new LocalCourse("Database", "Nakov", "Enterprise");
            Console.WriteLine(localCourse);

            IStudent peter = new Student("Peter", "Peshov");
            IStudent maria = new Student("Maria", "Marianova"); // Seems legit.

            localCourse.AddStudents(peter, maria);
            Console.WriteLine(localCourse);

            IStudent milena = new Student("Milena", "Milenova");
            IStudent todor = new Student("Todor", "Petkov");
            localCourse.AddStudents(milena, todor);
            Console.WriteLine(localCourse);

            OffsiteCourse offsiteCourse = new OffsiteCourse(
                "PHP and WordPress Development",
                "Mario Peshev",
                new List<IStudent>()
                    {
                        new Student("Thomas", "Edinburg"),
                        new Student("Ani", "Beleva"),
                        new Student("Steve", "Petrov")
                    },
                "Blagoevgrad");
            Console.WriteLine(offsiteCourse);
        }
    }
}
