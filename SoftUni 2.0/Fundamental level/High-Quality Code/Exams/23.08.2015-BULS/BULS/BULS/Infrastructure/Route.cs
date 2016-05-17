namespace UniversityLearningSystem.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Net;

    using UniversityLearningSystem.Contracts;

    public class Route : IRoute
    {
        public Route(string routeUrl)
        {
            this.Parse(routeUrl);
        }

        public string ActionName { get; private set; }

        public string ControllerName { get; private set; }

        public IDictionary<string, string> Parameters { get; private set; }

        private void Parse(string inputUrl)
        {
            string[] inputArgs = inputUrl.Split(new[] { "/", "?" }, StringSplitOptions.RemoveEmptyEntries);
            if (inputArgs.Length < 2)
            {
                throw new InvalidOperationException("The provided route is invalid.");
            }

            this.ControllerName = inputArgs[0] + "Controller";
            this.ActionName = inputArgs[1];
            if (inputArgs.Length >= 3)
            {
                this.Parameters = new Dictionary<string, string>();
                string[] parameterPairs = inputArgs[2].Split('&');
                foreach (var pair in parameterPairs)
                {
                    string[] nameAndValue = pair.Split('=');
                    this.Parameters.Add(WebUtility.UrlDecode(nameAndValue[0]), WebUtility.UrlDecode(nameAndValue[1]));
                }
            }
        }
    }
}