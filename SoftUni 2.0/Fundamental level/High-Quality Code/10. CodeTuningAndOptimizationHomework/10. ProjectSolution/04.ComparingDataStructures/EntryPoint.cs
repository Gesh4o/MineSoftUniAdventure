namespace _02.ComparingDataStructures
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EntryPoint
    {
        private const int PersonCount = 1000;
        private static readonly Random Rnd = new Random();

        private static int personCounter;

        public static void Main()
        {
            const int DefaultTestToBePerformedCount = 3;
            const int SearchCount = 10000000;

            for (int testCount = 0; testCount < DefaultTestToBePerformedCount; testCount++)
            { 
                Dictionary<string, string> peopleDictionary = new Dictionary<string, string>(PersonCount);
                List<Person> peopleList = new List<Person>(PersonCount);

                List<string> phoneNumbers = new List<string>(PersonCount);
                List<string> peopleNames = new List<string>(PersonCount);

                GeneratePrimeData(phoneNumbers, peopleNames);

                PutPrimeDataInDataStructure(peopleDictionary, peopleList, peopleNames, phoneNumbers);

                StringBuilder testData = new StringBuilder();
                testData.AppendFormat(
                    "Performing test with {0} elements, searched {1} times.{2}",
                    PersonCount,
                    SearchCount,
                    Environment.NewLine);

                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();
                for (int i = 0; i < SearchCount; i++)
                {
                    Person person = peopleList.FirstOrDefault(p => p.PhoneNumber == phoneNumbers[Rnd.Next(phoneNumbers.Count)]);
                }

                stopwatch.Stop();
                testData.AppendLine("List: " + Environment.NewLine + stopwatch.Elapsed);

                stopwatch.Reset();

                stopwatch.Start();
                for (int i = 0; i < SearchCount; i++)
                {
                    string number = peopleDictionary[peopleNames[Rnd.Next(peopleNames.Count)]];
                }

                stopwatch.Stop();
                testData.AppendLine("Dictionary: " + Environment.NewLine + stopwatch.Elapsed);
                testData.AppendLine(new string('-', 25));

                using (StreamWriter writer = new StreamWriter("Data structures test information 2.txt", true))
                {
                    writer.Write(testData.ToString());
                }
            }
        }

        private static void GeneratePrimeData(List<string> phoneNumbers, List<string> peopleNames)
        {
            for (int i = 0; i < PersonCount; i++)
            {
                string number = GeneratePhoneNumber();
                phoneNumbers.Add(number);
                string personName = GeneratePersonName();
                peopleNames.Add(personName);
            }
        }

        private static string GeneratePhoneNumber()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < 10; i++)
            {
                result.Append(Rnd.Next(10));
            }

            return result.ToString();
        }

        private static string GeneratePersonName()
        {
            string result = string.Format(personCounter.ToString());
            personCounter++;
            return result;
        }

        private static void PutPrimeDataInDataStructure(
            Dictionary<string, string> peopleDictionary,
            List<Person> peopleList,
            List<string> peopleNames,
            List<string> phoneNumbers)
        {
            for (int i = 0; i < PersonCount; i++)
            {
                peopleDictionary.Add(peopleNames[i], phoneNumbers[i]);
                peopleList.Add(new Person(peopleNames[i], phoneNumbers[i]));
            }
        }
    }
}
