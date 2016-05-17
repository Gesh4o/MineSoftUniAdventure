import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

public class _03_RoyalFlush {
    private static Scanner scanner = new Scanner(System.in);

    private static Map<String, String> cardByNext = new HashMap<>();

    private static int flushesCount = 0;

    public static void main(String[] args) {
        initializeDictionary();

        Integer n = Integer.parseInt(scanner.nextLine());

        StringBuilder cards = new StringBuilder();
        for (int i = 0; i < n; i++) {
            cards.append(scanner.nextLine());
        }

        int indexOfTen = cards.indexOf("10");
        String currentCard = "10";
        while (indexOfTen != -1) {
            boolean isRoyalFlushPossible = true;

            int indexOfSuit = indexOfTen + 2;
            String suit = Character.toString(cards.charAt(indexOfSuit));

            int indexOfNextSuit = cards.indexOf(suit, indexOfSuit + 1);

            while (!currentCard.equals("A")) {
                if (indexOfNextSuit == -1) {
                    isRoyalFlushPossible = false;
                    break;
                }

                String prevCard = currentCard;
                currentCard = Character.toString(cards.charAt(indexOfNextSuit - 1));

                if (!currentCard.equals(cardByNext.get(prevCard))) {
                    isRoyalFlushPossible = false;
                    break;
                }

                indexOfNextSuit = cards.indexOf(suit, indexOfNextSuit + 2);
            }

            if (isRoyalFlushPossible) {
                flushesCount++;
                printRoyalFlush(suit);
            }

            indexOfTen = cards.indexOf("10", indexOfTen + 2);
            currentCard = "10";
        }

        System.out.printf(String.format("Royal's Royal Flushes - %d.%n", flushesCount));
    }

    private static void printRoyalFlush(String suit) {
        switch (suit) {
            case "s":
                System.out.println("Royal Flush Found - Spades");
                break;
            case "d":
                System.out.println("Royal Flush Found - Diamonds");
                break;
            case "h":
                System.out.println("Royal Flush Found - Hearts");
                break;
            case "c":
                System.out.println("Royal Flush Found - Clubs");
                break;
        }
    }

    private static void initializeDictionary() {
        cardByNext.put("10", "J");
        cardByNext.put("J", "Q");
        cardByNext.put("Q", "K");
        cardByNext.put("K", "A");
    }
}
