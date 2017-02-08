namespace AddPizza
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using PizzaMore.Data;
    using PizzaMore.Data.Models;
    using PizzaMore.Utility;

    public class AddPizzaMain
    {
        static void Main(string[] args)
        {
            try
            {
                Header head = new Header();
                head.Print();
                ICookieCollection requestCookies = WebUtil.GetCookies();

                if (!requestCookies.ContainsKey(Constants.SessionCookieName))
                {
                    WebUtil.PageNotAllowed();
                    return;
                }

                int sid = int.Parse(requestCookies[Constants.SessionCookieName].Value);
                using (PizzaMoreContext pizzaMoreContext = new PizzaMoreContext())
                {
                    Session session = pizzaMoreContext.Sessions.FirstOrDefault(s => s.Id == sid);

                    if (session == null)
                    {
                        WebUtil.PageNotAllowed();
                        return;
                    }

                    if (WebUtil.IsGet())
                    {
                        WebUtil.PrintFileContent(Constants.AddPizzaPath);
                    }
                    else if (WebUtil.IsPost())
                    {
                        IDictionary<string, string> parameters = WebUtil.RetrievePostParameters();

                        string pizzaTitle = parameters["title"];
                        string pizzaRecipe = parameters["recipe"];
                        string pizzaImgUlr = parameters["url"];

                        Pizza pizza = new Pizza() { Title = pizzaTitle, Recipe = pizzaRecipe, ImageUrl = pizzaImgUlr, OwnerId = session.UserId };
                        pizzaMoreContext.Pizzas.Add(pizza);
                        pizzaMoreContext.SaveChanges();

                        WebUtil.PrintFileContent(Constants.AddPizzaPath);
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
