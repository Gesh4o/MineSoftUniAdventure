namespace _02.AdMessage
{
    using System;

    public class AdMessageMain
    {
        private static readonly string[] DefaultPhrases = { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category." };

        private static readonly string[] DefaultAuthors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Misha", "Annie" };

        private static readonly string[] DefaultCities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

        private static readonly string[] DefaultEvents =
            {
                "Now I feel good.", "I have succeeded to change.", "That makes miracles.", "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied."
            };

        private static readonly Random Random = new Random();

        public static void Main(string[] args)
        {
            int messagesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < messagesCount; i++)
            {
                int phraseIndex = Random.Next(DefaultPhrases.Length);
                string phrase = DefaultPhrases[phraseIndex];

                int eventsIndex = Random.Next(DefaultEvents.Length);
                string eventString = DefaultEvents[eventsIndex];

                int authorsIndex = Random.Next(DefaultAuthors.Length);
                string author = DefaultAuthors[authorsIndex];

                int cityIndex = Random.Next(DefaultCities.Length);
                string city = DefaultCities[cityIndex];

                string message = $"{phrase} {eventString} {author} - {city}";
                Console.WriteLine(message);
            }
        }
    }
}
