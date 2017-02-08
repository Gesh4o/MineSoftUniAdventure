namespace PizzaDetails
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using PizzaMore.Data;
    using PizzaMore.Data.Models;
    using PizzaMore.Utility;


    public class PizzaDetailsMain
    {
        static void Main(string[] args)
        {
            Header head = new Header();
            head.Print();

            if (WebUtil.IsGet())
            {
                using (PizzaMoreContext pizzaContext = new PizzaMoreContext())
                {
                    Session session = WebUtil.GetSession();

                    if (session == null)
                    {
                        WebUtil.PageNotAllowed();
                        return;
                    }

                    IDictionary<string, string> parameters = WebUtil.RetrieveGetParameters();
                    int pizzaId = int.Parse(parameters["pizzaId"]);
                    Pizza pizza = pizzaContext.Pizzas.SingleOrDefault(p => p.Id == pizzaId);

                    PrintPizza(pizza);
                }
            }
        }

        private static void PrintPizza(Pizza pizza)
        {
            Console.WriteLine("<!doctype html><html lang=\"en\"><head><meta charset=\"UTF-8\" /><title>PizzaMore - Details</title><meta name=\"viewport\" content=\"width=device-width, initial-scale=1\" /><link rel=\"stylesheet\" href=\"/pm/bootstrap/css/bootstrap.min.css\" /><link rel=\"stylesheet\" href=\"/pm/css/signin.css\" /></head><body><div class=\"container\">");
            Console.WriteLine("<div class=\"jumbotron\">");
            Console.WriteLine("<a class=\"btn btn-danger\" href=\"Menu.exe\">All Suggestions</a>");
            Console.WriteLine($"<h3>{pizza.Title}</h3>");
            Console.WriteLine($"<img src=\"{pizza.ImageUrl}\" width=\"300px\"/>");
            Console.WriteLine($"<p>{pizza.Recipe}</p>");
            Console.WriteLine($"<p>Up: {pizza.Upvotes}</p>");
            Console.WriteLine($"<p>Down: {pizza.Downvotes}</p>");
            Console.WriteLine("</div>");
            Console.WriteLine("</div><script src=\"/pm/jquery/jquery-3.1.1.js\"></script><script src=\"/pm/bootstrap/js/bootstrap.min.js\"></script></body></html>");
        }
    }
}
