namespace SoftUniGameStore.App.Routings
{
    using System.Collections.Generic;

    using Services;

    using SimpleHttpServer.Enums;
    using SimpleHttpServer.Models;

    using SimpleMVC.Routers;

    using Utilities;

    public static class Routes
    {
        public static IEnumerable<Route> GetRoutes()
        {
            
            IList<Route> routes = new List<Route>
            {
                new Route
                {
                    Name = "Controller/Action GET",
                    UrlRegex = "^/([a-zA-Z0-9]+)/([a-zA-Z0-9]+)(\\?[\\w=\\+]+)?$",
                    Method = RequestMethod.GET,
                    Callable = request => new ControllerRouter().Handle(request)
                },
                new Route
                {
                    Name = "Controller/Action POST",
                    UrlRegex = "^/([a-zA-Z0-9]+)/([a-zA-Z0-9]+)(\\?[\\w=\\+]+)?$",
                    Method = RequestMethod.POST,
                    Callable = request => new ControllerRouter().Handle(request)
                },
                new Route
                {
                    Name = "Public Files Service",
                    UrlRegex = "^/public/(.+)$",
                    Method = RequestMethod.GET,
                    Callable = request =>
                    {
                        string directory =
                            $"{Constants.WorkDirectory}{request.Url.TrimStart('/')}";

                        return new FileRouterService().Handle(request, directory);
                    }
                }
            };

            return routes;
        }
    }
}
