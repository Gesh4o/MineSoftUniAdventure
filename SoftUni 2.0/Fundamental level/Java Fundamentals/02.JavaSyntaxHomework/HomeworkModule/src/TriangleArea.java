import java.util.Arrays;
import java.util.Locale;
import java.util.Scanner;

public class TriangleArea {
    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);
        Scanner scanner = new Scanner(System.in);
        Integer[] aCoordinates = Arrays.stream(scanner.nextLine().split("\\s+")).map(Integer::parseInt).toArray(Integer[]::new);
        Integer[] bCoordinates = Arrays.stream(scanner.nextLine().split("\\s+")).map(Integer::parseInt).toArray(Integer[]::new);
        Integer[] cCoordinates = Arrays.stream(scanner.nextLine().split("\\s+")).map(Integer::parseInt).toArray(Integer[]::new);

        Integer area = Math.abs(
                (
                        aCoordinates[0]*(bCoordinates[1]- cCoordinates[1]) +
                        bCoordinates[0]*(cCoordinates[1] - aCoordinates[1]) +
                        cCoordinates[0]*(aCoordinates[1] - bCoordinates[1])
                ) / 2);

        System.out.println(area);
    }
}
