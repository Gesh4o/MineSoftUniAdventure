import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class _16_Parachute {
    private static Scanner scanner = new Scanner(System.in);

    private static List<char[]> layout = new ArrayList<>();

    private static int parachuteRow = 1;

    private static int parachuteCol;

    private static final String LandedLikeABossMessage = "Landed on the ground like a boss!";

    private static final String DrawnedLikeACatMessage = "Drowned in the water like a cat!";

    private static final String SmashedLikeADogMessage = "Got smacked on the rock like a dog!";

    private static boolean isFinished = false;


    public static void main(String[] args) {
        initializeLayout();

        fall();

        if (isFinished) {
            System.out.printf("%d %d%n", parachuteRow, parachuteCol);
        }
    }

    private static void fall() {
        int leftDirections = 0;
        int rightDirections = 0;

        for (int row = parachuteRow + 1; row < layout.size(); row++) {
            char[] currentHight = layout.get(row);
            for (char c : currentHight) {
                if (c == '<') {
                    leftDirections++;
                } else if (c == '>') {
                    rightDirections++;
                }
            }

            int positionsToMove = Math.abs(rightDirections - leftDirections);
            parachuteRow++;

            if (rightDirections > leftDirections) {
                parachuteCol = Math.min(layout.get(row).length - 1, parachuteCol + positionsToMove);
            } else if (leftDirections > rightDirections) {
                parachuteCol = Math.max(0, parachuteCol - positionsToMove);
            }

            if (layout.get(row)[parachuteCol] == '/' ||
                    layout.get(row)[parachuteCol] == '\\' ||
                    layout.get(row)[parachuteCol] == '|') {
                System.out.println(SmashedLikeADogMessage);
                isFinished = true;
                break;
            } else if (layout.get(row)[parachuteCol] == '~') {
                System.out.println(DrawnedLikeACatMessage);
                isFinished = true;
                break;
            } else if (layout.get(row)[parachuteCol] == '_') {
                System.out.println(LandedLikeABossMessage);
                isFinished = true;
                break;
            }

            rightDirections = 0;
            leftDirections = 0;
        }
    }

    private static void initializeLayout() {
        String inputInfo = scanner.nextLine();
        int count = 0;

        while (!inputInfo.equals("END")) {
            char[] row = inputInfo.toCharArray();
            layout.add(inputInfo.toCharArray());
            for (int index = 0; index < row.length; index++) {
                if (row[index] == 'o') {
                    parachuteCol = index;
                    parachuteRow = count;
                }
            }

            count++;
            inputInfo = scanner.nextLine();
        }
    }
}