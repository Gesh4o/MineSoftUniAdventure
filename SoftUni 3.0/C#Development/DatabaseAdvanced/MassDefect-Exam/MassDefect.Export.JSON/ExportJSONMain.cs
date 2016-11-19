namespace MassDefect.Export.JSON
{
    using MassDefect.Models;
    using System.Linq;
    using Newtonsoft.Json;
    using System.IO;

    class ExportJSONMain
    {
        static void Main(string[] args)
        {
            MassDefectContext context = new MassDefectContext();

            ExportPlanetsWhichAreNotAnomalyOrigins(context);

            ExportPeopleWhichAreNotVictims(context);

            ExportAnomalyEffectedMostPeople(context);
        }

        private static void ExportAnomalyEffectedMostPeople(MassDefectContext context)
        {
            var anomaly = context.Anomalies.OrderByDescending(a => a.Victims.Count)
                .Take(1)
                .Select(a => new
                {
                    id = a.Id,
                    originPlanet = new { name = a.OriginPlanet.Name },
                    teleportPlanet = new { name = a.TeleportPlanet.Name },
                    victimsCount = a.Victims.Count
                });

            string anomalyAsJson = JsonConvert.SerializeObject(anomaly, Formatting.Indented);
            File.WriteAllText("../../exports/anomaly.json", anomalyAsJson);
        }

        private static void ExportPeopleWhichAreNotVictims(MassDefectContext context)
        {
            var exportedPeople = context.People
                .Where(p => !p.Anomalies.Any())
                .Select(p => new
                {
                    name = p.Name,
                    homeplanet = new { name = p.HomePlanet.Name}
                });

            string peopleAsJson = JsonConvert.SerializeObject(exportedPeople, Formatting.Indented);
            File.WriteAllText("../../exports/people.json", peopleAsJson);
        }

        private static void ExportPlanetsWhichAreNotAnomalyOrigins(MassDefectContext context)
        {
            var exportedPlanets = context.Planets
                .Where(p => !p.OriginAnomalies.Any())
                .Select(p => new { name = p.Name });

            string planetsAsJson = JsonConvert.SerializeObject(exportedPlanets, Formatting.Indented);
            File.WriteAllText("../../exports/planets.json", planetsAsJson);
        }
    }
}
