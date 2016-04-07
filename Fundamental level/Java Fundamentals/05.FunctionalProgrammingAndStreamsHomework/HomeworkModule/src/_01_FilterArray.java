import java.util.Arrays;
import java.util.Scanner;

public class _01_FilterArray {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String[] inputSequence = Arrays.stream(scanner.nextLine().split("\\s+")).toArray(String[]::new);

        String[] sortedSequence = Arrays.stream(inputSequence).filter(word -> word.length() > 3).toArray(String[]::new);

        if (sortedSequence == null || sortedSequence.length == 0){
            System.out.println("(empty)");
        } else {
            System.out.println(String.join(" ",  sortedSequence));
        }
    }
}