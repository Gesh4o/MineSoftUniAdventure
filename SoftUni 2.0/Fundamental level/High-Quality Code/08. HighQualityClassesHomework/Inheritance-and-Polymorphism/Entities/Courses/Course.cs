namespace InheritanceAndPolymorphism.Entities.Courses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;

    public abstract class Course : ICourse
    {
        private string courseName;
        private string teacherName;
        private IList<IStudent> students; 

        protected Course(string courseName, string teacherName)
        {
            this.CourseName = courseName;
            this.TeacherName = teacherName;
            this.Students = new List<IStudent>();
        }

        protected Course(string courseName, string teachearName, IList<IStudent> students)
            : this(courseName, teachearName)
        {
            this.Students = students;
        }

        public string CourseName
        {
            get
            {
                return this.courseName;
            }
            private set
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
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format($"{nameof(this.TeacherName)} cannot be null or empty!"));
                }

                this.teacherName = value;
            }
        }

        public IEnumerable<IStudent> Students
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

                this.students = (value as IList<IStudent>);
            }
        }

        public void AddStudents(params IStudent[] studentsToAdd)
        {
            if (studentsToAdd == null || studentsToAdd.Length == 0)
            {
                throw new ArgumentException("Student cannot be null or empty!");
            }

            foreach (IStudent student in studentsToAdd)
            {
                if (student == null)
                {
                    throw new ArgumentNullException("Cannot add null student!");
                }

                this.students.Add(student);
            }
        }

        public void RemoveStudent(IStudent studentToRemove)
        {
            if (studentToRemove == null)
            {
                throw new ArgumentNullException("Cannot remove student null!");
            }

            bool isStudentExistingInCourse = false;
            foreach (IStudent student in this.students)
            {
                if (student.FirstName != studentToRemove.FirstName || student.LastName != studentToRemove.LastName)
                {
                    continue;
                }
                isStudentExistingInCourse = true;
                break;
            }

            if (isStudentExistingInCourse)
            {
                Console.WriteLine($"Student {studentToRemove.FirstName} {studentToRemove.LastName} removed successfully!");
            }
            else
            {
                Console.WriteLine($"Student {studentToRemove.FirstName} {studentToRemove.LastName} is not listed in current course!");
            }
        } 

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Course { Name = ");
            result.Append(this.CourseName);

            result.Append("; Teacher = ");
            result.Append(this.TeacherName);

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());

            return result.ToString();
        }

        private string GetStudentsAsString()
        {
            StringBuilder result = new StringBuilder();
            if (this.Students == null || !this.Students.Any()) 
            {
                result.Append("{ }");
                return result.ToString();
            }
            else
            {
                result.Append("{ ");
                result.Append(string.Join(", ", this.Students));
                result.Append(" }");

                return result.ToString();
            }
        }
    }
}
