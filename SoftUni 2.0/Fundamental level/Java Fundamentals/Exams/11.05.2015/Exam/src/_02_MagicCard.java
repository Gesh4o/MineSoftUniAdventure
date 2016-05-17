import java.util.HashMap;
import java.util.Scanner;

public class _02_MagicCard {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        char[] cardSuits = new char[]{'S', 'H', 'D', 'C'};
        HashMap<Character, Integer> cardsByPoints = new HashMap<>();
        cardsByPoints.put('2',20);
        cardsByPoints.put('3',30);
        cardsByPoints.put('4',40);
        cardsByPoints.put('5',50);
        cardsByPoints.put('6',60);
        cardsByPoints.put('7',70);
        cardsByPoints.put('8',80);
        cardsByPoints.put('9',90);
        cardsByPoints.put('1',100);
        cardsByPoints.put('J', 120);
        cardsByPoints.put('Q', 130);
        cardsByPoints.put('K', 140);
        cardsByPoints.put('A', 150);

        String[] card = scanner.nextLine().split("\\s+");
        String type = scanner.nextLine();
        String magicCard = scanner.nextLine();

        Character magicCardFace = magicCard.charAt(0);
        Character magicCardSuit = magicCard.charAt(magicCard.length() - 1);

        Integer startIndex = 0;
        if (type.equals("odd")){
            startIndex = 1;
        }

        Integer points =0;
        for (int i = startIndex; i < card.length; i += 2) {
            // ToDo: toUpper();

            Character currentCardFace = card[i].charAt(0);
            Integer currentPoints = cardsByPoints.get(currentCardFace);
            if (magicCardFace.equals(currentCardFace)){
                currentPoints *= 3;
            }

            Character currentCardSuit = card[i].charAt(card[i].length() - 1);
            if (magicCardSuit.equals(currentCardSuit)){
                currentPoints *= 2;
            }

            points += currentPoints;
        }

        System.out.println(points);
    }
}
