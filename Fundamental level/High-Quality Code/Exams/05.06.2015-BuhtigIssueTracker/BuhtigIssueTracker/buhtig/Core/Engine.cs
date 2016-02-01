namespace BuhtigIssueTracker.Core
{
    using System;

    using BuhtigIssueTracker.Contracts;
    using BuhtigIssueTracker.Infrastructure;

    public class Engine : IEngine
    {
        public Engine(UrlDispatcher urlDispatcher)
        {
            this.UrlDispatcher = urlDispatcher;
        }

        public Engine()
            : this(new UrlDispatcher())
        {
        }

        public UrlDispatcher UrlDispatcher { get; private set; }

        public void Run()
        {
            while (true)
            {
                string url = Console.ReadLine();
                if (url == null)
                {
                    break;
                }

                url = url.Trim();

                if (!string.IsNullOrEmpty(url))
                {
                    try
                    {
                        var endpoint = new Endpoint(url);
                        string viewResult = this.UrlDispatcher.DispatchAction(endpoint);
                        Console.WriteLine(viewResult);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
