namespace PizzaMore.Utility
{
    using Data;
    using Data.Models;

    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.IO;
    using System.Linq;
    using System.Net;

    public static class WebUtil
    {
        public static bool IsPost()
        {
            string requestMethod = Environment.GetEnvironmentVariable("REQUEST_METHOD");
            return requestMethod == "POST";
        }

        public static bool IsGet()
        {
            string requestMethod = Environment.GetEnvironmentVariable("REQUEST_METHOD");
            return requestMethod == "GET";
        }

        public static IDictionary<string, string> RetrieveGetParameters()
        {
            string queryString = Environment.GetEnvironmentVariable("QUERY_STRING");

            return RetrieveRequestParameters(queryString);
        }

        public static IDictionary<string, string> RetrievePostParameters()
        {
            string queryString = Console.ReadLine();

            return RetrieveRequestParameters(queryString);
        }

        public static ICookieCollection GetCookies()
        {
            string cookieString = Environment.GetEnvironmentVariable("HTTP_COOKIE");
            if (string.IsNullOrEmpty(cookieString))
            {
                return new CookieCollection();
            }

            var cookies = new CookieCollection();
            string[] cookieSaves = cookieString.Split(';');
            foreach (var cookieSave in cookieSaves)
            {
                string[] cookiePair = cookieSave.Split('=').Select(x => x.Trim()).ToArray();
                var cookie = new Cookie(cookiePair[0], cookiePair[1]);
                cookies.AddCookie(cookie);
            }
            return cookies;
        }

        public static Session GetSession()
        {
            ICookieCollection cookies = GetCookies();

            if (!cookies.ContainsKey("sid"))
            {
                return null;
            }
            else
            {
                Cookie cookie = cookies["sid"];
                using (PizzaMoreContext pizzaContext = new PizzaMoreContext())
                {
                    int sessionId = int.Parse(cookie.Value);
                    Session session = pizzaContext.Sessions.FirstOrDefault(s => s.Id == sessionId);
                    return session;
                }
            }
        }

        public static void PrintFileContent(string path)
        {
            string text = File.ReadAllText(path);

            Console.WriteLine(text);
        }

        public static void PageNotAllowed()
        {
            PrintFileContent(Constants.PageNotAllowedPath);
        }

        public static User GetUserByCookiesOrDefault(ICookieCollection requestCookies)
        {
            if (!requestCookies.ContainsKey(Constants.SessionCookieName))
            {
                return null;
            }

            int sid = int.Parse(requestCookies[Constants.SessionCookieName].Value);

            using (PizzaMoreContext pizzaContext = new PizzaMoreContext())
            {
                Session session = pizzaContext.Sessions.FirstOrDefault(c => c.Id == sid);

                if (session == null)
                {
                    return null;
                }

                // Including pizzas is a (performance) problem.
                User user = pizzaContext.Users.Include(u => u.Suggestions).FirstOrDefault(u => u.Id == session.UserId);

                return user;
            }
        }

        private static IDictionary<string, string> RetrieveRequestParameters(string queryString)
        {
            queryString = WebUtility.UrlDecode(queryString);

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            foreach (string keyValuePair in queryString.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries))
            {
                string[] pairInfo = keyValuePair.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                if (pairInfo.Length == 2)
                {
                    parameters.Add(pairInfo[0], pairInfo[1]);
                }
            }

            return parameters;
        }
    }
}
