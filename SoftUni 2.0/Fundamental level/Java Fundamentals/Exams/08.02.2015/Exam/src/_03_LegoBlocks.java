import java.util.Arrays;
import java.util.Scanner;
import java.util.stream.Stream;

public class _03_LegoBlocks {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Integer n = Integer.parseInt(scanner.nextLine());

        Integer[][] firstMatrix = new Integer[n][];
        for (int i = 0; i < n; i++) {
            firstMatrix[i] = Arrays.stream(scanner.nextLine().trim().split("\\s+")).map(Integer::parseInt).toArray(Integer[]::new);
        }

        Integer[][] secondMatrix = new Integer[n][];
        for (int i = 0; i < n; i++) {
            secondMatrix[i] = Arrays.stream(scanner.nextLine().trim().split("\\s+")).map(Integer::parseInt).toArray(Integer[]::new);
        }

        boolean doPerformRectangle = true;
        int firstRowLength = firstMatrix[0].length + secondMatrix[0].length;
        for (int i = 1; i < n; i++) {
            int currentRowLength = firstMatrix[i].length + secondMatrix[i].length;

            if (currentRowLength != firstRowLength){
                doPerformRectangle = false;
                break;
            }
        }

        if (doPerformRectangle){
            Integer[][] rectangularMatrix = new Integer[n][];
            for (int i = 0; i < n; i++) {
                Integer[] currentRowArray = Stream
                        .concat(Stream.of(firstMatrix[i]),Stream.of(reverseArray(secondMatrix[i])))
                        .toArray(Integer[]::new);
                rectangularMatrix[i] = currentRowArray;
            }

            printMatrix(rectangularMatrix);
        }else{
            long cellsInMatrices = 0;
            for (int i = 0; i < n; i++) {
                cellsInMatrices += firstMatrix[i].length;
                cellsInMatrices += secondMatrix[i].length;
            }

            System.out.printf("The total number of cells is: %d",cellsInMatrices);

        }
    }

    private static void printMatrix(Integer[][] rectangularMatrix) {
        for (int i = 0; i < rectangularMatrix.length; i++) {
            String[] currentRow = Arrays.stream(rectangularMatrix[i]).map(Object::toString).toArray(String[]::new);
            System.out.printf("[%s]%n", String.join(", ", currentRow));
        }
    }

    private static Integer[] reverseArray(Integer[] integers) {
        for (int i = 0; i < integers.length / 2; i++) {
            Integer oldValue = integers[i];
            integers[i] = integers[integers.length - 1 - i];
            integers[integers.length - 1 - i] = oldValue;
        }
        return integers;
    }
}
