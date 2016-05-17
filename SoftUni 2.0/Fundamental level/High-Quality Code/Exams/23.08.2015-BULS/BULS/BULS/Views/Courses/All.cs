namespace UniversityLearningSystem.Views.Courses
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using UniversityLearningSystem.Infrastructure;
    using UniversityLearningSystem.Models;

    public class All : View
    {
        public All(IEnumerable<Course> courses)
            : base(courses)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var courses = this.Model as IEnumerable<Course>;
            if (!courses.Any())
            {
                viewResult.AppendLine("No courses.");
            }
            else
            {
                viewResult.AppendLine("All courses:");
                foreach (var course in courses)
                {
                    viewResult.AppendFormat("{0} ({1} students)", course.Name, course.Students.Count()).AppendLine();
                }
            }
        }
    }
}