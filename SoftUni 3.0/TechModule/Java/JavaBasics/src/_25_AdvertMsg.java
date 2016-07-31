import java.util.Random;
import java.util.Scanner;

public class _25_AdvertMsg {
    
        private static final String[] DefaultPhrases = { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category." };

        private static final String[] DefaultAuthors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Misha", "Annie" };

        private static final String[] DefaultCities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

        private static final String[] DefaultEvents =
        {
            "Now I feel good.", "I have succeeded to change.", "That makes miracles.", "I cannot believe but now I feel awesome.",
                    "Try it yourself, I am very satisfied."
        };

        private static final Random Rnd = new Random();

        public static void main(String[] args)
        {
            Scanner scanner = new Scanner(System.in);
            int messagesCount = Integer.parseInt(scanner.nextLine());

            for (int i = 0; i < messagesCount; i++)
            {
                int phraseIndex = Rnd.nextInt(DefaultPhrases.length);
                String phrase = DefaultPhrases[phraseIndex];

                int eventsIndex = Rnd.nextInt(DefaultEvents.length);
                String eventString = DefaultEvents[eventsIndex];

                int authorsIndex = Rnd.nextInt(DefaultAuthors.length);
                String author = DefaultAuthors[authorsIndex];

                int cityIndex = Rnd.nextInt(DefaultCities.length);
                String city = DefaultCities[cityIndex];

                String message = String.format("%s %s %s - %s", phrase, eventString, author, city);
                System.out.println(message);
            }
        }
}
