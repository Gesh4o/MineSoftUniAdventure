import java.util.Arrays;
import java.util.Scanner;

public class _03_RubikMatrix {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Integer[] arrayDimensions = Arrays.stream(scanner.nextLine().split("\\s+")).map(Integer::parseInt).toArray(Integer[]::new);

        int[][] orderedMatrix = initializeMatrix(arrayDimensions);

        int[][] rubikMatrix = initializeMatrix(arrayDimensions);

        int counter = Integer.parseInt(scanner.nextLine());

        for (int i = 0; i < counter; i++) {
            String[] commandInfo = scanner.nextLine().split("\\s+");
            String direction = commandInfo[1];
            int timesToMove = Integer.parseInt(commandInfo[2]);

            if (direction.equals("up") || direction.equals("down")){
                int column =  Integer.parseInt(commandInfo[0]);

                timesToMove = timesToMove % rubikMatrix[1].length;
                if (direction.equals("up")){
                    moveColumnUp(rubikMatrix, timesToMove, column);
                }else {
                    moveColumnDown(rubikMatrix, timesToMove, column);
                }
            }else{
                int row =  Integer.parseInt(commandInfo[0]);

                timesToMove = timesToMove % rubikMatrix[0].length;
                for (int move = 0; move < timesToMove; move++) {
                    if (direction.equals("right")){
                        moveRowRight(rubikMatrix, rubikMatrix[row]);
                    }else{
                        moveRowLeft(rubikMatrix, rubikMatrix[row]);
                    }
                }
            }
        }


        for (int row = 0; row < rubikMatrix[0].length; row++) {
            for (int col = 0; col < rubikMatrix[1].length; col++) {
                if (orderedMatrix[row][col] == rubikMatrix[row][col]){
                    System.out.println("No swap required");
                }else{
                    findNextNumberAndPrintSwapInformation(orderedMatrix[row][col], rubikMatrix, row, col);
                }
            }
        }
    }

    private static void findNextNumberAndPrintSwapInformation(int i, int[][] rubikMatrix, int row, int col) {
        for (int nextRow = row ; nextRow < rubikMatrix[0].length; nextRow++) {
            for (int nextCol = 0; nextCol < rubikMatrix[1].length; nextCol++) {
                if (i == rubikMatrix[nextRow][nextCol]){
                    System.out.printf("Swap (%d, %d) with (%d, %d)%n",row,col,nextRow, nextCol);
                    rubikMatrix[nextRow][nextCol] = rubikMatrix[row][col];
                    rubikMatrix[row][col] = i;
                }

            }
        }
    }

    private static void moveRowLeft(int[][] rubikMatrix, int[] matrixRow) {
        int firstLeftElementValue = matrixRow[0];
        System.arraycopy(matrixRow, 1, matrixRow, 0, rubikMatrix[1].length - 1);

        matrixRow[rubikMatrix[1].length - 1] = firstLeftElementValue;
    }

    private static void moveRowRight(int[][] rubikMatrix, int[] matrixRow) {
        int lastRightElementValue = matrixRow[rubikMatrix[1].length - 1];

        System.arraycopy(matrixRow, 0, matrixRow, 1, rubikMatrix.length - 1);

        matrixRow[0] = lastRightElementValue;
    }

    private static void moveColumnDown(int[][] rubikMatrix, int moveCount, int column) {
        for (int j = 0; j < moveCount; j++) {
            int lastElementOldValue = rubikMatrix[rubikMatrix.length - 1][column];
            for (int row = rubikMatrix[0].length - 1; row > 0; row--) {
                rubikMatrix[row][column] = rubikMatrix[row - 1][column];
            }

            rubikMatrix[0][column] = lastElementOldValue;
        }
    }

    private static void moveColumnUp(int[][] rubikMatrix, int moveCount, int column) {
        for (int move = 0; move < moveCount; move++) {
            int firstElementOldValue = rubikMatrix[0][column];
            for (int row = 0; row < rubikMatrix[0].length - 1; row++) {
                rubikMatrix[row][column] = rubikMatrix[row + 1][column];
            }

            rubikMatrix[rubikMatrix[0].length - 1][column] = firstElementOldValue;
        }
    }

    private static void printMatrix(int[][] rubikMatrix) {
        for (int row = 0; row < rubikMatrix[0].length; row++) {
            for (int col = 0; col < rubikMatrix[1].length; col++) {
                System.out.printf("%d ", rubikMatrix[row][col]);
            }
            System.out.println();
        }
    }

    private static  int[][] initializeMatrix(Integer[] arrayDimensions) {
        int[][] matrix = new int[arrayDimensions[0]][arrayDimensions[1]];
        int counter = 1;
        for (int row = 0; row < matrix[0].length; row++) {
            for (int col = 0; col < matrix[1].length; col++) {
                matrix[row][col] = counter;
                counter++;
            }
        }

        return matrix;
    }
}
