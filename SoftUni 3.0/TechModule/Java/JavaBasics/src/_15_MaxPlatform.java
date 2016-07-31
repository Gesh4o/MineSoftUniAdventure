import java.util.Arrays;
import java.util.Scanner;

public class _15_MaxPlatform {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        long maxPlatformValue = Long.MIN_VALUE;
        Integer[] rowAndCol = Arrays.stream(scanner.nextLine().split("\\s+")).map(Integer::parseInt).toArray(Integer[]::new);

        long[][] matrix = new long[rowAndCol[0]][rowAndCol[1]];

        for (int row = 0; row < rowAndCol[0]; row++) {
            Integer[] array = Arrays.stream(scanner.nextLine().split("\\s+")).map(Integer::parseInt).toArray(Integer[]::new);

            for (int col = 0; col < rowAndCol[1]; col++) {
                matrix[row][col] = array[col];
            }
        }

        int maxPlatformRow = -1;
        int maxPlatformCol = -1;

        for (int row = 0; row < matrix.length - 2; row++) {
            for (int col = 0; col < matrix[row].length - 2; col++) {
                long maxValue =
                        matrix[row][col] + matrix[row][col + 1] + matrix[row][col + 2] +
                        matrix[row + 1][col] + matrix[row + 1][col + 1] + matrix[row + 1][col + 2] +
                        matrix[row + 2][col] + matrix[row + 2][col + 1] + matrix[row + 2][col + 2];

                if (maxValue > maxPlatformValue) {
                    maxPlatformValue = maxValue;
                    maxPlatformRow = row;
                    maxPlatformCol = col;
                }
            }
        }

        System.out.println(maxPlatformValue);
        printPlatform(matrix, maxPlatformRow, maxPlatformCol);
    }

    private static void printPlatform(long[][]matrix, int maxPlatformRow, int maxPlatformCol) {
        for (int row = maxPlatformRow; row <= maxPlatformRow + 2; row++) {
            for (int col = maxPlatformCol; col <= maxPlatformCol + 2; col++) {
                if (row >= 0 && row < matrix.length && col >= 0 && col < matrix[row].length) {
                    System.out.print(matrix[row][col] + " ");
                }
            }

            System.out.println();
        }
    }
}
