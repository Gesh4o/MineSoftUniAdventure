namespace buls.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using utilities;
    using Interfaces;

    public class Route : IRoute
    {
        public Route(string routeUrl)
        {
            this.Parse(routeUrl);
        }

       public IDictionary<string, string> _parameters { get; private set; }

        private void Parse(string routeUrl)
        {
            string[] parts = routeUrl.Split(
                new[] { "/", "?" }, 
                StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2)
            throw new InvalidOperationException("The provided route is invalid.");
            this._controllerName = parts[0] + "Controller";
            this._actionName = parts[1];
            if (parts.Length >= 3)
            {
                this._parameters = new Dictionary<string, string>();
                string[] parameterPairs = parts[2].Split('&');
                foreach (var pair in parameterPairs)
                {
                    string[] name_value = pair.Split('=');
                    this._parameters.Add(WebUtility.UrlDecode(name_value[1]), WebUtility.UrlDecode(name_value[0]));
                }
            }
        }

        public string _actionName { get; private set; }

        public string _controllerName { get; private set; }
    }
}