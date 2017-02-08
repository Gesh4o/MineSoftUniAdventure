namespace Home
{
    using System.Collections.Generic;
    using System.Linq;

    using PizzaMore.Data.Models;
    using PizzaMore.Utility;

    public class Home
    {
        public static IDictionary<string, string> RequestParameters { get; set; }

        public static Session Session { get; set; }

        public static Header Header { get; set; } = new Header();

        public static string Language { get; set; }

        public static void AddDefaultLanguageCookie()
        {
            ICookieCollection cookies = WebUtil.GetCookies();
            Cookie langCookie = cookies.FirstOrDefault(c => c.Name == "lang");
            if (langCookie == null)
            {
                Header.Cookies.AddCookie(new Cookie("lang", "EN"));
            }
            else
            {
                Header.Cookies.AddCookie(new Cookie("lang", langCookie.Value));
            }

            Language = Header.Cookies["lang"].Value;
        }
    }
}
