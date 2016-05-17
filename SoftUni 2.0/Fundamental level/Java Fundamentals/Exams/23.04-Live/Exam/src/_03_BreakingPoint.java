import java.math.BigInteger;
import java.util.Arrays;
import java.util.Scanner;

public class _03_BreakingPoint {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String command = scanner.nextLine();

        boolean isPointExisting = true;
        long criticalRatio = -1;
        int totalLines = 0;
        StringBuilder stringBuilder = new StringBuilder();
        while (!command.equals("Break it.")) {
            Long[] planeCoordinates = Arrays.stream(command.split("\\s+"))
                    .map(Long::parseLong).toArray(Long[]::new);
            long x1 = planeCoordinates[0];
            long y1 = planeCoordinates[1];

            long x2 = planeCoordinates[2];
            long y2 = planeCoordinates[3];

            long currentCriticalRatio = Math.abs((( x2 + y2)) - ( x1 + y1));
            if (currentCriticalRatio != 0) {
                if (criticalRatio == -1) {
                    criticalRatio = currentCriticalRatio;
                } else {
                    if (criticalRatio != currentCriticalRatio) {
                        isPointExisting = false;
                        System.out.println("Critical breakpoint does not exist.");
                        break;
                    }
                }
            }
            stringBuilder.append(String.format("Line: [%d, %d, %d, %d]%n", x1, y1, x2, y2));
            totalLines++;
            command = scanner.nextLine();
        }

        if (isPointExisting) {
            BigInteger breakingPoint =
                    new BigInteger(Long.toString(criticalRatio))
                            .pow(totalLines)
                            .remainder(new BigInteger(Integer.toString(totalLines)));
            System.out.println(stringBuilder.toString().trim());
            System.out.printf("Critical Breakpoint: %d%n", breakingPoint);
        }

    }
}
