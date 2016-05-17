import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _01_ExtractEmails {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String input = scanner.nextLine();

        Matcher matcher = Pattern.compile("\\b([\\w\\.-_]+)@(([a-z\\.-]+)\\.([a-z-]+))\\b").matcher(input);
        while (matcher.find()){
            System.out.println(matcher.group());
        }
    }
}
