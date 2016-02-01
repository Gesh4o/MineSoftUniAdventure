namespace UniversityLearningSystem.Views.Courses
{
    using System.Text;

    using UniversityLearningSystem.Infrastructure;
    using UniversityLearningSystem.Models;

    public class Enroll : View
    {
        public Enroll(Course course)
            : base(course)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.Model as Course;
            viewResult.AppendFormat("Student successfully enrolled in course {0}.", course.Name).AppendLine();
        }
    }
}