namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Course
    {
        private string courseName;
        private string teacherName;
        private IList<string> students; 

        protected Course(string courseName, string teacherName)
        {
            this.CourseName = courseName;
            this.TeacherName = teacherName;
            this.students = new List<string>();
        }

        protected Course(string courseName, string teachearName, IList<string> students)
            : this(courseName, teachearName)
        {
            this.students = students;
        }

        public string CourseName
        {
            get
            {
                return this.courseName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format($"{nameof(this.CourseName)} cannot be null or empty!"));
                }

                this.courseName = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format($"{nameof(this.TeacherName)} cannot be null or empty!"));
                }

                this.teacherName = value;
            }
        }

        public IEnumerable<string> Students
        {
            get
            {
                return this.students;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(string.Format($"{nameof(this.Students)} cannot be null."));
                }
            }
        }

        public void AddStudent(params string[] students)
        {
            if (students == null || students.Length == 0)
            {
                throw new ArgumentException("Student cannot be null or empty!");
            }

            foreach (string student in students)
            {
                if (student.Length < 6 || !student.Contains(" "))
                {
                    throw new ArgumentException("Student name is either too short or not full.");
                }

                this.students.Add(student);
            }
        }

        public void RemoveStudent(string student)
        {
            if (string.IsNullOrEmpty(student))
            {
                throw new ArgumentException("Student to remove cannot be null or empty!");
            }

            if (this.students.Contains(student))
            {
                this.students.Remove(student);
                Console.WriteLine($"Student {student} removed successfully!");
            }
            else
            {
                Console.WriteLine("Student is not listed in current course!");
            }
        } 

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Course { Name = ");
            result.Append(this.CourseName);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }
            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());

            return result.ToString();
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}
