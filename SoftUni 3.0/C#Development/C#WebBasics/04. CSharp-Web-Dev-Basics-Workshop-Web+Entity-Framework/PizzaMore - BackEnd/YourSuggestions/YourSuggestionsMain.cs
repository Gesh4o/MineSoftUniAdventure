namespace YourSuggestions
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using PizzaMore.Data.Models;
    using PizzaMore.Utility;
    using PizzaMore.Data;

    public class YourSuggestionsMain
    {
        static void Main(string[] args)
        {
            Header head = new Header();
            head.Print();

            ICookieCollection requestCookies = WebUtil.GetCookies();

            Session session = WebUtil.GetSession();
            using (PizzaMoreContext pizzaContext = new PizzaMoreContext())
            {
                if (session == null)
                {
                    WebUtil.PageNotAllowed();
                    return;
                }

                User user = pizzaContext.Users.Include(u => u.Suggestions).SingleOrDefault(u => u.Id == session.UserId);

                if (WebUtil.IsGet())
                {
                    PrintPage(user);
                }
                else if (WebUtil.IsPost())
                {
                    IDictionary<string, string> parameters = WebUtil.RetrievePostParameters();
                    int pizzaId = int.Parse(parameters["pizzaId"]);

                    Pizza pizza = pizzaContext.Pizzas.FirstOrDefault(p => p.Id == pizzaId);

                    user.Suggestions.Remove(pizza);
                    pizzaContext.Pizzas.Remove(pizza);
                    pizzaContext.SaveChanges();

                    PrintPage(user);
                }
            }
        }

        private static void PrintPage(User user)
        {
            WebUtil.PrintFileContent(Constants.YourSuggestionsTopPath);
            Console.WriteLine("<ul>");
            foreach (var suggestion in user.Suggestions)
            {
                Console.WriteLine("<form method=\"POST\">");
                Console.WriteLine($"<li><a href=\"PizzaDetails.exe?pizzaId={suggestion.Id}\">{suggestion.Title}</a> <input type=\"hidden\" name=\"pizzaId\" value=\"{suggestion.Id}\"/> <input type=\"submit\" class=\"btn btn-sm btn-danger\" value=\"X\"/></li>");
                Console.WriteLine("</form>");
            }
            Console.WriteLine("</ul>");
            WebUtil.PrintFileContent(Constants.YourSuggestionsBottomPath);
        }
    }
}
