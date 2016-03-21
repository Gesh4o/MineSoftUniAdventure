import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _06_CountSpecifiedWord {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String text = scanner.nextLine();

        String searchedWord = scanner.nextLine();

        String regexPattern = String.format("\\b(%s)\\b", searchedWord);

        Matcher matcher = Pattern.compile(regexPattern,Pattern.CASE_INSENSITIVE).matcher(text);

        int wordRepetitionsCount = 0;
        while (matcher.find()){
            wordRepetitionsCount++;
        }

        System.out.println(wordRepetitionsCount);
    }
}
