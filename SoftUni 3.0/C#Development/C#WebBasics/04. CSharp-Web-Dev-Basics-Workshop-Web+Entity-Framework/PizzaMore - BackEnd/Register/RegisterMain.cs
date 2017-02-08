namespace Register
{
    using System;
    using System.Collections.Generic;

    using PizzaMore.Utility;
    using PizzaMore.Data;
    using PizzaMore.Data.Models;

    public class RegisterMain
    {
        static void Main(string[] args)
        {
            try
            {
                Header head = new Header();
                head.Print();

                if (WebUtil.IsGet())
                {
                    WebUtil.PrintFileContent(Constants.RegisterPath);
                }
                else if (WebUtil.IsPost())
                {
                    IDictionary<string, string> parameters =  WebUtil.RetrievePostParameters();
                    string email = parameters["email"];
                    string password = parameters["password"];
                    password = PasswordHasher.HashPassword(password);

                    using (PizzaMoreContext pizzaContext = new PizzaMoreContext())
                    {
                        pizzaContext.Users.Add(new User() { Email = email, Password = password });
                        pizzaContext.SaveChanges();
                    }

                    WebUtil.PrintFileContent(Constants.RegisterPath);
                }
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString());
            }
        }
    }
}
