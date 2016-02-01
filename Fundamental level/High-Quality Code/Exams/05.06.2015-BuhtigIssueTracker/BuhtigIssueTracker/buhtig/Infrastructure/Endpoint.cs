namespace BuhtigIssueTracker.Infrastructure
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    using BuhtigIssueTracker.Contracts;

    public class Endpoint : IEndpoint
    {
        public Endpoint(string url)
        {
            this.Initialize(url);
        }

        public string ActionName { get; set; }

        public IDictionary<string, string> Parameters { get; set; }

        private void Initialize(string url)
        {
            int questionMarkIndex = url.IndexOf('?');
            if (questionMarkIndex != -1)
            {
                this.ActionName = url.Substring(0, questionMarkIndex);
                var pairs =
                    url.Substring(questionMarkIndex + 1)
                        .Split('&')
                        .Select(parameter => parameter.Split('=').Select(pair => WebUtility.UrlDecode(pair)).ToArray());

                var parameters = new Dictionary<string, string>();

                foreach (var pair in pairs)
                {
                    parameters.Add(pair[0], pair[1]);
                }

                this.Parameters = parameters;
            }
            else
            {
                this.ActionName = url;
            }
        }
    }
}
