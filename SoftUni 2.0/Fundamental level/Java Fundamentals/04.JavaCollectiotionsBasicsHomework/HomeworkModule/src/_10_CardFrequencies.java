import java.util.*;

public class _10_CardFrequencies {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String cardSequence = scanner.nextLine();

        String[] cards = cardSequence.split("\\W+");

        Map<String, Integer> cardsByRepetitions = new LinkedHashMap<>();

        for (String card : cards) {
            if (!cardsByRepetitions.containsKey(card)){
                cardsByRepetitions.put(card, 1);
            }
            else{
                cardsByRepetitions.put(card , cardsByRepetitions.get(card) + 1);
            }
        }

        for (String card : cardsByRepetitions.keySet()) {

            double cardPercent = (cardsByRepetitions.get(card) / (cards.length * 1.0)) * 100;
            System.out.printf("%s ->%.2f%%%n", card, cardPercent);
        }
    }
}
