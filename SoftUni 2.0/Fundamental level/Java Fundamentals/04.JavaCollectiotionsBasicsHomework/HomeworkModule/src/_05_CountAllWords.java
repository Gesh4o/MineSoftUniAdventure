import java.util.Scanner;

public class _05_CountAllWords {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String text = scanner.nextLine();

        String[] wordsInText = text.split("\\W+");

        System.out.println(wordsInText.length);
    }
}
