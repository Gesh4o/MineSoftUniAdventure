namespace _01.HumanStudentWorker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MainClass
    {
        private static void Main()
        {
            List<Student> universityClass = new List<Student>(10);

            Student bobo = new Student("Borislav", "Bojidarov", "12345");
            Student gogo0 = new Student("Georgi", "Vasilev", "abcde");
            Student toto = new Student("Tihomir", "Aleksandrov", "ABCDE");
            Student gogo1 = new Student("Georgi", "Georgiev", "dsdsa");
            Student momo = new Student("Misho", "Botisho", "43155");

            universityClass.Add(gogo0);
            universityClass.Add(momo);
            universityClass.Add(toto);
            universityClass.Add(bobo);
            universityClass.Add(gogo1);

            // Code pieces are left if you want to do a check.
            //foreach (var student in universityClass)
            //{
            //    Console.WriteLine(student);
            //}

            universityClass = universityClass.OrderBy(p => p.FacultyNumber).ToList();

            //Console.WriteLine();
            //Console.WriteLine();
            //foreach (var student in universityClass)
            //{
            //    Console.WriteLine(student);
            //}

            List<Worker> brigade = new List<Worker>(10);
            Worker tosho = new Worker("Tihomir", "Manolov", 8, 120);
            Worker gosho = new Worker("Georgi", "Todorov", 6, 140);
            Worker tanya = new Worker("Tanya", "Emilova", 12, 280);
            Worker dimcho = new Worker("Dimitur", "Ognqnov", 4, 60);
            Worker maq = new Worker("Maq", "Pchelickata", 8, 130);
            Worker viktor = new Worker("Viktor", "Samuilov", 10, 200);

            brigade.Add(tosho);
            brigade.Add(gosho);
            brigade.Add(tanya);
            brigade.Add(dimcho);
            brigade.Add(maq);
            brigade.Add(viktor);

            brigade = brigade.OrderByDescending(p => p.WeekSalary).ToList();

            //foreach (var worker in brigade)
            //{
            //    Console.WriteLine(worker);
            //}

            List<Human> human = new List<Human>();
            human.AddRange(brigade);
            human.AddRange(universityClass);

            //foreach (var person in human)
            //{
            //    Console.WriteLine(person);
            //}

            human = human.OrderBy(p => p.FirstName).ThenBy(p => p.LastName).ToList();

            //Console.WriteLine();
            //Console.WriteLine();

            //foreach (var person in human)
            //{
            //    Console.WriteLine(person);
            //}
        }
    }
}
