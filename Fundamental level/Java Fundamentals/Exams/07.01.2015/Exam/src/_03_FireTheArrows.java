import java.util.Scanner;

public class _03_FireTheArrows {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Integer n = Integer.parseInt(scanner.nextLine());

        char[][] matrix = new char[n][];
        boolean[][] boolMatrix = new boolean[n][];
        for (int i = 0; i < n; i++) {
            char[] currentInputSequence = scanner.nextLine().toCharArray();
            matrix[i] = currentInputSequence;
            boolMatrix[i] = new boolean[currentInputSequence.length];
        }

        int arrowsCount = 0;
        for (char[] array : matrix) {
            for (char c : array) {
                if (c == '>' || c == '<' || c == 'v' || c == '^') {
                    arrowsCount++;
                }
            }
        }

        int arrowsDone = 0;
        while (arrowsCount != arrowsDone) {
            int blockedArrows = 0;
            for (int row = 0; row < matrix.length; row++) {
                for (int col = 0; col < matrix[row].length; col++) {
                    if (boolMatrix[row][col]) {
                        continue;
                    }

                    char currentChar = matrix[row][col];

                    switch (currentChar) {
                        case '^':
                            if (row - 1 < 0 || boolMatrix[row - 1][col] || matrix[row -1][col] == 'v') {
                                boolMatrix[row][col] = true;
                                arrowsDone++;

                            } else if (matrix[row - 1][col] == 'o') {
                                matrix[row - 1][col] = matrix[row][col];
                                matrix[row][col] = 'o';
                            }else{
                                blockedArrows++;
                            }
                            break;
                        case 'v':
                            if (row + 1 >= matrix.length || boolMatrix[row + 1][col] || matrix[row + 1][col] == '^') {
                                boolMatrix[row][col] = true;
                                arrowsDone++;

                            } else if (matrix[row + 1][col] == 'o') {
                                matrix[row + 1][col] = matrix[row][col];
                                matrix[row][col] = 'o';
                            } else {
                                blockedArrows++;
                            }
                            break;
                        case '>':
                            if (col + 1 >= matrix[row].length || boolMatrix[row][col + 1] || matrix[row][col + 1] == '<') {
                                boolMatrix[row][col] = true;
                                arrowsDone++;

                            } else if (matrix[row][col + 1] == 'o') {
                                matrix[row][col + 1] = matrix[row][col];
                                matrix[row][col] = 'o';
                            } else{
                                blockedArrows++;
                            }
                            break;
                        case '<':
                            if (col - 1 < 0 || boolMatrix[row][col - 1] || matrix[row][col - 1] == '>') {
                                boolMatrix[row][col] = true;
                                arrowsDone++;

                            } else if (matrix[row][col - 1] == 'o') {
                                matrix[row][col - 1] = matrix[row][col];
                                matrix[row][col] = 'o';
                            } else{
                                blockedArrows++;
                            }
                            break;
                    }

                    if (arrowsCount == arrowsDone || blockedArrows == arrowsCount) {
                        printMatrix(matrix);
                        return;
                    }
                }
            }
        }
    }

    private static void printMatrix(char[][] matrix) {
        for (char[] array : matrix) {
            for (char c : array) {
                System.out.print(c);
            }

            System.out.println();
        }
    }
}
