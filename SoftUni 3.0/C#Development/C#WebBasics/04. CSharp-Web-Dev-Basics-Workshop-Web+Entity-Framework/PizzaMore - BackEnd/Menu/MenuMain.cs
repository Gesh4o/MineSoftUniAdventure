namespace Menu
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using PizzaMore.Utility;
    using PizzaMore.Data.Models;
    using PizzaMore.Data;

    class MenuMain
    {
        static void Main(string[] args)
        {
            try
            {
                Header head = new Header();
                head.Print();

                ICookieCollection requestCookies = WebUtil.GetCookies();
                if (WebUtil.IsGet())
                {
                    User user = WebUtil.GetUserByCookiesOrDefault(requestCookies);

                    if (user == null)
                    {
                        WebUtil.PageNotAllowed();
                        return;
                    }

                    PrintPage(user);
                }
                else if (WebUtil.IsPost())
                {
                    User user = WebUtil.GetUserByCookiesOrDefault(requestCookies);

                    if (user == null)
                    {
                        WebUtil.PageNotAllowed();
                        return;
                    }

                    VoteForPizza();

                    PrintPage(user);
                }
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString());
            }
        }

        private static void VoteForPizza()
        {
            IDictionary<string, string> parameters = WebUtil.RetrievePostParameters();
            string vote = parameters["pizzaVote"];
            int pizzaId = int.Parse(parameters["pizzaId"]);
            using (PizzaMoreContext pizzaContext = new PizzaMoreContext())
            {
                Pizza pizza = pizzaContext.Pizzas.FirstOrDefault(p => p.Id == pizzaId);

                if (pizza == null)
                {
                    WebUtil.PageNotAllowed();
                    return;
                }

                if (vote == "up")
                {
                    pizza.Upvotes++;
                }
                else if (vote == "down")
                {
                    pizza.Downvotes++;
                }

                pizzaContext.SaveChanges();
            }
        }

        private static void PrintPage(User user)
        {
            WebUtil.PrintFileContent(Constants.MenuTopPath);
            PrintNavBar(user);
            PrintAllSuggestions(user.Suggestions.ToList());
            WebUtil.PrintFileContent(Constants.MenuBotPath);
        }

        private static void PrintAllSuggestions(ICollection<Pizza> pizzas)
        {
            Logger.Log(pizzas.Count.ToString());
            Console.WriteLine("<div class=\"card-deck\">");
            foreach (var pizza in pizzas)
            {
                Console.WriteLine("<div class=\"card\">");
                Console.WriteLine($"<img class=\"card-img-top\" src=\"{pizza.ImageUrl}\" width=\"200px\"alt=\"Card image cap\">");
                Console.WriteLine("<div class=\"card-block\">");
                Console.WriteLine($"<h4 class=\"card-title\">{pizza.Title}</h4>");
                Console.WriteLine($"<p class=\"card-text\"><a href=\"PizzaDetails.exe?pizzaId={pizza.Id}\">Recipe</a></p>");
                Console.WriteLine("<form method=\"POST\">");
                Console.WriteLine($"<div class=\"radio\"><label><input type = \"radio\" name=\"pizzaVote\" value=\"up\">Up</label></div>");
                Console.WriteLine($"<div class=\"radio\"><label><input type = \"radio\" name=\"pizzaVote\" value=\"down\">Down</label></div>");
                Console.WriteLine($"<input type=\"hidden\" name=\"pizzaId\" value=\"{pizza.Id}\" />");
                Console.WriteLine("<input type=\"submit\" class=\"btn btn-primary\" value=\"Vote\" />");
                Console.WriteLine("</form>");
                Console.WriteLine("</div>");
                Console.WriteLine("</div>");
            }
            Console.WriteLine("</div>");
        }

        private static void PrintNavBar(User user)
        {
            Console.WriteLine("<nav class=\"navbar navbar-default\">" +
                "<div class=\"container-fluid\">" +
                "<div class=\"navbar-header\">" +
                "<a class=\"navbar-brand\" href=\"Home.exe\">PizzaMore</a>" +
                "</div>" +
                "<div class=\"collapse navbar-collapse\" id=\"bs-example-navbar-collapse-1\">" +
                "<ul class=\"nav navbar-nav\">" +
                "<li ><a href=\"AddPizza.exe\">Suggest Pizza</a></li>" +
                "<li><a href=\"YourSuggestions.exe\">Your Suggestions</a></li>" +
                "</ul>" +
                "<ul class=\"nav navbar-nav navbar-right\">" +
                "<p class=\"navbar-text navbar-right\"></p>" +
                "<p class=\"navbar-text navbar-right\"><a href=\"Home.exe?logout=true\" class=\"navbar-link\">Sign Out</a></p>" +
                $"<p class=\"navbar-text navbar-right\">Signed in as {user.Email}</p>" +
                "</ul> </div></div></nav>");
        }
    }
}
