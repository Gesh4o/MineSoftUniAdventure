import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _21_ToUpper {
    public static void main(String[] args) {
        Scanner scanner =new Scanner(System.in);

        String input = scanner.nextLine();
        Pattern pattern = Pattern.compile("<upcase>(.*?)</upcase>");
        Matcher regexMatcher = pattern.matcher(input);
        while (regexMatcher.find()) {
            input = regexMatcher.replaceAll(
                    String.valueOf(regexMatcher.group(1).toUpperCase()));
        }

        System.out.println(input);
    }
}
