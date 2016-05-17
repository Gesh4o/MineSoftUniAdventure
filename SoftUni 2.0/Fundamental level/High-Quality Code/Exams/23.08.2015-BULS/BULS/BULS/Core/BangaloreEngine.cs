namespace UniversityLearningSystem.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using UniversityLearningSystem.Contracts;
    using UniversityLearningSystem.Data;
    using UniversityLearningSystem.Infrastructure;
    using UniversityLearningSystem.Models;

    public class BangaloreEngine : IEngine
    {
        public void Run()
        {
            var database = new BangaloreUniversityData();
            User user = null;
            while (true)
            {
                string input = Console.ReadLine();

                if (input == null)
                {
                    break;
                }

                var route = new Route(input);

                var controllerType = Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(type => type.Name == route.ControllerName);

                var controller = Activator.CreateInstance(controllerType, database, user) as Controller;
                var action = controllerType.GetMethod(route.ActionName);
                object[] parameters = MapParameters(route, action);

                try
                {
                    var view = action.Invoke(controller, parameters) as IView;
                    Console.WriteLine(view.Display());
                    user = controller.CurrentUser;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
        }

        private static object[] MapParameters(IRoute route, MethodInfo action)
        {
            var parameters = action
                .GetParameters()
                .Select<ParameterInfo, object>(p =>
                        {
                            if (p.ParameterType == typeof(int))
                            {
                                return int.Parse(route.Parameters[p.Name]);
                            }
                            else
                            {
                                return route.Parameters[p.Name];
                            }
                        }).ToArray();
            return parameters;
        }
    }
}
