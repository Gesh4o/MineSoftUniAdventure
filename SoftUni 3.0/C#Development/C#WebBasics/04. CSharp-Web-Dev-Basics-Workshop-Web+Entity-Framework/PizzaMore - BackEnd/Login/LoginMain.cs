namespace Login
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using PizzaMore.Data;
    using PizzaMore.Data.Models;
    using PizzaMore.Utility;

    class LoginMain
    {
        static void Main(string[] args)
        {
            try
            {
                Header head = new Header();

                if (WebUtil.IsGet())
                {
                    head.Print();
                    WebUtil.PrintFileContent(Constants.LoginPath);
                }
                else if (WebUtil.IsPost())
                {
                    IDictionary<string, string> parameters = WebUtil.RetrievePostParameters();

                    string email = parameters["email"];
                    string password = parameters["password"];

                    password = PasswordHasher.HashPassword(password);

                    using (PizzaMoreContext pizzaContext = new PizzaMoreContext())
                    {
                        User user = pizzaContext.Users.FirstOrDefault(u => u.Email == email & u.Password == password);

                        if (user == null)
                        {
                            head.Print();
                            WebUtil.PrintFileContent(Constants.LoginPath);
                        } 
                        else
                        {
                            Session session = new Session() { User = user };
                            pizzaContext.Sessions.Add(session);
                            pizzaContext.SaveChanges();

                            Cookie sessionCookie = new Cookie(Constants.SessionCookieName, session.Id.ToString());
                            head.Cookies.AddCookie(sessionCookie);

                            head.Print();
                            WebUtil.PrintFileContent(Constants.LoginPath);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString());
            }
        }
    }
}
