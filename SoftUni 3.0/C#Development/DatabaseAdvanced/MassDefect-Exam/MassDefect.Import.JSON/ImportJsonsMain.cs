namespace MassDefect.Import.JSON
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Newtonsoft.Json;

    using DTOs;
    using MassDefect.Models;
    using Models.Models;
    using Utilities;

    class ImportJsonsMain
    {
        static void Main(string[] args)
        {
                ImportSolarSystems();
                ImportStars();
                ImportPlanets();
                ImportPeople();
                ImportAnomalies();
                ImportAnomalyVictims();
        }

        private static void ImportSolarSystems()
        {
            MassDefectContext context = new MassDefectContext();
            string json = File.ReadAllText(Constants.SolarSystemsPath);
            IEnumerable<SolarSystemDTO> solarSystems = JsonConvert.DeserializeObject<IEnumerable<SolarSystemDTO>>(json);

            foreach (var solarSystem in solarSystems)
            {
                if(solarSystem.Name == null)
                {
                    Console.WriteLine(Constants.ErrorMessage);
                    continue;
                }

                var solarSystemEntity = new SolarSystem(solarSystem.Name);
                context.SolarSystems.Add(solarSystemEntity);
                context.SaveChanges();

                Console.WriteLine(Constants.SuccessMessage, "Solar system", solarSystem.Name);
            }
        }

        private static void ImportStars()
        {
            MassDefectContext context = new MassDefectContext();
            string json = File.ReadAllText(Constants.StarsPath);
            IEnumerable<StarDTO> stars = JsonConvert.DeserializeObject<IEnumerable<StarDTO>>(json);

            foreach (StarDTO star in stars)
            {
                if (star.Name == null || star.SolarSystem == null)
                {
                    Console.WriteLine(Constants.ErrorMessage);
                    continue;
                }

                SolarSystem solarSystem = context.SolarSystems.SingleOrDefault(s => s.Name == star.SolarSystem);

                if (solarSystem == null)
                {
                    Console.WriteLine(Constants.ErrorMessage);
                    continue;
                }

                Star starEntity = new Star(star.Name, solarSystem);
                context.Stars.Add(starEntity);
                context.SaveChanges();

                Console.WriteLine(Constants.SuccessMessage, "Star", star.Name);
            }
        }

        private static void ImportPlanets()
        {
            MassDefectContext context = new MassDefectContext();
            string json = File.ReadAllText(Constants.PlanetsPath);
            IEnumerable<PlanetDTO> planets = JsonConvert.DeserializeObject<IEnumerable<PlanetDTO>>(json);

            foreach (PlanetDTO planet in planets)
            {
                if (planet.Name == null || planet.SolarSystem == null || planet.Sun == null)
                {
                    Console.WriteLine(Constants.ErrorMessage);
                    continue;
                }

                SolarSystem solarySystem = context.SolarSystems.SingleOrDefault(s => s.Name == planet.SolarSystem);
                Star star = context.Stars.SingleOrDefault(s => s.Name == planet.Sun);

                if (solarySystem == null || star == null)
                {
                    Console.WriteLine(Constants.ErrorMessage);
                    continue;
                }

                Planet planetEntity = new Planet(planet.Name, star, solarySystem);
                context.Planets.Add(planetEntity);

                context.SaveChanges();
                Console.WriteLine(Constants.SuccessMessage, "Planet", planet.Name);
            }
        }

        private static void ImportPeople()
        {
            MassDefectContext context = new MassDefectContext();
            string json = File.ReadAllText(Constants.PeoplePath);
            IEnumerable<PersonDTO> people = JsonConvert.DeserializeObject<IEnumerable<PersonDTO>>(json);

            foreach (PersonDTO person in people)
            {
                if (person.Name == null || person.HomePlanet == null)
                {
                    Console.WriteLine(Constants.ErrorMessage);
                    continue;
                }

                Planet planet = context.Planets.SingleOrDefault(p => p.Name == person.HomePlanet);
                if (planet == null)
                {
                    Console.WriteLine(Constants.ErrorMessage);
                    continue;
                }

                Person personEntity = new Person(person.Name, planet);

                context.People.Add(personEntity);
                context.SaveChanges();

                Console.WriteLine(Constants.SuccessMessage, "Person", person.Name);
            }
        }

        private static void ImportAnomalies()
        {
            MassDefectContext context = new MassDefectContext();
            var json = File.ReadAllText(Constants.AnomaliesPath);
            var anomalies = JsonConvert.DeserializeObject<IEnumerable<AnomalyDTO>>(json);

            foreach (AnomalyDTO anomaly in anomalies)
            {
                if (anomaly.OriginPlanet == null || anomaly.TeleportPlanet == null)
                {
                    Console.WriteLine(Constants.ErrorMessage);
                    continue;
                }

                Planet originPlanet = context.Planets.SingleOrDefault(p => p.Name == anomaly.OriginPlanet);
                Planet teleportPlanet = context.Planets.SingleOrDefault(p => p.Name == anomaly.TeleportPlanet);

                if (originPlanet == null || teleportPlanet == null)
                {
                    Console.WriteLine(Constants.ErrorMessage);
                    continue;
                }

                Anomaly anomalyEntity = new Anomaly(originPlanet, teleportPlanet);
                context.Anomalies.Add(anomalyEntity);
                context.SaveChanges();

                Console.WriteLine("Successfully imported anomaly.");
            }
        }

        private static void ImportAnomalyVictims()
        {
            MassDefectContext context = new MassDefectContext();
            string json = File.ReadAllText(Constants.AnomalyVictimsPath);
            IEnumerable<AnomalyVictimDTO> anomalyVictims = JsonConvert.DeserializeObject<IEnumerable<AnomalyVictimDTO>>(json);

            foreach (AnomalyVictimDTO anomalyVictim in anomalyVictims)
            {
                if (anomalyVictim.Id == null || anomalyVictim.Person == null)
                {
                    Console.WriteLine(Constants.ErrorMessage);
                    continue;
                }

                Anomaly anomaly = context.Anomalies.SingleOrDefault(a => a.Id == anomalyVictim.Id);
                Person person = context.People.SingleOrDefault(p => p.Name == anomalyVictim.Person);
                if (anomaly == null || person == null)
                {
                    Console.WriteLine(Constants.ErrorMessage);
                    continue;
                }

                anomaly.Victims.Add(person);
                context.SaveChanges();
            }
        }
    }
}
