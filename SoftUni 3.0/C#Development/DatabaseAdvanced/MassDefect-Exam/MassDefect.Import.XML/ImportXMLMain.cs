namespace MassDefect.Import.XML
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;

    using MassDefect.Models;
    using Models.Models;
    using System.Collections.Generic;

    class ImportXMLMain
    {
        private const string AnomaliesXMLPath = "../../../datasets/new-anomalies.xml";
        private const string ErrorMessage = "Error: Invalid data.";

        static void Main(string[] args)
        {
            XDocument xml = XDocument.Load(AnomaliesXMLPath);
            IEnumerable<XElement> anomalies = xml.XPathSelectElements("anomalies/anomaly");

            MassDefectContext context = new MassDefectContext();

            foreach (var anomaly in anomalies)
            {
                ImportAnomalyAndVictims(anomaly, context);
            }
        }

        private static void ImportAnomalyAndVictims(XElement anomalyNode, MassDefectContext context)
        {
            XAttribute originPlanetName = anomalyNode.Attribute("origin-planet");
            XAttribute teleportPlanetName = anomalyNode.Attribute("teleport-planet");

            if (originPlanetName == null || teleportPlanetName == null)
            {
                Console.WriteLine(ErrorMessage);
                return;
            }

            Planet origin = context.Planets.SingleOrDefault(p => p.Name == originPlanetName.Value);
            Planet teleport = context.Planets.SingleOrDefault(p => p.Name == teleportPlanetName.Value);

            if (origin == null || teleport == null)
            {
                Console.WriteLine(ErrorMessage);
                return;
            }

            Anomaly anomaly = new Anomaly(origin, teleport);
            context.Anomalies.Add(anomaly);
            Console.WriteLine("Successfully imported anomaly.");

            ImportVictims(context, anomalyNode, anomaly);

            context.SaveChanges();
        }

        private static void ImportVictims(MassDefectContext context, XElement anomalyNode, Anomaly anomaly)
        {
            IEnumerable<XElement> victims = anomalyNode.XPathSelectElements("victims/victim");
            foreach (var victim in victims)
            {
                XAttribute name = victim.Attribute("name");

                if (name == null)
                {
                    Console.WriteLine(ErrorMessage);
                    continue;
                }

                Person person = context.People.SingleOrDefault(p => p.Name == name.Value);

                if (person == null)
                {
                    Console.WriteLine(ErrorMessage);
                    continue;
                }

                anomaly.Victims.Add(person);
            }
        }
    }
}
