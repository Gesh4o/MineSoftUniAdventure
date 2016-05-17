namespace InheritanceAndPolymorphism.Entities.Courses
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;

    public class OffsiteCourse : Course, IOffsiteCourse
    {
        private string town;

        public OffsiteCourse(string courseName, string teacherName, string town) 
            : this(courseName, teacherName, new List<IStudent>(), town)
        {
        }

        public OffsiteCourse(string courseName, string teacherName, IList<IStudent> studentsInCourse, string town) 
            : base(courseName, teacherName, studentsInCourse)
        {
            this.Town = town;
        }

        public string Town
        {
            get
            {
                return this.town;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format($"{nameof(this.Town)} cannot be null or empty!"));
                }

                this.town = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());
            result.Append("; Town = ");
            result.Append(this.Town);
            result.Append(" }");

            return result.ToString();
        }
    }
}
