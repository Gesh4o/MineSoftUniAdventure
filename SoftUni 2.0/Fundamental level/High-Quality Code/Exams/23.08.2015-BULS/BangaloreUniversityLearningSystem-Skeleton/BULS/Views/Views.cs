using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Text;
using buls.Infrastructure;
namespace buls.Views.Courses
{
    public class Crate : View
    {
        public Crate(Course course)
            : base(course)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.model as Course;
            viewResult.AppendFormat("Course {0} created successfully.", course.Name).AppendLine();
        }
    }
    public class Details : View
    {
        public Details(Course course)
            : base(course)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.model as Course;
            viewResult.AppendLine(course.Name);
            if (!course.Lectures.Any())
            {
                viewResult.AppendLine("No lectures");
            }
            else
            {
                var lectureNames = course.Lectures.Select(l => "- " + l.Name);
                viewResult.AppendLine(string.Join(Environment.NewLine, lectureNames));
            }
        }
    }
    public class All : View
    {
        public All(IEnumerable<Course> courses)
            : base(courses)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            var courses = this.model as IEnumerable<Course>;
            if (!courses.Any())
            {
                viewResult.AppendLine("No courses.");
            }
            else
            {
                viewResult.AppendLine("All courses:");
                foreach (var course in courses)
                {
                    viewResult.AppendFormat("{0} ({1} students)", course.Name, course.Students.Count).AppendLine();
                }
            }
        }
    }
    public class AddLectures : View
    {
        public AddLectures(Course course)
            : base(course)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.model as Course;
            viewResult.AppendFormat("Lecture successfully added to course {0}.", course.Name).AppendLine();
        }
    }
    public class Enroll : View
    {
        public Enroll(Course course)
            : base(course)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.model as Course;
            viewResult.AppendFormat("Student successfully enrolled in course {0}.", course.Name).AppendLine();
        }
    }
}

namespace buls.Views.Users
{
    public class Logout : View
    {
        public Logout(User user)
            : base(user)
        {
        }
        internal override void BuildViewResult(StringBuilder viewResult)
        {
            // TODO: Implement me
        }
    }
    public class Login : View
    {
        public Login(User user)
            : base(user)
        {
        }
        internal override void BuildViewResult(StringBuilder viewResult)
        {
            viewResult.AppendFormat("User {0} logged in successfully.", (this.model as User).usr).AppendLine();
        }
    }
    public class Register : View
    {
        public Register(User user)
            : base(user)
        {
        }
        internal override void BuildViewResult(StringBuilder viewResult)
        {
            viewResult.AppendFormat("User {0} registered successfully.", (this.model as User).usr).AppendLine();
        }
    }
}
