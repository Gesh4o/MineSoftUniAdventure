import java.util.Locale;
import java.util.Random;
import java.util.Scanner;

public class RandomNumberFromNToM {
    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);
        Scanner scanner = new Scanner(System.in);

        int n = scanner.nextInt();
        int m = scanner.nextInt();

        Random random = new Random();

        int[] array = random.ints(Math.abs(n - m), n, m).toArray();

        String[] resultArray = new String[array.length];
        for (int i = 0; i < resultArray.length; i++) {
            resultArray[i] = Integer.toString(array[i]);
        }

        System.out.println(String.join(" ", resultArray));
    }
}
