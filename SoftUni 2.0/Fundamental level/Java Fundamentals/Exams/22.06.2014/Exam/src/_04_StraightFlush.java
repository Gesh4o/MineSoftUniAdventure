import java.util.ArrayList;
import java.util.Scanner;

public class _04_StraightFlush {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String[] cards = scanner.nextLine().split("[\\s,]+");

        boolean isFound = false;
        for (int i = 0; i < cards.length; i++) {
            String currentCard = cards[i];
            ArrayList<String> flush = new ArrayList<>();
            flush.add(currentCard);

            for (int j = 0; j < 4; j++) {
                String nextCard = getNextCard(currentCard, cards);
                if (nextCard == null){
                    break;
                }
                flush.add(nextCard);
                currentCard = nextCard;
            }

            if (flush.size() == 5){
                isFound = true;
                System.out.println(flush.toString());
            }
        }

        if (!isFound){
            System.out.println("No Straight Flushes");
        }
    }

    private static String getNextCard(String currentCard, String[] cards) {
        String currentCardFace = currentCard.substring(0,1);
        String currentCardSuit = currentCard.substring(currentCard.length() - 1);
        String nextCardFace;
        switch (currentCardFace){
            case "2":
                nextCardFace = "3" ;
                break;
            case "3":
                nextCardFace = "4" ;
                break;
            case "4":
                nextCardFace = "5" ;
                break;
            case "5":
                nextCardFace = "6" ;
                break;
            case "6":
                nextCardFace = "7" ;
                break;
            case "7":
                nextCardFace = "8" ;
                break;
            case "8":
                nextCardFace = "9" ;
                break;
            case "9":
                nextCardFace = "1" ;
                break;
            case "1":
                nextCardFace = "J" ;
                break;
            case "J":
                nextCardFace = "Q" ;
                break;
            case "Q":
                nextCardFace = "K" ;
                break;
            case "K":
                nextCardFace = "A" ;
                break;
            case "A":
                nextCardFace = null;
                break;
            default:
                nextCardFace = null;
        }

        if (nextCardFace == null) {
            return nextCardFace;
        }

        if (nextCardFace.equals("1")){
            nextCardFace = "10";
        }

        String nextCard = nextCardFace + currentCardSuit;
        for (String card : cards) {
            if (nextCard.equals(card)){
                return nextCard;
            }
        }

        return null;
    }
}
