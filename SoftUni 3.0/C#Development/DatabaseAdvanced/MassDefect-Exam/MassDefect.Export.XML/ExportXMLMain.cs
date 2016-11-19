namespace MassDefect.Export.XML
{
    using MassDefect.Models;
    using System.Linq;
    using System.Xml.Linq;

    class ExportXMLMain
    {
        static void Main(string[] args)
        {
            MassDefectContext context = new MassDefectContext();

            var exportedAnomalies = context.Anomalies.Select(a => new
            {
                id = a.Id,
                originPlanetName = a.OriginPlanet.Name,
                teleportPlanetName = a.TeleportPlanet.Name,
                victims = a.Victims.Select(v => v.Name)
                    .ToList()
            })
            .OrderBy(a => a.id)
            .ToList();

            var xml = new XElement("anomalies");
            foreach (var anomaly in exportedAnomalies)
            {
                XElement anomalyNode = new XElement("anomaly");
                anomalyNode.Add(new XAttribute("id", anomaly.id));
                anomalyNode.Add(new XAttribute("origin-planet", anomaly.originPlanetName));
                anomalyNode.Add(new XAttribute("teleport-planet", anomaly.teleportPlanetName));

                XElement victimsNode = new XElement("victims");

                foreach (string victimName in anomaly.victims)
                {
                    XElement victimNode = new XElement("victim");
                    victimNode.Add(new XAttribute("name", victimName));
                    victimsNode.Add(victimNode);
                }

                anomalyNode.Add(victimsNode);
                xml.Add(anomalyNode);
            }

            xml.Save("../../exports/anomalies.xml");
        }
    }
}
