namespace SoftUniGameStore.App
{
    using System.Reflection;

    using Routings;

    using SimpleHttpServer;

    using SimpleMVC;

    public class StoreMain
    {
        public static void Main(string[] args)
        {
            HttpServer server = new HttpServer(8082, Routes.GetRoutes());
            MvcEngine.Run(server, Assembly.GetExecutingAssembly().GetName().Name);
        }
    }
}
