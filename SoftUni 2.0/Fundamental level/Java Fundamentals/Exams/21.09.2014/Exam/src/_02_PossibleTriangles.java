import java.util.Arrays;
import java.util.Scanner;

public class _02_PossibleTriangles {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String command = scanner.nextLine();
        boolean isFound = false;
        while (!command.equals("End")) {
            Double[] sequence = Arrays.stream(command.split("\\s+")).map(Double::parseDouble).toArray(Double[]::new);
            sequence = Arrays.stream(sequence).sorted().toArray(Double[]::new);
            boolean cSide = ((Double) (sequence[0] + sequence[1])).compareTo(sequence[2]) > 0;
            boolean aSide = ((Double) (sequence[2] + sequence[1])).compareTo(sequence[0]) > 0;
            boolean bSide = ((Double) (sequence[0] + sequence[2])).compareTo(sequence[1]) > 0;
            if (cSide && aSide && bSide) {
                System.out.printf("%.2f+%.2f>%.2f%n", sequence[0], sequence[1], sequence[2]);
                isFound = true;
            }

            command = scanner.nextLine();
        }

        if (!isFound) {
            System.out.println("No");
        }
    }
}
