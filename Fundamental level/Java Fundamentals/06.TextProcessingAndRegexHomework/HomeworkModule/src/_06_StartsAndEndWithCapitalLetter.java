import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _06_StartsAndEndWithCapitalLetter {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String inputText = scanner.nextLine();

        StringBuilder result = new StringBuilder();
        Matcher matcher = Pattern.compile("(\\b[A-Z]+([a-zA-Z]*?)[A-Z]+\\b)").matcher(inputText);
        while (matcher.find()){
            result.append(matcher.group()).append(" ");
        }

        System.out.println(result);
    }
}
