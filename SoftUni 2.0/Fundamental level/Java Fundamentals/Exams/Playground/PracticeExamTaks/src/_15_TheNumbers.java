import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _15_TheNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String text = scanner.nextLine();

        Pattern  pattern = Pattern.compile("[0-9]+");
        Matcher matcher = pattern.matcher(text);
        List<String> numbers = new ArrayList<>();
        while (matcher.find()){
            Long number = Long.parseLong(matcher.group());
            String numberAsString = "0x"  + String.format("%4s", Long.toHexString(number).toUpperCase()).replace(' ', '0');
            numbers.add(numberAsString);
        }

        System.out.println(String.join("-", numbers));

    }
}
