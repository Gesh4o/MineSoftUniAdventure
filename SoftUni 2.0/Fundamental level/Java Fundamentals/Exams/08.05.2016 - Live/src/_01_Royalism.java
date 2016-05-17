import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class _01_Royalism {
    private static Scanner scanner = new Scanner(System.in);

    private static final int PositionOfRInAlphabet = 18;

    private static final int CountOfEnglishLetters = 26;

    private static List<String> royalist = new ArrayList<>();

    private static List<String> nonRoyalist = new ArrayList<>();

    public static void main(String[] args) {
        String[] inputInfo = scanner.nextLine().split("\\s+");

        for (String string : inputInfo) {
            int currentSum = 0;
            for (char c : string.toCharArray()) {
                currentSum += c;

                while (currentSum > CountOfEnglishLetters) {
                    currentSum -= CountOfEnglishLetters;
                }
            }

            if (currentSum == PositionOfRInAlphabet) {
                royalist.add(string);
            } else {
                nonRoyalist.add(string);
            }
        }

        if (royalist.size() >= nonRoyalist.size()) {
            System.out.printf("Royalists - %d%n", royalist.size());
            royalist.forEach(System.out::println);
            System.out.println("All hail Royal!");
        } else {
            nonRoyalist.forEach(System.out::println);
            System.out.println("Royalism, Declined!");
        }
    }
}
