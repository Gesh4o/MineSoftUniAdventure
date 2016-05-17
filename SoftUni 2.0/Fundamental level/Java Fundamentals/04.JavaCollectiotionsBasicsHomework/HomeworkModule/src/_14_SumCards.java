import java.util.Arrays;
import java.util.HashSet;
import java.util.Objects;
import java.util.Scanner;

public class _14_SumCards {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String[] inputInfo = scanner.nextLine().split("([H|D|S|C]+)[\\s]*");

        for (int i = 0; i < inputInfo.length; i++) {
            switch (inputInfo[i]){
                case "A":
                    inputInfo[i] = "15";
                    break;
                case "K":
                    inputInfo[i] = "14";
                    break;
                case "Q":
                    inputInfo[i] = "13";
                    break;
                case "J":
                    inputInfo[i] = "12";
                    break;
                default:
                    break;
            }
        }

        int sum = 0;

        HashSet<Integer> visitedIndexes = new HashSet<>();

        Integer[] cards = Arrays.stream(inputInfo).map(Integer::parseInt).toArray(Integer[]::new);

        for (int i = 0; i < cards.length; i++) {
            int currentSum = cards[i];
            int nextIndex = i + 1;

            if (!visitedIndexes.contains(i)){
                visitedIndexes.add(0);
                while(nextIndex < cards.length && Objects.equals(cards[i], cards[nextIndex])){
                    visitedIndexes.add(nextIndex);
                    currentSum += cards[i];
                    nextIndex++;
                }

                if (currentSum != cards[i]){
                    currentSum *= 2;
                }

                sum += currentSum;
            }
        }

        System.out.println(sum);
    }
}
