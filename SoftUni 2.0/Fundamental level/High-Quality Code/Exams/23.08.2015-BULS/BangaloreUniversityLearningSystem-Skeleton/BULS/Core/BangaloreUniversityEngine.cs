using System;
using System.Linq;
using System.Reflection;
using Interfaces;
using Data;
using buls.Infrastructure;

namespace buls.Core
{
    public class बंगलौर_विश्वविद्यालय_इंजन : Iइंजन
    {
        public void रन()
        {
            var db = new BangaloreUniversityDate();
            User u = null;
            while (true)
            {
                string str = Console.ReadLine();
                if (str == null)
                {
                    break;
                }
                var route = new Route(str);
                var controllerType = Assembly.GetExecutingAssembly().GetTypes()
                    .FirstOrDefault(type => type.Name == route._controllerName)
                    ;
                var ctrl = Activator.CreateInstance(controllerType, db, u) as Controller;
                var act = controllerType.GetMethod(route._actionName);
                object[] @params = MapParameters(route, act);
                try {
                    var view = act.Invoke(ctrl, @params) as IView;
                    Console.WriteLine(view.Display());
                    u = ctrl.usr;
                } catch (Exception ex) {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
        }

        private static object[] MapParameters(Route route, MethodInfo action)
        {
            return action.GetParameters().Select<ParameterInfo, object>(p => { if (p.ParameterType == typeof(int)) return int.Parse(route._parameters[p.Name]); else return route._parameters[p.Name]; }).ToArray();
        }
    }
}
