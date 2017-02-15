namespace SimpleMVC.App.MVC.Routers
{
    using Attributes.Methods;
    using Controllers;
    using Interfaces;
    using SimpleHttpServer.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Reflection;

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
            this.getParams = RetrieveGetParameters(request.Url);

            this.postParams = RetrievePostParameters(request.Content);

            this.requestMethod = request.Method.ToString();

            Tuple<string, string> controllerAndActionNames = this.GetControllerAndActionName(request.Url);
            this.controllerName = controllerAndActionNames.Item1;
            this.actionName = controllerAndActionNames.Item2;

            MethodInfo method = this.GetMethod();

            if (method == null)
            {
                throw new NotSupportedException("Method not supported!");
            }

            this.SetMethodParameters(method);

            IInvocable actionResult = (IInvocable)this.GetMethod().Invoke(this.GetController(this.controllerName), this.methodParams);

            string content = actionResult.Invoke();

            HttpResponse response = new HttpResponse() { ContentAsUTF8 = content };

            return response;
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
                        this.postParams[this.ToCamelCase(bindingModelProperty.Name)],
                        bindingModelProperty.PropertyType));
            }

            this.methodParams[index] = Convert.ChangeType
                (bindingModel, bindingModel.GetType());
        }

        private string ToCamelCase(string text)
        {
            return text[0].ToString().ToLower() + text.Substring(1);
        }

        private void SetPrimitiveParameterValue(int index, ParameterInfo param)
        {
            object value = this.getParams[param.Name];
            this.methodParams[index] =
                Convert.ChangeType(
                    value,
                    param.ParameterType);
        }

        private MethodInfo GetMethod()
        {
            MethodInfo method = null;

            foreach (MethodInfo methodInfo in this.GetMethods(this.controllerName, this.actionName))
            {
                IEnumerable<Attribute> attributes = methodInfo.GetCustomAttributes().Where(a => a is HttpMethodAttribute);

                if (!attributes.Any())
                {
                    return methodInfo;
                }

                foreach (HttpMethodAttribute attr in attributes)
                {
                    if (attr.IsValid(this.requestMethod))
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
        private IEnumerable<MethodInfo> GetMethods(string className, string methodName)
        {
            return this.GetController(className).GetType().GetMethods().Where(m => m.Name == methodName);
        }

        private Controller GetController(string className)
        {
            string controllerType = string.Format(
                "{0}.{1}.{2}",
                MvcContext.Instance.AssemblyName,
                MvcContext.Instance.ControllersFolder,
                className);

            Controller controller = (Controller)Activator.CreateInstance(Type.GetType(controllerType));
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
            string[] splitArgs = url.Split('/').Select(c => c.Trim()).ToArray();
            if (splitArgs.Length != 3)
            {
                return Tuple.Create("Invalid Url", "Invalid Url");
            }
            else
            {
                string controller = splitArgs[1];
                string action = splitArgs[2];
                int questionMarkIndex = action.IndexOf('?');
                if (questionMarkIndex >= 0)
                {
                    action = action.Substring(0, questionMarkIndex);
                }

                if (!string.IsNullOrEmpty(controller) && !string.IsNullOrEmpty(controller))
                {
                    return Tuple.Create(ToTitleCase(controller) + MvcContext.Instance.ControllersSuffix, ToTitleCase(action));
                }
                else
                {
                    return Tuple.Create("Invalid Url", "Invalid Url");
                }
            }
        }

        /// <summary>
        /// Replaces the first char with uppercase one (if possible).
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private string ToTitleCase(string text)
        {
            string firstChar = text[0].ToString();
            return firstChar.ToUpper() + text.Substring(1);
        }

        private IDictionary<string, string> RetrievePostParameters(string paramsString)
        {
            return this.RetrieveParameters(paramsString);
        }

        private IDictionary<string, string> RetrieveGetParameters(string url)
        {
            int questionMarkIndex = url.IndexOf('?');
            if (questionMarkIndex > 0)
            {
                string queryArgs = url.Substring(questionMarkIndex + 1);
                Dictionary<string, string> parameters = RetrieveParameters(queryArgs);

                return parameters;
            }
            else
            {
                return new Dictionary<string, string>();
            }
        }

        private Dictionary<string, string> RetrieveParameters(string paramsString)
        {
            if (string.IsNullOrEmpty(paramsString))
            {
                return new Dictionary<string, string>();
            }
            paramsString = WebUtility.UrlDecode(paramsString);
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            string[] parametersPairs = paramsString.Split('&').Select(p => p.Trim()).ToArray();

            foreach (string pair in parametersPairs)
            {
                string[] tokens = pair.Split('=').Select(p => p.Trim()).ToArray();
                string key = tokens[0];
                string value = tokens[1];

                parameters.Add(key, value);
            }

            return parameters;
        }
    }
}