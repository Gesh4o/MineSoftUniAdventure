import java.util.Arrays;
import java.util.Scanner;

public class _02_SortArrayWithStreamApi {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Integer[] sequence = Arrays.stream(scanner.nextLine().split("\\s+")).map(Integer::parseInt).toArray(Integer[]::new);

        Integer[] orderedSequence;

        String orderType = scanner.nextLine();

        if (orderType.equals("Ascending")){
            orderedSequence = Arrays.stream(sequence).sorted(Integer::compareTo).toArray(Integer[]::new);

        }else if (orderType.equals("Descending")){
            orderedSequence = Arrays.stream(sequence).sorted((i1, i2) -> i2.compareTo(i1)).toArray(Integer[]::new);
        }else{
            System.out.println("Unknown type!");
            return;
        }

        System.out.println(Arrays.toString(orderedSequence));
    }
}
