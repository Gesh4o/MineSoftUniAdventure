import java.util.Arrays;
import java.util.Scanner;

public class OddAndEvenPairs {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Integer[] sequence = Arrays
                .stream("\\s+".split(scanner.nextLine()))
                .map(Integer::parseInt)
                .toArray(Integer[]::new);

        if (sequence == null || sequence.length <= 0 || sequence.length % 2 == 1){
            System.out.println("Invalid length");
            return;
        }

        for (int i = 0; i < sequence.length; i += 2) {
            if (sequence[i] % 2 == 0 && sequence[i+1] % 2 == 0){
                System.out.format("%d,%d -> both are even%n", sequence[i], sequence[i + 1]);
            }
            else if (sequence[i] % 2 == 1 && sequence[i+1] % 2 == 1){
                System.out.format("%d,%d -> both are odd%n", sequence[i], sequence[i + 1]);
            }
            else{
                System.out.format("%d,%d -> different%n", sequence[i], sequence[i + 1]);
            }
        }
    }
}
