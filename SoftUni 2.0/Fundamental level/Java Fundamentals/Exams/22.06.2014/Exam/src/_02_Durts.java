import java.util.Arrays;
import java.util.Scanner;

public class _02_Durts {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Integer[] crossCenterCoordinates = Arrays.stream(scanner.nextLine().split("\\s+")).map(Integer::parseInt).toArray(Integer[]::new);

        Integer r = Integer.parseInt(scanner.nextLine());

        Integer n = Integer.parseInt(scanner.nextLine());

        if (n > 0) {
            Integer[] shotsCoordinates = Arrays.stream(scanner.nextLine().split("\\s+")).map(Integer::parseInt).toArray(Integer[]::new);


            for (int shot = 0; shot < shotsCoordinates.length; shot += 2) {

                int shotX = shotsCoordinates[shot];
                int shotY = shotsCoordinates[shot + 1];
                boolean isInHorizontalRectangle = isInHorizontalRectangle(crossCenterCoordinates, r, shotX, shotY);


                boolean isInVerticalRectangle = isInVerticalRectangle(crossCenterCoordinates, r, shotX, shotY);

                if (isInHorizontalRectangle || isInVerticalRectangle) {
                    System.out.println("yes");
                } else {
                    System.out.println("no");
                }

            }
        }

    }

    private static boolean isInHorizontalRectangle(Integer[] crossCenterCoordinates, Integer r, int x, int y) {
        int rectangleBottomBoundary = crossCenterCoordinates[0] - r / 2;
        int rectangleTopBoundary = crossCenterCoordinates[0] + r / 2;

        int rectangleLeftBoundary = crossCenterCoordinates[1] - r;
        int rectangleRightBoundary = crossCenterCoordinates[1] + r;

        return (x >= rectangleBottomBoundary && x <= rectangleTopBoundary) && (y >= rectangleLeftBoundary && y <= rectangleRightBoundary);
    }

    private static boolean isInVerticalRectangle(Integer[] crossCenterCoordinates, Integer r, int x, int y) {
        int rectangleBottomBoundary = crossCenterCoordinates[0] - r;
        int rectangleTopBoundary = crossCenterCoordinates[0] + r;

        int rectangleLeftBoundary = crossCenterCoordinates[1] - r / 2;
        int rectangleRightBoundary = crossCenterCoordinates[1] + r / 2;

        return (x >= rectangleBottomBoundary && x <= rectangleTopBoundary) && (y >= rectangleLeftBoundary && y <= rectangleRightBoundary);
    }
}
