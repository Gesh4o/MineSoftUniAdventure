namespace HotelBookingSystem
{
    using System;
    using HotelBookingSystem.Core;

    public class HotelBookingSystemMain
    {
        public static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            var chepelareEngine = Activator.CreateInstance(typeof(Engine)) as Engine;

            chepelareEngine.StartOperation();
        }
    }
}
