namespace UniversityLearningSystem.Views.Users
{
    using System;
    using System.Text;

    using UniversityLearningSystem.Infrastructure;
    using UniversityLearningSystem.Models;

    public class Logout : View
    {
        public Logout(User user)
            : base(user)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            if ((this.Model as User) == null)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            viewResult.AppendFormat(
                "User {0} logged out successfully.{1}",
                (this.Model as User).Username,
                Environment.NewLine);
        }
    }
}