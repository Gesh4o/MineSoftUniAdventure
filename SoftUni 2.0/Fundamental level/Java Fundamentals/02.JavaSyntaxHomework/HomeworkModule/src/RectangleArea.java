import java.util.Arrays;
import java.util.Scanner;

public class RectangleArea {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        // Locale.setDefault(Locale.ROOT);
        /**
        String[] inputData = scanner.nextLine().split("\\s+");

         Double[] rectangleSidesArray = new Double[inputData.length];

        for (int i = 0; i < inputData.length; i++) {
            rectangleSidesArray[i] = Double.parseDouble(inputData[i]);
        }
        */

        Double[] rectangleSides = Arrays
                .stream(scanner.nextLine().split("\\s+"))
                .map(Double::parseDouble)
                .toArray(Double[]::new);

        Double rectangleArea = rectangleSides[0].doubleValue() * rectangleSides[1];

        System.out.println(rectangleArea);
    }
}
