import java.util.Arrays;
import java.util.Scanner;

public class _13_StuckNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Integer number = Integer.parseInt(scanner.nextLine());

        Integer[] sequence = Arrays
                .stream(scanner.nextLine().split("\\s+"))
                .map(Integer::parseInt)
                .toArray(Integer[]::new);


        Boolean isMatchFound = false;

        for (int a = 0; a < sequence.length; a++) {
            Integer firstNumber = sequence[a];
            for (int b = 0; b < sequence.length; b++) {
                Integer secondNumber = sequence[b];
                String firstMatch = (firstNumber.toString() + secondNumber.toString());
                for (int c = 0; c < sequence.length ; c++) {
                    Integer thirdNumber = sequence[c];
                    for (int d = 0; d < sequence.length; d++) {
                        if ( a == b || a == c || a == d || b == c || b == d || c == d){
                            continue;
                        }

                        Integer fourthNumber = sequence[d];
                        String secondMatch = (thirdNumber.toString() + fourthNumber.toString());

                        if (firstMatch.equals(secondMatch)){
                            System.out.printf("%d|%d==%d|%d%n", firstNumber, secondNumber, thirdNumber, fourthNumber);
                            isMatchFound = true;
                        }
                    }
                }
            }
        }

        if (!isMatchFound){
            System.out.println("No");
        }
    }
}
