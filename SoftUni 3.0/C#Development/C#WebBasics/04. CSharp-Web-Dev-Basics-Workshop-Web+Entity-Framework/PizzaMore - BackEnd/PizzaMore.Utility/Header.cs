namespace PizzaMore.Utility
{
    using System;
    using System.Text;

    public class Header
    {
        private const string DefaultHeaderType = "Content-type: text/html";
        public Header()
        {
            this.Type = DefaultHeaderType;
            this.Cookies = new CookieCollection();
        }

        public string Type { get; private set; }

        public string Location { get; private set; }

        public ICookieCollection Cookies { get; set; }

        public void AddLocation(string location)
        {
            this.Location = $"Location: {location}";
        }

        public void AddCookie(Cookie cookie)
        {
            this.Cookies.AddCookie(cookie);
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            StringBuilder headerSB = new StringBuilder();
            headerSB.AppendLine(this.Type);

            foreach (Cookie cookie in this.Cookies)
            {
                headerSB.AppendLine($"Set-Cookie: {cookie.ToString()}");
            }

            if (!string.IsNullOrEmpty(this.Location))
            {
                headerSB.AppendLine(this.Location);
            }

            return headerSB.AppendLine().ToString();
        }
    }
}
