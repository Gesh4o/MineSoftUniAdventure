namespace _01.Logger
{
    using _01.Logger.Enums;
    using _01.Logger.Objects;
    using _01.Logger.Objects.Appenders;
    using _01.Logger.Objects.Layouts;

    public class LoggerMain
    {
        public static void Main()
        {
            var simpleLayout = new SimpleLayout();
            var consoleAppender = new ConsoleAppender(simpleLayout);

            // The only reason this is not set in the constructor is because of the example in the task.
            // The syntax there requires it.
            consoleAppender.ReportLevel = ReportLevel.Error; 

            var logger = new Logger(consoleAppender);

            logger.Info("Everything seems fine");
            logger.Warn("Warning: ping is too high - disconnect imminent");
            logger.Error("Error parsing request");
            logger.Critical("No connection string found in App.config");
            logger.Fatal("mscorlib.dll does not respond");

            // First example. (you will need to import _01.Logger.Contracts for this one)
            ////ILayout simpleLayout = new SimpleLayout();
            ////IAppender consoleAppender =
            ////     new ConsoleAppender(simpleLayout);
            ////ILogger logger = new Logger(consoleAppender);

            ////logger.Error("Error parsing JSON.");
            ////logger.Info($"User {"Pesho"} successfully registered.");

            // Second example.
            ////var simpleLayout = new SimpleLayout();

            ////var consoleAppender = new ConsoleAppender(simpleLayout);
            ////var fileAppender = new FileAppender(simpleLayout);
            ////fileAppender.File = "log.txt";

            ////var logger = new Logger(consoleAppender, fileAppender);
            ////logger.Error("Error parsing JSON.");
            ////logger.Info(string.Format("User {0} successfully registered.", "Pesho"));
            ////logger.Warn("Warning - missing files.");

            // Third one.
            ////var xmlLayout = new XmlLayout();
            ////var consoleAppender = new ConsoleAppender(xmlLayout);
            ////var logger = new Logger(consoleAppender);

            ////logger.Fatal("mscorlib.dll does not respond");
            ////logger.Critical("No connection string found in App.config");
        }
    }
}
