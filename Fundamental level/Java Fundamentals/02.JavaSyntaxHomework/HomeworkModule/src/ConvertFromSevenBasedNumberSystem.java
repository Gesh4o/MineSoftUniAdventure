import java.util.Locale;
import java.util.Scanner;

public class ConvertFromSevenBasedNumberSystem {
    private static final int TenNumberSystemBase = 10;
    private static final int SevenNumberSystemBase = 7;

    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);
        Scanner scanner = new Scanner(System.in);

        Integer inputNumber;

        inputNumber = scanner.nextInt();

        int convertedToDecimalNumberSystem = convertToDecimal(inputNumber);

        // Or directly number can be read and converted.
        // inputNumber = scanner.nextInt(SevenNumberSystemBase);

        System.out.println(convertedToDecimalNumberSystem);
   }

    private static int convertToDecimal(Integer number) {
        int result = 0;
        int exponent = 0;
        while(number > 0){
            result += (number % TenNumberSystemBase) * (Math.pow(SevenNumberSystemBase,exponent));
            number /= TenNumberSystemBase;

            exponent++;
        }
        return result;
    }
}
