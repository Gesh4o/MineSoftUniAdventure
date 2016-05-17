import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class StartsAndEndsWithCapitalLetter {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String inputInfo = scanner.nextLine();

        String pattern = "(\\b[A-Z]+[a-zA-Z]*[A-Z]+\\b)";

        List<String> allMatches = new ArrayList<>();
        Matcher matcher = Pattern.compile(pattern).matcher(inputInfo);
        while (matcher.find()){
            allMatches.add(matcher.group());
        }

        System.out.println(String.join(" ", allMatches));
    }
}
