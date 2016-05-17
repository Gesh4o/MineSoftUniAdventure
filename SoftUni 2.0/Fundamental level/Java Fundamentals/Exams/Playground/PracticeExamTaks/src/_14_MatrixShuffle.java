import java.util.Scanner;

public class _14_MatrixShuffle {

    private static Character[][] matrix;

    private static String text;

    private static Integer textIndex = 0;

    private static Scanner scanner = new Scanner(System.in);

    private static StringBuilder whiteTeam = new StringBuilder();

    private static StringBuilder blackTeam = new StringBuilder();

    public static void main(String[] args) {
        int matrixDimension = Integer.parseInt(scanner.nextLine());
        text = scanner.nextLine();

        initializeMatrix(matrixDimension, text);

        collectTeams();

        String text = whiteTeam.toString().replaceAll("\\s+", "").toLowerCase()
                + blackTeam.toString().replaceAll("\\s+", "").toLowerCase();
        boolean isPalindrome = checkIsPalindrome(text);
        String background = "#E0000F";
        if (isPalindrome) {
            background = "#4FE000";
        }

        System.out.printf(
                "<div style='background-color:%s'>%s</div>%n",
                background,
                whiteTeam.toString() + blackTeam.toString());
    }

    private static boolean checkIsPalindrome(String text) {
        text = text.replaceAll("[^a-zA-Z]+","");
        for (int index = 0; index < text.length(); index++) {
            if (text.charAt(index) != text.charAt(text.length() - 1 - index)) {
                return false;
            }
        }

        return true;
    }

    private static void collectTeams() {
        for (int row = 0; row < matrix.length; row++) {
            for (int col = 0; col < matrix.length; col++) {
                if (row % 2 == 0) {
                    if (col % 2 == 0) {
                        whiteTeam.append(matrix[row][col]);
                    } else {
                        blackTeam.append(matrix[row][col]);
                    }
                } else {
                    if (col % 2 == 1) {
                        whiteTeam.append(matrix[row][col]);
                    } else {
                        blackTeam.append(matrix[row][col]);
                    }
                }
            }
        }
    }

    private static void initializeMatrix(int matrixDimension, String text) {
        matrix = new Character[matrixDimension][matrixDimension];
        populateMatrix();
    }

    private static void populateMatrix() {
        int rightStart = 0;
        int rightEnd = matrix.length - 1;

        int downStart = 1;
        int downEnd = matrix.length - 1;

        int leftStart = (matrix.length - 1) - 1;
        int leftEnd = 0;

        int upStart = (matrix.length - 1) - 1;
        int upEnd = 1;

        while (true) {
            populateRightDirection(rightStart, rightEnd);

            populateDownDirection(downStart, downEnd);

            populateLeftDirection(leftStart, leftEnd);

            populateUpDirection(upStart, upEnd);

            rightStart++;
            rightEnd--;

            if (rightEnd < rightStart) {
                break;
            }

            downStart++;
            downEnd--;

            leftStart--;
            leftEnd++;

            upStart--;
            upEnd++;
        }
    }

    private static void populateUpDirection(int start, int end) {
        int col = end - 1;
        for (int row = start; row >= end; row--) {
            populateCell(row, col);
        }
    }

    private static void populateLeftDirection(int start, int end) {
        int row = start + 1;
        for (int col = start; col >= end; col--) {
            populateCell(row, col);
        }
    }

    private static void populateDownDirection(int start, int end) {
        int col = end;
        for (int row = start; row <= end; row++) {
            populateCell(row, col);
        }
    }

    private static void populateRightDirection(int start, int end) {
        int row = start;
        for (int col = start; col <= end; col++) {
            populateCell(row, col);
        }
    }

    private static void populateCell(int row, int col) {
        if (textIndex < text.length()) {
            matrix[row][col] = text.charAt(textIndex);
            textIndex++;
        } else {
            matrix[row][col] = ' ';
        }
    }
}
