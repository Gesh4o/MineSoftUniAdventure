namespace Home
{
    using System;
    using System.Collections.Generic;

    using PizzaMore.Utility;
    using PizzaMore.Data.Models;
    using PizzaMore.Data;

    class PizzaMoreMain
    {
        static void Main(string[] args)
        {
            try
            {
                Home.AddDefaultLanguageCookie();

                IDictionary<string, string> parameters;
                ICookieCollection cookies = Home.Header.Cookies;
                if (WebUtil.IsGet())
                {
                    parameters = WebUtil.RetrieveGetParameters();

                    if (parameters.ContainsKey("logout"))
                    {
                        bool shouldLogOut = parameters["logout"] == "true";

                        if (shouldLogOut)
                        {
                            LogOut();
                        }
                    }
                }
                else if (WebUtil.IsPost())
                {
                    Home.RequestParameters = WebUtil.RetrievePostParameters();
                    string language = Home.RequestParameters["language"];

                    if (Home.Header.Cookies.ContainsKey("lang"))
                    {
                        Home.Header.Cookies["lang"].Value = language;
                    }
                    else
                    {
                        Home.Header.Cookies.AddCookie(new Cookie("lang", language));
                    }

                    Home.Language = language;
                }

                ShowPage();
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString());
                Logger.Log(e.StackTrace);
            }
        }

        private static void LogOut()
        {
            Session session = WebUtil.GetSession();

            using (PizzaMoreContext pizzaContext = new PizzaMoreContext())
            {
                pizzaContext.Sessions.Attach(session);
                pizzaContext.Sessions.Remove(session);
                pizzaContext.SaveChanges();
            }
        }

        private static void ShowPage()
        {
            Home.Header.Print();

            if (Home.Language == "EN")
            {
                ServeHtmlEn();
            }
            else if (Home.Language == "DE")
            {
                ServerHtmlDe();
            }
        }

        private static void ServerHtmlDe()
        {
            WebUtil.PrintFileContent("D:/wamp64/www/pm/home-de.html");
        }

        private static void ServeHtmlEn()
        {
            WebUtil.PrintFileContent("D:/wamp64/www/pm/home.html");
        }
    }
}
