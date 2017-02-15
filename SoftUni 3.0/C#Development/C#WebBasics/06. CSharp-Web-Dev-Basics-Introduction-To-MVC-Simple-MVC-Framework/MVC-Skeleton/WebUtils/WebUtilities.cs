namespace WebUtils
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    public static class WebUtilities
    {
        public static IDictionary<string, string> RetrievePostParameters(string paramsString)
        {
            return RetrieveParameters(paramsString);
        }

        public static IDictionary<string, string> RetrieveGetParameters(string url)
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

        private static Dictionary<string, string> RetrieveParameters(string paramsString)
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

        /// <summary>
        /// Gets navigation parameters (like controller name and action name) from url string.
        /// e.g: example.com/user/profile?id=3 will return array => [0] - user ; [1] - profile.
        /// </summary>
        /// <param name="url">Url to parse for parameters</param>
        /// <returns>Action parameters or null if url is invalid</returns>
        public static string[] GetRouteNavigation(string url)
        {
            int questionMarkIndex = url.IndexOf('?');
            if (questionMarkIndex >= 0)
            {
                url = url.Substring(0, questionMarkIndex);
            }

            string[] splitArgs = url.Split('/').Select(c => c.Trim()).Skip(1).ToArray();

            if (splitArgs.Any(a => string.IsNullOrEmpty(a)))
            {
                return null;
            }

            return splitArgs;
        }
    }
}
