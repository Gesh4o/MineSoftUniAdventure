﻿namespace UniversityLearningSystem.Infrastructure
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;

    using UniversityLearningSystem.Contracts;
    using UniversityLearningSystem.Exceptions;
    using UniversityLearningSystem.Models;
    using UniversityLearningSystem.Utilities;

    public abstract class Controller
    {
        public bool HasCurrentUser
        {
            get
            {
                return this.CurrentUser != null;
            }
        }

        public User CurrentUser { get; set; }

        protected IBangaloreUniversityDate Data { get; set; }

        protected void EnsureAuthorization(params Role[] roles)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            // Performance: Useless foreach was found.
            if (!roles.Any(role => this.CurrentUser.IsInRole(role)))
            {
                throw new AuthorizationFailedException("The current user is not authorized to perform this operation.");
            }
        }

        protected IView View(object model)
        {
            string fullNamespace = this.GetType().Namespace;

            int firstSeparatorIndex = fullNamespace.IndexOf(".");
            string baseNamespace = fullNamespace.Substring(0, firstSeparatorIndex);

            string controllerName = this.GetType().Name.Replace("Controller", string.Empty);
            string actionName = new StackTrace().GetFrame(1).GetMethod().Name;

            string fullPath = string.Format("{0}.Views.{1}.{2}", baseNamespace, controllerName, actionName);
            var viewType = Assembly.GetExecutingAssembly().GetType(fullPath);

            return Activator.CreateInstance(viewType, model) as IView;
        }
    }
}