import java.util.Locale;
import java.util.Scanner;

public class GetAverage {
    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);
        Scanner scanner = new Scanner(System.in);

        double firstNumber = scanner.nextDouble();
        double secondNumber = scanner.nextDouble();
        double thirdNumber = scanner.nextDouble();

        double averageNumber = getAverageOfThreeNumbers(firstNumber, secondNumber, thirdNumber);

        System.out.println(averageNumber);
    }

    private static double getAverageOfThreeNumbers(double firstNumber, double secondNumber, double thirdNumber) {
        double result = getAverage(firstNumber, secondNumber, thirdNumber);

        return result;
    }

    private static double getAverage(Double... numbers) {
        double result = 0;

        for ( Double number: numbers) {
            result += number;
        }

        result /= numbers.length;
        return result;
    }
}
