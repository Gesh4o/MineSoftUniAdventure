namespace SimpleMVC.App.MVC
{
    using SimpleHttpServer;
    using System;
    using System.Reflection;

    public static class MvcEngine
    {
        public static void Run(HttpServer server)
        {
            RegisterAssemblyName();
            RegisterControllers();
            RegisterViews();
            RegisterModels();

            try
            {
                server.Listen();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void RegisterModels()
        {
            MvcContext.Instance.ModelsFolder = "Models";
        }

        private static void RegisterViews()
        {
            MvcContext.Instance.ViewsFolder = "Views";
        }

        private static void RegisterControllers()
        {
            MvcContext.Instance.ControllersFolder = "Controllers";
            MvcContext.Instance.ControllersSuffix = "Controller";
        }

        private static void RegisterAssemblyName()
        {
            MvcContext.Instance.AssemblyName = Assembly.GetExecutingAssembly().GetName().Name;
        }
    }
}