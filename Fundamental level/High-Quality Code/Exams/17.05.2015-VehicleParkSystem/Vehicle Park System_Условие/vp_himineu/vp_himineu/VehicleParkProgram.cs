namespace VehicleParkSystem
{
    using System.Globalization;
    using System.Threading;

    using VehicleParkSystem.Core;

    public static class VehicleParkProgram
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var engine = new Engine();
            engine.Run();
        }
    }
}