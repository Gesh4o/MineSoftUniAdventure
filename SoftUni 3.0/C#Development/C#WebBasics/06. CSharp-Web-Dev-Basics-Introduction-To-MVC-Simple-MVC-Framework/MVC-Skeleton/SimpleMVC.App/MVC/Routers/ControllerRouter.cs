namespace SimpleMVC.App.MVC.Routers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Attributes.Methods;
    using Controllers;
    using Interfaces;
    using SimpleHttpServer.Models;
    using WebUtils;
    using SimpleHttpServer;

    public class ControllerRouter : IHandleable
    {
        private IDictionary<string, string> getParams;

        private IDictionary<string, string> postParams;

        private string requestMethod;

        private string controllerName;

        private string actionName;

        private object[] methodParams;

        public HttpResponse Handle(HttpRequest request)
        {
            this.getParams = WebUtilities.RetrieveGetParameters(request.Url);

            this.postParams = WebUtilities.RetrievePostParameters(request.Content);

            this.requestMethod = request.Method.ToString();

            Tuple<string, string> controllerAndActionNames = this.GetControllerAndActionName(request.Url);

            if (controllerAndActionNames == null)
            {
                return HttpResponseBuilder.NotFound();
            }

            this.controllerName = controllerAndActionNames.Item1;
            this.actionName = controllerAndActionNames.Item2;

            MethodInfo method = this.GetControllerMethod(this.controllerName, this.actionName, this.requestMethod);

            if (method == null)
            {
                throw new NotSupportedException("Method not supported!");
            }

            this.SetMethodParameters(method);

            IInvocable actionResult = (IInvocable)this.GetControllerMethod(
                this.controllerName, 
                this.actionName, 
                this.requestMethod)
                .Invoke(
                this.GetController(this.GetControllerTypeName(this.controllerName)),
                this.methodParams);

            string content = actionResult.Invoke();

            HttpResponse response = new HttpResponse() { ContentAsUTF8 = content };

            return response;
        }

        public Controller GetController(string controllerTypeName)
        {
            Controller controller = (Controller)Activator.CreateInstance(Type.GetType(controllerTypeName));
            return controller;
        }

        /// <summary>
        /// Returns Tuple with first item controller name and second item action name base on string url
        /// e.g: example.com/home/index - HomeController/Index.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private Tuple<string, string> GetControllerAndActionName(string url)
        {
            string[] splitArgs = WebUtilities.GetRouteNavigation(url);
            if (splitArgs == null || splitArgs.Length != 2)
            {
                return null;
            }
            else
            {
                string controller = StringUtilities.ToTitleCase(splitArgs[0]);
                string action = StringUtilities.ToTitleCase(splitArgs[1]);

                return Tuple.Create(controller + MvcContext.Instance.ControllersSuffix, action);
            }
        }

        private MethodInfo GetControllerMethod(string controllerName, string actionName, string requestMethod)
        {
            MethodInfo method = null;

            foreach (MethodInfo methodInfo in this.GetMethods(controllerName, actionName))
            {
                IEnumerable<Attribute> attributes = methodInfo.GetCustomAttributes().Where(a => a is HttpMethodAttribute);

                if (!attributes.Any())
                {
                    return methodInfo;
                }

                foreach (HttpMethodAttribute attr in attributes)
                {
                    if (attr.IsValid(requestMethod))
                    {
                        return methodInfo;
                    }
                }
            }

            return method;
        }

        /// <summary>
        /// Get respective methods info from respective class.
        /// </summary>
        /// <param name="methodName"></param>
        /// <returns></returns>
        private IEnumerable<MethodInfo> GetMethods(string controllerName, string methodName)
        {
            controllerName = this.GetControllerTypeName(controllerName);
            return this.GetController(controllerName).GetType().GetMethods().Where(m => m.Name == methodName);
        }

        private string GetControllerTypeName(string controllerName)
        {
            string controllerType = string.Format(
                                            "{0}.{1}.{2}",
                                            MvcContext.Instance.AssemblyName,
                                            MvcContext.Instance.ControllersFolder,
                                            controllerName);

            return controllerType;
        }

        private void SetMethodParameters(MethodInfo method)
        {
            IEnumerable<ParameterInfo> parametersInfo = method.GetParameters();

            this.methodParams = new object[parametersInfo.Count()];

            int index = 0;

            foreach (ParameterInfo param in parametersInfo)
            {
                if (param.ParameterType.IsPrimitive)
                {
                    this.SetPrimitiveParameterValue(index, param);
                }
                else if (param.ParameterType.IsClass)
                {
                    this.SetComplexParameterValue(index, param);
                }

                index++;
            }
        }

        private void SetComplexParameterValue(int index, ParameterInfo param)
        {
            Type bindingModelType = param.ParameterType;
            object bindingModel = Activator.CreateInstance(bindingModelType);

            IEnumerable<PropertyInfo> bindingModelProperties = bindingModel.GetType().GetProperties();

            foreach (PropertyInfo bindingModelProperty in bindingModelProperties)
            {
                bindingModelProperty.SetValue(bindingModel,
                    Convert.ChangeType(
                        this.postParams[StringUtilities.ToCamelCase(bindingModelProperty.Name)],
                        bindingModelProperty.PropertyType));
            }

            this.methodParams[index] = Convert.ChangeType
                (bindingModel, bindingModel.GetType());
        }

        private void SetPrimitiveParameterValue(int index, ParameterInfo param)
        {
            object value = this.getParams[param.Name];
            this.methodParams[index] =
                Convert.ChangeType(
                    value,
                    param.ParameterType);
        }
    }
}