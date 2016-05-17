import java.math.BigDecimal;
import java.math.RoundingMode;
import java.util.Arrays;
import java.util.Scanner;

public class _02_RoyalNonStop {
    private static Scanner scanner = new Scanner(System.in);

    private static BigDecimal earnings = BigDecimal.ZERO;

    private static BigDecimal lukankaPrice = BigDecimal.ZERO;

    private static BigDecimal rakiqPrice = BigDecimal.ZERO;

    private static int count = 0;

    public static void main(String[] args) {
        initializePrices();

        String command = scanner.nextLine();
        while (!command.equals("Royal Close")) {
            Integer[] currentPosition = Arrays.stream(command.split("\\s+")).map(Integer::parseInt).toArray(Integer[]::new);
            int row = currentPosition[0];
            int col = currentPosition[1];
            if (row < col) {
                goUpAndLeftPath(row, col);
            } else {
                goLeftAndUpPath(row, col);
            }
            count++;
            command = scanner.nextLine();
        }

        earnings = earnings.setScale(6, RoundingMode.HALF_UP);
        System.out.println(earnings);
        System.out.println(count);
    }

    private static void initializePrices() {
        String sdasd = scanner.nextLine();
        String command = scanner.nextLine();
        BigDecimal[] prices = Arrays.stream(command.split("\\s+")).map(BigDecimal::new).toArray(BigDecimal[]::new);
        lukankaPrice = prices[0];
        rakiqPrice = prices[1];
    }

    private static void goLeftAndUpPath(int startRow, int startCol) {
        BigDecimal currentPrice = lukankaPrice;

        if (startRow % 2 == 1) {
            currentPrice = rakiqPrice;
        }

        for (int col = startCol; col > 0; col--) {
            BigDecimal currentRow = new BigDecimal(Integer.toString(startRow + 1));
            BigDecimal currentCol = new BigDecimal(Integer.toString(col + 1));
            BigDecimal addition = currentPrice.multiply(currentRow).multiply(currentCol);

             earnings = earnings.add(addition);
        }

        for (int row = startRow; row > 0; row--) {
            if (row % 2 == 0) {
                currentPrice = lukankaPrice;
            } else {
                currentPrice = rakiqPrice;
            }

            BigDecimal currentRow = new BigDecimal(Integer.toString(row + 1));
            BigDecimal addition = currentPrice.multiply(currentRow);

            earnings = earnings.add(addition);
        }
    }

    private static void goUpAndLeftPath(int startRow, int startCol) {
        BigDecimal currentPrice = BigDecimal.ZERO;
        for (int row = startRow; row > 0; row--) {
            if (row % 2 == 0){
                currentPrice = lukankaPrice;
            }else {
                currentPrice = rakiqPrice;
            }

            BigDecimal currentRow = new BigDecimal(Integer.toString(row + 1));
            BigDecimal currentCol = new BigDecimal(Integer.toString(startCol + 1));
            BigDecimal addition = currentRow.multiply(currentCol).multiply(currentPrice);

            earnings = earnings.add(addition);
        }

        currentPrice = lukankaPrice;
        for (int col = startCol; col > 0; col--) {
            BigDecimal currentCol = new BigDecimal(Integer.toString(col + 1));
            BigDecimal addition = currentCol.multiply(currentPrice);

            earnings = earnings.add(addition);
        }
    }
}
