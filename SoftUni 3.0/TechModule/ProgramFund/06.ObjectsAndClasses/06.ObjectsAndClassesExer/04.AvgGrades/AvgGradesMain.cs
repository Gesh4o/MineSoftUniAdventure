namespace _04.AvgGrades
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AvgGradesMain
    {
        public static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            int studentsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < studentsCount; i++)
            {
                string[] studentInfo = Console.ReadLine()
                   .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                   .ToArray();

                int[] grades = studentInfo.Skip(1).Select(int.Parse).ToArray();

                students.Add(new Student(studentInfo[0], grades));
            }

            foreach (Student student in students.Where(s => s.Grades.Average() >= 5).OrderBy(s => s.Name))
            {
                Console.WriteLine(student);
            }
        }
    }

    class Student
    {
        public Student(string name, int[] grades)
        {
            this.Name = name;
            this.Grades = grades;
        }

        public string Name { get; set; }

        public int[] Grades { get; set; }

        public override string ToString()
        {
            string stringView = $"{this.Name} -> {this.Grades.Average():F2}";

            return stringView;
        }
    }
}
