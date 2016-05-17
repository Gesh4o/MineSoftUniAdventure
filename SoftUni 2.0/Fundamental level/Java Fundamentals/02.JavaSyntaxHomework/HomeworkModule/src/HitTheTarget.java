import java.util.Scanner;

public class HitTheTarget {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Integer inputNumber = scanner.nextInt();

        // Get all sums that are equal to the input number.
        for (int i = 1; i <= 20; i++) {
            if (i >= inputNumber){
                break;
            }
            for (int j = 1; j <= 20; j++) {
                if (i + j == inputNumber){
                    System.out.format("%d + %d = %d%n", i, j, inputNumber);
                    break;
                }
            }
        }

        // Get all differences that are equal to the input number.
        for (int i = 1; i <= 20; i++) {
            for (int j = 1; j <= 20; j++) {
                if (i - j < inputNumber){
                    break;
                }
                if (i - j == inputNumber){
                    System.out.format("%d - %d = %d%n", i, j, inputNumber);
                    break;
                }
            }
        }
    }
}
