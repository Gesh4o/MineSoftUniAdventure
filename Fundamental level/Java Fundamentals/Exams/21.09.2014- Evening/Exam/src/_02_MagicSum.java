import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Scanner;

public class _02_MagicSum {
    private static int d;

    private static List<Integer> numbers;

    private static List<Integer[]> combinations;

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        d = Integer.parseInt(scanner.nextLine());

        String command = scanner.nextLine();
        numbers = new ArrayList<>();
        combinations = new ArrayList<>();
        while (!command.equals("End")) {
            Integer number = Integer.parseInt(command);
            numbers.add(number);
            command = scanner.nextLine();
        }

        for (int firstNum = 0; firstNum < numbers.size(); firstNum++) {
            for (int secondNum = 0; secondNum < numbers.size(); secondNum++) {
                for (int thirdNum = 0; thirdNum < numbers.size(); thirdNum++) {
                    Long sum = (long) (numbers.get(firstNum) + numbers.get(secondNum) + numbers.get(thirdNum));
                    if (sum < 0){
                        sum *= (-1);
                    }
                    if ((firstNum != thirdNum && secondNum != thirdNum && firstNum != secondNum) &&
                            (sum) % d == 0) {
                        combinations.add(new Integer[]{numbers.get(firstNum), numbers.get(secondNum), numbers.get(thirdNum)});
                    }
                }
            }
        }

        int biggestSum = Integer.MIN_VALUE;
        int biggestSumIndex = -1;
        for (int i = 0; i < combinations.size(); i++) {
            int sum = 0;
            for (Integer integer : combinations.get(i)) {
                sum += integer;
            }

            if (sum > biggestSum) {
                biggestSum = sum;
                biggestSumIndex = i;
            }
        }
        if (biggestSumIndex >= 0) {
            PrintResult(combinations.get(biggestSumIndex));
        } else {
            System.out.println("No");
        }

    }

    private static void PrintResult(Integer[] combinationArray) {
        System.out.printf("(%d + %d + %d) %% %d = 0",
                combinationArray[0],
                combinationArray[1],
                combinationArray[2],
                d);
    }
}
