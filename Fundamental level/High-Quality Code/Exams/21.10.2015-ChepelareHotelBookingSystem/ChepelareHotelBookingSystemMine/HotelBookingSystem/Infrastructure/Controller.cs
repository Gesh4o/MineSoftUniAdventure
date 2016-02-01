namespace HotelBookingSystem.Infrastructure
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using Contracts;
    using HotelBookingSystem.Enums;
    using HotelBookingSystem.Identity;
    using HotelBookingSystem.Models;
    using HotelBookingSystem.Utilities;
    using HotelBookingSystem.Views.Shared;

    /// <summary>
    /// Provides functionality to create a view and return it to UI.
    /// </summary>
    public class Controller
    {
        /// <summary>
        /// Gets a new controller which works with given <paramref name="data"></paramref>
        /// and will be set from passed <paramref name="user"></paramref>.
        /// </summary>
        /// <param name="data">Data in which will be made changes.</param>
        /// <param name="user">User with whose information changes will be made.</param>
        public Controller(IHotelBookingSystemData data, User user)
        {
            this.Data = data;
            this.CurrentUser = user;
        }

        /// <summary>
        /// Currently logged in user in system.
        /// </summary>
        public User CurrentUser { get; set; }
        
        /// <summary>
        /// Checks if currently user is logged in.
        /// </summary>
        public bool HasCurrentUser => this.CurrentUser != null;

        /// <summary>
        /// Data which controller will update.
        /// </summary>
        public IHotelBookingSystemData Data { get; private set; }

        /// <summary>
        /// Provides view which will be passed to the UI.
        /// </summary>
        /// <param name="model">Concrete expected model from which view will be made.</param>
        /// <returns></returns>
        public IView View(object model)
        {
            string fullNamespace = this.GetType().Namespace;

            int firstSeparatorIndex = fullNamespace.IndexOf(Constants.NamespaceSeparator);

            string baseNamespace = fullNamespace.Substring(0, firstSeparatorIndex);

            string controllerName = this.GetType().Name.Replace(Constants.ControllerSuffix, string.Empty);
            string actionName = new StackTrace().GetFrame(1).GetMethod().Name;

            string fullPath = string.Join(
                Constants.NamespaceSeparator,
                new[] { baseNamespace, Constants.ViewsFolder, controllerName, actionName });

            var viewType = Assembly
                .GetExecutingAssembly()
                .GetType(fullPath);

            var view = Activator.CreateInstance(viewType, model) as IView;
            return view;
        }

        /// <summary>
        /// Used to signalize user with error messages.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public IView NotFound(string message)
        {
            return new Error(message);
        }

        /// <summary>
        /// Authorize users role.
        /// </summary>
        /// <param name="roles">Roles which will be checked if user belongs to.</param>
        public void Authorize(params Roles[] roles)
        {
            if (!HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            if (!roles.Any(role => CurrentUser.IsInRole(role)))
            {
                throw new AuthorizationFailedException("The currently logged in user doesn't have sufficient rights to perform this operation.", this.CurrentUser);
            }
        }
    }
}
