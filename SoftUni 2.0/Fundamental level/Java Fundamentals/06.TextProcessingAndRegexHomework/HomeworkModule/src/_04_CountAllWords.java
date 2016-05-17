import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _04_CountAllWords {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String inputText = scanner.nextLine();

        int matchesCount = 0;
        Matcher matcher = Pattern.compile("([a-zA-Z]+)").matcher(inputText);
        while (matcher.find()){
            matchesCount++;
        }

        System.out.println(matchesCount);
    }
}
