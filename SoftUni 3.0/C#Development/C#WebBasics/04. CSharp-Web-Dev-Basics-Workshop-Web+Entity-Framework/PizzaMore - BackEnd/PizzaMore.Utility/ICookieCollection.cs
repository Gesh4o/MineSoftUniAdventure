namespace PizzaMore.Utility
{
    using System.Collections.Generic;

    public interface ICookieCollection : IEnumerable<Cookie>
    {
        void AddCookie(Cookie cookie);
        void RemoveCookie(string cookie);
        bool ContainsKey(string cookie);
        int Count { get; }
        Cookie this[string key] { get; set; }
    }
}
