namespace SimpleMVC.App.MVC.Controllers
{
    using System.Runtime.CompilerServices;

    using Interfaces;
    using Interfaces.Generic;
    using ViewEngine;
    using ViewEngine.Generic;

    public abstract class Controller
    {
        protected IActionResult View([CallerMemberName] string callee = "")
        {
            string controllerName = this.GetType()
                .Name
                .Replace(
                        MvcContext.Instance.ControllersSuffix, string.Empty
                        );

            string viewName = string.Format("{0}.{1}.{2}.{3}",
                MvcContext.Instance.AssemblyName,
                MvcContext.Instance.ViewsFolder,
                controllerName,
                callee);

            return new ActionResult(viewName);
        }

        protected IActionResult View(string controller, string action)
        {
            string viewName = string.Format("{0}.{1}.{2}.{3}",
                MvcContext.Instance.AssemblyName,
                MvcContext.Instance.ViewsFolder,
                controller,
                action);

            return new ActionResult(viewName);
        }

        protected IActionResult<T> View<T>(T model, [CallerMemberName]string callee = "")
        {
            string controllerName = this.GetType()
                .Name
                .Replace(
                        MvcContext.Instance.ControllersSuffix, string.Empty
                        );

            string viewName = string.Format("{0}.{1}.{2}.{3}",
                MvcContext.Instance.AssemblyName,
                MvcContext.Instance.ViewsFolder,
                controllerName,
                callee);

            return new ActionResult<T>(viewName, model);
        }

        protected IActionResult<T> View<T>(T model, string controller, string action)
        {
            string viewName = string.Format("{0}.{1}.{2}.{3}",
                MvcContext.Instance.AssemblyName,
                MvcContext.Instance.ViewsFolder,
                controller,
                action);

            return new ActionResult<T>(viewName, model);
        }
    }
}