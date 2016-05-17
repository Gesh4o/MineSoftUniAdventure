namespace InheritanceAndPolymorphism.Entities.Courses
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;

    public class LocalCourse : Course, ILocalCourse
    {
        private string lab;

        public LocalCourse(string courseName, string teacherName,string lab)
           : this(courseName, teacherName, new List<IStudent>(), lab) 
        {
        }

        public LocalCourse(string courseName, string teacherName, IList<IStudent> studentsInCourse, string lab)
            : base(courseName, teacherName, studentsInCourse)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new NullReferenceException(string.Format($"{nameof(this.Lab)} name cannot be null or empty"));
                }

                this.lab = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Local");
            result.Append(base.ToString());

            result.Append("; Lab = ");
            result.Append(this.Lab);
            result.Append(" }");

            return result.ToString();
        }
    }
}
