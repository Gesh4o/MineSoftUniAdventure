namespace SimpleMVC.App
{
    using SimpleHttpServer;
    using SimpleMVC.App.MVC;

    internal class AppStart
    {
        private static void Main(string[] args)
        {
            HttpServer server = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(server);
        }
    }
}