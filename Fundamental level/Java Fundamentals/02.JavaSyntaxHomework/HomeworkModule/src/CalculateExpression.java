import java.util.Locale;
import java.util.Scanner;

// Used some math terminology here.
// Exponent - number which indicate how many time the base number will multiply itself.
// For more info see here: https://en.wikipedia.org/wiki/Exponentiation

public class CalculateExpression {
    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);
        Scanner scanner = new Scanner(System.in);

        Double a = scanner.nextDouble();
        Double b = scanner.nextDouble();
        Double c = scanner.nextDouble();

        Double formulaOneResult = getFormulaOneResult(a, b, c);

        Double formulaTwoResult = getFormulaTwoResult(a, b, c);

        Double formulaAverage = getAverage(formulaOneResult, formulaTwoResult);

        Double numberAverage = getAverage(a, b, c);

        System.out.format(
                "F1 result: %.2f; F2 result: %.2f; Diff: %.2f",
                formulaOneResult,
                formulaTwoResult,
                Math.abs(numberAverage - formulaAverage));
    }

    private static Double getAverage(Double... numbers) {
        Double sum = 0.0;
        for (Double number : numbers) {
            sum += number;
        }
        Double average = sum / numbers.length;

        return average;
    }

    private static Double getFormulaTwoResult(Double a, Double b, Double c) {
        Double exponent = a - b;

        Double base = Math.pow(a, 2) + Math.pow(b,2) - Math.pow(c, 3);

        Double result = Math.pow(base, exponent);

        return result;
    }

    private static Double getFormulaOneResult(Double a, Double b, Double c) {
        Double sum = a + b + c;
        Double sqrtC = Math.sqrt(c);
        Double exponent = sum / sqrtC;

        Double poweredA = Math.pow(a,2);
        Double poweredB = Math.pow(b,2);
        Double base = (poweredA + poweredB) / (poweredA - poweredB);

        Double result = Math.pow(base, exponent);

        return result;
    }
}
