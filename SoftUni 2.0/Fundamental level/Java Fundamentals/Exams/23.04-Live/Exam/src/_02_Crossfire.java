import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Scanner;

public class _02_Crossfire {
    private static Scanner scanner = new Scanner(System.in);

    private static List<List<Integer>> matrix;
    private static boolean isCenterRemoved;

    public static void main(String[] args) {
        InitializeMatrix();

        ProcessInput();

        PrintMatrix();
    }

    private static void InitializeMatrix() {
        Integer[] matrixDimensions = Arrays.stream(scanner.nextLine().split("\\s+")).map(Integer::parseInt).toArray(Integer[]::new);
        int rows = matrixDimensions[0];
        int cols = matrixDimensions[1];

        matrix = new ArrayList<>(rows);

        for (int row = 0; row < rows; row++) {
            matrix.add(new ArrayList<>());
            for (int col = 0; col < cols; col++) {
                matrix.get(row).add((col + 1) + (row * cols));
            }
        }
    }

    private static void ProcessInput() {
        String command = scanner.nextLine();

        while (!command.equals("Nuke it from orbit")) {
            Integer[] bombInfo = Arrays.stream(command.split("\\s+")).map(Integer::parseInt).toArray(Integer[]::new);
            int bombRow = bombInfo[0];
            int bombCol = bombInfo[1];
            int bombRange = bombInfo[2];

            removeFromAttackCol(bombRow, bombCol, bombRange);

            if (isRowInRangeInMatrix(bombRow)) {
                removeFromAttackRow(bombRow, bombCol, bombRange);
            }

            command = scanner.nextLine();
        }
    }

    private static void removeFromAttackRow(int bombRow, int bombCol, int bombRange) {
        int startCol = Math.max(0, bombCol - bombRange);
        int endCol = Math.min(matrix.get(bombRow).size() - 1, bombCol + bombRange);


        if (startCol == 0 && endCol == matrix.get(bombRow).size() - 1 && endCol != 0){
            matrix.remove(bombRow);
            return;
        }

        for (int col = startCol; col <= endCol; col++) {
            if (isColInRangeInMatrix(bombRow, col)) {
                matrix.get(bombRow).remove(col);
                col--;
                endCol--;
            }
        }
    }

    private static void removeFromAttackCol(int bombRow, int bombCol, int bombRange) {

        int startRow = Math.max(0, bombRow - bombRange);
        int endRow = Math.min(matrix.size() - 1, bombRow + bombRange);

        for (int row = startRow; row <= endRow; row++) {
            if (isInRangeInMatrix(row, bombCol)) {
                if (bombRow == row){
                    isCenterRemoved = true;
                }else{
                    matrix.get(row).remove(bombCol);
                }
            }
        }
    }

    private static boolean isInRangeInMatrix(int row, int col) {
        if (isRowInRangeInMatrix(row) && isColInRangeInMatrix(row, col)) {
            return true;
        }

        return false;
    }

    private static boolean isColInRangeInMatrix(int row, int col) {
        if (col >= 0 && col < matrix.get(row).size()) {
            return true;
        }

        return false;
    }

    private static boolean isRowInRangeInMatrix(int row) {
        if (row >= 0 && row < matrix.size()) {
            return true;
        }

        return false;
    }

    private static void PrintMatrix() {
        for (int row = 0; row < matrix.size(); row++) {
            String[] currentRow = matrix.get(row).stream().map(Object::toString).toArray(String[]::new);

            if (currentRow.length > 0) {
                System.out.println(String.join(" ", currentRow));
            }
        }
    }
}