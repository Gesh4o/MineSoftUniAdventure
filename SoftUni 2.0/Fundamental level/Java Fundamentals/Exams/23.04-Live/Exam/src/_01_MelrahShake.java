import java.util.Scanner;

public class _01_MelrahShake {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        StringBuilder text = new StringBuilder(scanner.nextLine());
        StringBuilder regexPattern = new StringBuilder(scanner.nextLine());

        while (true) {
            int startIndex = text.indexOf(regexPattern.toString());
            int endIndex = text.lastIndexOf(regexPattern.toString());

            if (startIndex == -1 || endIndex == -1 || startIndex == endIndex || text.length() < regexPattern.length() * 2 || regexPattern.length() == 0) {
                System.out.println("No shake.");
                System.out.println(text.toString());
                break;
            }

            text.replace(startIndex, startIndex + regexPattern.length(), "");
            text.replace(endIndex - regexPattern.length(), endIndex, "");

            regexPattern.deleteCharAt(regexPattern.length() / 2);

            System.out.println("Shaked it.");

        }
    }
}