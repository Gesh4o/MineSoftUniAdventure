import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _03_CountSpecifiedWord {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String inputText = scanner.nextLine();
        String wordToFind = scanner.nextLine();

        String regexPattern = String.format("\\b(%s)\\b", wordToFind);

        int matchesCount = 0;
        Matcher matcher = Pattern.compile(regexPattern,Pattern.CASE_INSENSITIVE).matcher(inputText);
        while (matcher.find()){
            matchesCount++;
        }

        System.out.println(matchesCount);
    }
}
