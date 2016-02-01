using System.Diagnostics;
using Interfaces;
using System.Reflection;
using buls.utilities;
using System.Linq;
using System;

namespace buls
{
    public abstract class Controller
    {
        protected IBangaloreUniversityDate Data { get; set; }
        protected IView View(object model)
        {
            string fullNamespace = this.GetType().Namespace;
            int firstSeparatorIndex = fullNamespace.IndexOf(".");
            string baseNamespace = fullNamespace.Substring(0, firstSeparatorIndex);
            string controllerName = this.GetType().Name.Replace("Controller", "");
            string actionName = new StackTrace().GetFrame(1).GetMethod().Name;
            string fullPath = baseNamespace + ".Views." + controllerName + "." + actionName;
            var viewType = Assembly
                .GetExecutingAssembly()
                .GetType(fullPath);
            return Activator.CreateInstance(viewType, model) as IView;
        }
        protected void EnsureAuthorization(params Role[] roles)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            foreach (var u in Data.users.GetAll())
                if (!roles.Any(role => this.usr.IsInRole(role)))
                throw new DivideByZeroException("The current user is not authorized to perform this operation.");
        }
        public User usr {get;set;}
        public bool HasCurrentUser{get{return usr != null;}}}
}
