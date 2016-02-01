namespace UniversityLearningSystem.Controllers
{
    using System;

    using UniversityLearningSystem.Contracts;
    using UniversityLearningSystem.Exceptions;
    using UniversityLearningSystem.Infrastructure;
    using UniversityLearningSystem.Models;
    using UniversityLearningSystem.Utilities;

    /// <summary>
    /// Provides all the functionality needed to be performed by the user.
    /// </summary>
    public class UsersController : Controller
    {
        public UsersController(IBangaloreUniversityDate data, User user)
        {
            this.Data = data;
            this.CurrentUser = user;
        }

        /// <summary>
        /// Register user with specific parameters.
        /// </summary>
        /// <param name="username">
        /// The username of the user. Note that the name cant be duplicated.
        /// </param>
        /// <param name="password">
        /// Password used to enter to the system.
        /// </param>
        /// <param name="confirmPassword">
        /// This password must match with the previous one.
        /// </param>
        /// <param name="role">
        /// Describe the role of the registrating user in system. 
        /// </param>
        /// <returns>
        /// Returns view which will be appended on the UI.
        /// </returns>
        public IView Register(string username, string password, string confirmPassword, string role)
        {
            if (password != confirmPassword)
            {
                throw new ArgumentException("The provided passwords do not match.");
            }

            this.EnsureNoLoggedInUser();

            var existingUser = this.Data.Users.GetByUsername(username);
            if (existingUser != null)
            {
                throw new ArgumentException(string.Format("A user with username {0} already exists.", username));
            }

            Role userRole = (Role)Enum.Parse(typeof(Role), role, true);
            var user = new User(username, password, userRole);
            this.Data.Users.Add(user);
            return this.View(user);
        }

        /// <summary>
        /// Provides the login utility.
        /// </summary>
        /// <param name="username">
        /// Username which was chosen during registration.
        /// </param>
        /// <param name="password">
        /// Password which was chosen during registration.
        /// </param>
        /// <returns>
        /// Returns view which will be appended on the UI.
        /// </returns>
        public IView Login(string username, string password)
        {
            this.EnsureNoLoggedInUser();

            var existingUser = this.Data.Users.GetByUsername(username);
            if (existingUser == null)
            {
                throw new ArgumentException(string.Format("A user with username {0} does not exist.", username));
            }

            if (existingUser.PasswordHash != HashUtilities.HashPassword(password))
            {
                throw new ArgumentException("The provided password is wrong.");
            }

            this.CurrentUser = existingUser;
            return this.View(existingUser);
        }

        /// <summary>
        /// Logs out the current logged in user.
        /// </summary>
        /// <returns>Returns view which will be appended on the UI.</returns>
        public IView Logout()
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            if (!this.CurrentUser.IsInRole(Role.Lecturer) && !this.CurrentUser.IsInRole(Role.Student))
            {
                throw new AuthorizationFailedException("The current user is not authorized to perform this operation.");
            }

            var user = this.CurrentUser;
            this.CurrentUser = null;
            return this.View(user);
        }

        private void EnsureNoLoggedInUser()
        {
            if (this.HasCurrentUser)
            {
                throw new ArgumentException("There is already a logged in user.");
            }
        }
    }
}