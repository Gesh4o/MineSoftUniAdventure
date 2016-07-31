import java.util.Arrays;
import java.util.Scanner;

public class _13_DiagonalDifference {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());
        Integer[][] matrix = new Integer[n][];
        for (int row = 0; row < n; row++)
        {
            String[] rowAsString = scanner.nextLine().split("\\s+");
            matrix[row] = Arrays.stream(rowAsString).map(Integer::parseInt).toArray(Integer[]::new);
        }

        int currentSum = 0;
        for (int i = 0; i < matrix.length; i++)
        {
            currentSum += matrix[i][i];
        }

        int sum = 0;
        for (int i = 0; i < matrix.length; i++)
        {
            sum += matrix[i][matrix.length - 1 - i];
        }

        int result = Math.abs(currentSum - sum);

        System.out.println(result);
    }
}
