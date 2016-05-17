import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class _01_Pyramid {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Integer n = Integer.parseInt(scanner.nextLine());

        ArrayList<Integer> pyramidSequence = new ArrayList<>();
        Integer topPyramidInteger = Arrays.stream(scanner.nextLine().trim().split("\\s+")).map(Integer::parseInt).findFirst().get();
        pyramidSequence.add(topPyramidInteger);
        for (int i = 1; i < n; i++) {
            Integer[] currentRow = Arrays.stream(scanner.nextLine().trim().split("\\s+")).map(Integer::parseInt).toArray(Integer[]::new);

            Integer currentBiggerNumber = Integer.MAX_VALUE;
            boolean isFound = false;
            for (Integer integer : currentRow) {
                if (integer > topPyramidInteger){
                    if (integer < currentBiggerNumber){
                        currentBiggerNumber = integer;
                        isFound = true;
                    }
                }
            }

            if (!isFound){
                topPyramidInteger++;
            }else{
                topPyramidInteger = currentBiggerNumber;
                pyramidSequence.add(currentBiggerNumber);
            }
        }

        String result = pyramidSequence.toString().substring(1,pyramidSequence.toString().length() - 1);
        System.out.println(result);
    }
}
