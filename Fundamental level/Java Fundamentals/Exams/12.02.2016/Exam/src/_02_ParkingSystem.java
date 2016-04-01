import java.util.*;

public class _02_ParkingSystem {
    private static final int CurrentRowAddition = 1;

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Integer[] dimensions = Arrays.stream(scanner.nextLine().split("\\s+")).map(Integer::parseInt).toArray(Integer[]::new);

        Map<Integer, boolean[]> parking = new HashMap<>();

        String command = scanner.nextLine();

        while (!command.equals("stop")) {
            Integer[] coordinates = Arrays.stream(command.split("\\s+")).map(Integer::parseInt).toArray(Integer[]::new);
            Integer z = coordinates[0];
            Integer x = coordinates[1];
            Integer y = coordinates[2];

            if (!parking.containsKey(x)) {
                parking.put(x, new boolean[dimensions[1]]);
            }

            int currentCol = y;
            int leftCol = y - 1;
            int rightCol = y + 1;
            String result = "";
            Boolean isLeftSearch = true;
            while (true) {
                boolean isRowFull = leftCol <= 0 && rightCol > parking.get(x).length;
                if (isRowFull){
                    result = String.format("Row %d full", x);
                    break;
                }

                if (!parking.get(x)[currentCol]) {
                    parking.get(x)[currentCol] = true;
                    break;
                }

                if (isLeftSearch){
                    if (leftCol > 0){
                        currentCol = leftCol;
                        leftCol--;
                        isLeftSearch = false;
                    }else{
                        isLeftSearch = false;
                    }
                }else{
                    if (rightCol < parking.get(x).length){
                        currentCol = rightCol;
                        rightCol++;
                        isLeftSearch = true;
                    }else{
                        rightCol++;
                        isLeftSearch = true;
                    }
                }
            }

            if (result.equals("")){
                Integer distanceTraveled = Math.abs(x - z) + CurrentRowAddition + currentCol;
                result = distanceTraveled.toString();
            }

            System.out.println(result);
            command = scanner.nextLine();
        }
    }
}
