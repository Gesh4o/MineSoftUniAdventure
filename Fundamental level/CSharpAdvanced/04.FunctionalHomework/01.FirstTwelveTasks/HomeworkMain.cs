namespace FunctionalProgrammingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Sockets;

    public class HomeworkMain
    {
        public static void Main(string[] args)
        {
            List<Student> sampleExample = new List<Student>();

            InitializeStudentsData(sampleExample);

            // Problem 02.
            var sortedByGroup = SortByGroup(sampleExample);

            // Problem 03.
            var sortedByFirstAndLastName = SortByFirstAndLastName(sampleExample);

            // Problem 04.
            var sortedByAge =
                sampleExample.Where(s => s.Age >= 18 && s.Age <= 24)
                    .Select(student => new { student.FirstName, student.LastName, student.Age });

            // Problem 05.
            var sortedByNameDescending = SortByNameDescending(sampleExample);

            // Problem 06.
            var sortedByEmail = SortByEmail(sampleExample);

            // Problem 07.
            var sortedByPhone = SortByPhone(sampleExample);

            // Problem 08.
            var sortedByExcellentMark =
                sampleExample.Where(s => s.Marks.Contains(6))
                    .Select(s => new { s.FirstName, Marks = string.Join(", ", s.Marks) })
                    .ToList();

            // Problem 09.
            var weakStudents = SortByWeakStudents(sampleExample);

            // Problem 10.
            var sortedByEnroll =
                sampleExample.Where(s => s.FacultyNumber.EndsWith("14"))
                    .Select(s => new { Marks = string.Join(", ", s.Marks) });
             
            // Problem 11. There are two solutions which are practically the same.
            var sortedByGroupName =
                sampleExample.Select(
                    s => new
                        {
                            Group = s.GroupName,
                            StudentsInGroup =
                        string.Join(Environment.NewLine, sampleExample.Where(st => st.GroupName == s.GroupName))
                        }).ToList().Distinct();

            // If you follow HQC principles just skip next 18 rows
            var sortedWithGroupName = from student in sampleExample
                                      group
                                          new
                                              {
                                                  Group = student.GroupName,
                                                  Students =
                                                  string.Join(
                                                      Environment.NewLine,
                                                      (from st in sampleExample where st.GroupName == student.GroupName select st).ToList())
                                              } 
                                          by student.GroupName
                                      into studentGroup
                                      orderby studentGroup.Key
                                      select studentGroup;

            ////foreach (var group in sortedWithGroupName)
            ////{
            ////    Console.WriteLine(string.Join(Environment.NewLine, group));
            ////}

            // Problem 12.
            var specialties = new List<StudentSpecialty>();
            InitializeStudentSpecialties(specialties);

            var joinResult = sampleExample.Join(
                specialties,
                student => student.FacultyNumber,
                st => st.FacultyNumber,
                (s, p) => new { FirstName = s.FirstName, FacultyNumber = s.FacultyNumber, Specialty = p.SpecialtyName }).ToList();

            // Here you can paste every sorted enumerable from above but the "sortedWithGroupName".
            Console.WriteLine(string.Join(Environment.NewLine, joinResult));
        }

        private static void InitializeStudentSpecialties(List<StudentSpecialty> specialties)
        {
            var cSharp = new StudentSpecialty("CSharp for babies", "233114");
            var java = new StudentSpecialty("Java and regex", "212331");
            var python = new StudentSpecialty("Python OOP", "123456");
            var newCSharp = new StudentSpecialty("CSharp for babies", "696969");
            var javaOnly = new StudentSpecialty("Java", "133415");
            specialties.Add(cSharp);
            specialties.Add(javaOnly);
            specialties.Add(java);
            specialties.Add(python);
            specialties.Add(newCSharp);
        }

        private static List<Student> SortByWeakStudents(List<Student> sampleExample)
        {
            var weakStudents =
                (from student in sampleExample
                 let count = student.Marks.Count(mark => mark == 2)
                 where count == 2
                 select student).ToList();
            return weakStudents;
        }

        private static List<Student> SortByPhone(List<Student> sampleExample)
        {
            var sortedByPhone = sampleExample.Where(s => s.Phone.StartsWith("02")).ToList();
            return sortedByPhone;
        }

        private static IEnumerable<Student> SortByEmail(List<Student> sampleExample)
        {
            var sortedByEmail = sampleExample.Where(s => s.Email.EndsWith("@abv.bg"));
            return sortedByEmail;
        }

        private static IOrderedEnumerable<Student> SortByNameDescending(List<Student> sampleExample)
        {
            var sortedByNameDescending = from student in sampleExample
                                         orderby student.FirstName descending
                                         orderby student.LastName descending
                                         select student;
            return sortedByNameDescending;
        }

        private static List<Student> SortByFirstAndLastName(List<Student> sampleExample)
        {
            var sortedByFirstAndLastName = sampleExample.Where(s => s.FirstName.CompareTo(s.LastName) > 0).ToList();
            return sortedByFirstAndLastName;
        }

        private static List<Student> SortByGroup(List<Student> sampleExample)
        {
            var sortedByGroup = sampleExample.Where(s => s.GroupNumber == 2).OrderBy(s => s.FirstName).ToList();
            return sortedByGroup;
        }

        private static void InitializeStudentsData(List<Student> sampleExample)
        {
            var angel = new Student(
                "Angel",
                "Angelov",
                19,
                "233114",
                "+35912345678",
                "azSumUltras@abv.bg",
                new List<int>() { 3, 4, 5, 3, 5 },
                1,
                "C#");

            var bob = new Student(
                "Bobi",
                "Borisov",
                25,
                "212331",
                "+35945645678",
                "cska4ever@abv.bg",
                new List<int>() { 6, 2, 2, 3, 5 },
                2,
                "Java");

            var tosho = new Student(
                "Tosho",
                "Toshkov",
                21,
                "123456",
                "+35912123456",
                "malka_Akula@abv.bg",
                new List<int>() { 2, 6, 6, 5, 6 },
                3,
                "Python");

            var minka = new Student(
                "Minka",
                "Minkova",
                45,
                "133415",
                "02/443322",
                "minka.spasova@abv.bg",
                new List<int>() { 5, 4, 5, 6, 5 },
                1,
                "C#");

            var teodora = new Student(
                "Teodora",
                "Todorova",
                19,
                "696969",
                "+35912345678",
                "the_pretty_macrekkless_15@yahoo.com",
                new List<int>() { 3, 4, 5, 3, 5 },
                2,
                "Java");

            sampleExample.Add(angel);
            sampleExample.Add(bob);
            sampleExample.Add(tosho);
            sampleExample.Add(minka);
            sampleExample.Add(teodora);
        }
    }
}
