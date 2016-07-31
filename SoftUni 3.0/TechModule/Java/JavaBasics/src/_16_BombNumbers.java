import java.util.Arrays;
import java.util.Scanner;

public class _16_BombNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Integer[] sequence = Arrays.stream(scanner.nextLine().split("\\s+")).map(Integer::parseInt).toArray(Integer[]::new);
        Integer[] bombInfo = Arrays.stream(scanner.nextLine().split("\\s+")).map(Integer::parseInt).toArray(Integer[]::new);

        int bombNumber = bombInfo[0];
        int bombRange = bombInfo[1];

        for (int index = 0; index < sequence.length; index++) {
            if (sequence[index] == bombNumber) {
                int leftEnd = Math.max(0, index - bombRange);
                int rightEnd = Math.min(sequence.length - 1, index + bombRange);

                for (int indexToRemove = leftEnd; indexToRemove <= rightEnd; indexToRemove++) {
                    sequence[indexToRemove] = 0;
                }
            }
        }
        long sum = 0;

        for (Integer n :
                sequence) {
            sum += n;
        }
        System.out.println(sum);
    }
}
