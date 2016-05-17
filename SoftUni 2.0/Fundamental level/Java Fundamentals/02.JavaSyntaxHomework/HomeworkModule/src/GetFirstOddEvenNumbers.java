import java.util.Arrays;
import java.util.Objects;
import java.util.Scanner;

public class GetFirstOddEvenNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Integer[] sequence = Arrays
                .stream(scanner.nextLine().split("\\s+"))
                .map(Integer::parseInt)
                .toArray(Integer[]::new);

        String[] commandInfo = scanner.nextLine().split("\\s+");

        Integer countOfNumbers = Integer.parseInt(commandInfo[1]);

        String numberType = commandInfo[2];

        int leftOver = 0;
        if(Objects.equals(numberType, "odd")){
            leftOver = 1;
        }

        int numbersGotCount = 0;
        int sequenceIndex = 0;

        while(sequenceIndex < sequence.length || countOfNumbers < numbersGotCount){
            if (sequence[sequenceIndex] % 2 == leftOver) {
                System.out.print(sequence[sequenceIndex] + " ");
                numbersGotCount++;
            }

            sequenceIndex++;
        }
    }
}
