import java.util.ArrayList;
import java.util.Scanner;

public class _03_DragonTrap {
    private static  ArrayList<Character> symbolsToRotate = new ArrayList<Character>();
    private static ArrayList<Cell> cellsToRotate = new ArrayList<Cell>();

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int numberOfRows = Integer.parseInt(scanner.nextLine());
        String[] originalMatrix = new String[numberOfRows];
        char[][] rotatedMatrix = new char[numberOfRows][];

        readMatrix(scanner, numberOfRows, originalMatrix, rotatedMatrix);

        String command = scanner.nextLine();
        while (!command.equals("End")) {
            String[] tokens = command
                    .replaceAll("[\\s()]+", " ")
                    .trim()
                    .split(" ");

            int centerRow = Integer.parseInt(tokens[0]);
            int centerCol = Integer.parseInt(tokens[1]);
            int radius = Integer.parseInt(tokens[2]);
            int rotations = Integer.parseInt(tokens[3]);

            getSymbolsToRotate(rotatedMatrix, centerRow, centerCol, radius);

            if (symbolsToRotate.size() > 0) {
                rotations %= symbolsToRotate.size();

                if (rotations != 0) {
                    int index = rotations < 0 ? -rotations : symbolsToRotate.size() - rotations;

                    for (Cell cell : cellsToRotate) {
                        rotatedMatrix[cell.getRow()][cell.getColumn()] = symbolsToRotate.get(index);
                        index = (index + 1) % symbolsToRotate.size();
                    }
                }
            }

            symbolsToRotate.clear();
            cellsToRotate.clear();
            command = scanner.nextLine();
        }

        printOutput(originalMatrix, rotatedMatrix);
    }

    private static void readMatrix(Scanner scanner, int numberOfRows, String[] originalMatrix, char[][] rotatedMatrix) {
        for (int i = 0; i < numberOfRows; i++) {
            String input = scanner.nextLine();

            originalMatrix[i] = input;
            rotatedMatrix[i] = input.toCharArray();
        }
    }

    private static void getSymbolsToRotate(char[][] rotatedMatrix, int centerRow, int centerCol, int radius) {
        int startRow = centerRow - radius;
        int startCol = centerCol - radius;
        int endCol = centerCol + radius;
        int endRow = centerRow + radius;
        int row;
        int col;

        for (col = startCol, row = startRow; col <= endCol; col++) {
            if (isInsideMatrix(row, col, rotatedMatrix)) {
                symbolsToRotate.add(rotatedMatrix[row][col]);
                cellsToRotate.add(new Cell(row, col));
            }
        }

        for (row = startRow + 1, col = endCol; row <= endRow; row++) {
            if (isInsideMatrix(row, col, rotatedMatrix)) {
                symbolsToRotate.add(rotatedMatrix[row][col]);
                cellsToRotate.add(new Cell(row, col));
            }
        }

        for (col = endCol - 1, row = endRow; col >= startCol; col--) {
            if (isInsideMatrix(row, col, rotatedMatrix)) {
                symbolsToRotate.add(rotatedMatrix[row][col]);
                cellsToRotate.add(new Cell(row, col));
            }
        }

        for (row = endRow - 1, col = startCol; row > startRow; row--) {
            if (isInsideMatrix(row, col, rotatedMatrix)) {
                symbolsToRotate.add(rotatedMatrix[row][col]);
                cellsToRotate.add(new Cell(row, col));
            }
        }
    }

    private static boolean isInsideMatrix(int currentRow, int currentCol, char[][] matrix) {

        return 0 <= currentRow
                && currentRow < matrix.length
                && 0 <= currentCol
                && currentCol < matrix[currentRow].length;
    }

    private static void printOutput(String[] originalMatrix, char[][] rotatedMatrix) {
        int changedSymbols = 0;

        for (int i = 0; i < rotatedMatrix.length; i++) {
            for (int j = 0; j < rotatedMatrix[i].length; j++) {
                if (rotatedMatrix[i][j] != originalMatrix[i].charAt(j)) {
                    changedSymbols++;
                }

                System.out.print(rotatedMatrix[i][j]);
            }

            System.out.println();
        }

        System.out.printf("Symbols changed: %d", changedSymbols);
    }
}

class Cell {
    int row;
    int column;

    public Cell(int row, int column) {
        this.row = row;
        this.column = column;
    }

    public int getRow() {
        return this.row;
    }

    public int getColumn() {
        return this.column;
    }
}