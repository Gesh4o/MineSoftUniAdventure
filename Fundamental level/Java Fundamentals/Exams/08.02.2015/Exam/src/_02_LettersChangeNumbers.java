import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _02_LettersChangeNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double sum = 0.0d;
        Pattern pattern = Pattern.compile("(([a-zA-Z])([\\d]+)([a-zA-Z]))");
        Matcher matcher = pattern.matcher(scanner.nextLine());
        while (matcher.find()){
            Character firstLetter = matcher.group(2).charAt(0);
            Character lastLetter = matcher.group(4).charAt(0);

            double currentSum = 0.d;
            Double number = Double.parseDouble(matcher.group(3));

            if (Character.isUpperCase(firstLetter)){
                currentSum = (number * 1.0) / (firstLetter - 64);
            }else if (Character.isLowerCase(firstLetter)){
                currentSum = (number * 1.0) * (firstLetter - 96);
            }

            if (Character.isUpperCase(lastLetter)){
                currentSum -= (lastLetter - 64);
            }else if (Character.isLowerCase(lastLetter)){
                currentSum += (lastLetter - 96);
            }

            sum += currentSum;
        }

        System.out.printf("%.2f", sum);
    }
}
