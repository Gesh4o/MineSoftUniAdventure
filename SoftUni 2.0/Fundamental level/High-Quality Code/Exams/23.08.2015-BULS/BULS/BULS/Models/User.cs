namespace UniversityLearningSystem.Models
{
    using System;
    using System.Collections.Generic;

    using UniversityLearningSystem.Utilities;

    public class User
    {
        private string passwordHash;

        private string username;

        public User(string username, string password, Role role)
        {
            this.Username = username;
            this.PasswordHash = password;
            this.Role = role;
            this.Courses = new List<Course>();
        }

        public IList<Course> Courses { get; private set; }

        public string PasswordHash
        {
            get
            {
                return this.passwordHash;
            }

            private set
            {
                Validator.ValidateStringLength(value, Constants.MinimalUserPasswordLength, "password");

                this.passwordHash = HashUtilities.HashPassword(value);
            }
        }

        public Role Role { get; private set; }

        public string Username
        {
            get
            {
                return this.username;
            }

            private set
            {
                Validator.ValidateStringLength(value, Constants.MinimalUsernameLength, "username");

                this.username = value;
            }
        }
    }
}