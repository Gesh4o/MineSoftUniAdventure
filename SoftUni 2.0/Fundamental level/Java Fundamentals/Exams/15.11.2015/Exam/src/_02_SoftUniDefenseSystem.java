import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _02_SoftUniDefenseSystem {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String input = scanner.nextLine();

        double alcoholProvided = 0.0;
        Pattern pattern = Pattern.compile("([A-Z][a-z]+).*?([A-Z][a-z]*[A-Z]).*?(\\d+)L");
        while (!input.equals("OK KoftiShans")){
            Matcher matcher = pattern.matcher(input);

            while (matcher.find()){
                String personName = matcher.group(1);
                String alcoholName = matcher.group(2).toLowerCase();
                Integer alcoholQuantity = Integer.parseInt(matcher.group(3));

                System.out.printf("%s brought %d liters of %s!%n", personName, alcoholQuantity, alcoholName);
                alcoholProvided += (alcoholQuantity / 1000.0);
            }


            input = scanner.nextLine();
        }

        System.out.printf("%.3f softuni liters",alcoholProvided);
    }
}
