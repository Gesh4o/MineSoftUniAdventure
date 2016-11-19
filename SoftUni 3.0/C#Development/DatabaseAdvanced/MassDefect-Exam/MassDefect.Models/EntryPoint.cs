namespace MassDefect.Models
{
    using System.Linq;

    class EntryPoint
    {
        public static void Main()
        {
            MassDefectContext context = new MassDefectContext();
            context.Anomalies.Count();
        }
    }
}
