import java.util.Arrays;
import java.util.Scanner;

public class _14_Square {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Integer[] rowAndCol = Arrays.stream(scanner.nextLine().split("\\s+")).map(Integer::parseInt).toArray(Integer[]::new);

        char[][] matrix = new char[rowAndCol[0]][rowAndCol[1]];

        for (int row = 0; row < rowAndCol[0]; row++) {
            String rowAsString = scanner.nextLine().replaceAll("\\s+", "");
            for (int col = 0; col < rowAndCol[1]; col++) {
                matrix[row][col] = rowAsString.charAt(col);
            }
        }

        int count = 0;
        for (int row = 0; row < matrix.length - 1; row++) {
            for (int col = 0; col < matrix[row].length - 1; col++) {
                if (
                        matrix[row][col] == matrix[row][col + 1] &&
                        matrix[row][col] == matrix[row + 1][col] &&
                        matrix[row][col] == matrix[row + 1][col + 1]) {
                    count++;
                }
            }
        }

        System.out.println(count);
    }
}
