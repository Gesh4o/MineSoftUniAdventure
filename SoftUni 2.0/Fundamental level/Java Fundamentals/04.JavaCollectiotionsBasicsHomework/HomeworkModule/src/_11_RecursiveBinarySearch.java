import java.util.Arrays;
import java.util.Scanner;

public class _11_RecursiveBinarySearch {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Integer numberToFind = Integer.parseInt(scanner.nextLine());

        Integer[] sortedSequence = Arrays
                .stream(scanner.nextLine().split("\\s+"))
                .map(Integer::parseInt)
                .toArray(Integer[]::new);

        int indexOfNumberToFind = RecursiveBinarySearch(sortedSequence, numberToFind);

        System.out.println(indexOfNumberToFind);
    }

    private static int RecursiveBinarySearch(Integer[] sortedSequence, Integer numberToFind) {
        int currentIndex = sortedSequence.length / 2;
        int startBoundary = 0;
        int endBoundary = sortedSequence.length - 1;

        int index = BinarySearch(sortedSequence, numberToFind, currentIndex, startBoundary, endBoundary);

        return index;
    }

    private static int BinarySearch(
            Integer[] sortedSequence,
            Integer numberToFind,
            int currentIndex,
            int startBoundary,
            int endBoundary) {
        int index = -1;

        if (startBoundary == endBoundary){
            return index;
        }

        if (sortedSequence[currentIndex].compareTo(numberToFind) == 0){
            // Get the leftmost index.
            while(sortedSequence[currentIndex].compareTo(numberToFind) == 0){
                currentIndex--;
                if (currentIndex < 0){
                    break;
                }
            }

            // Compensate the addition decrement.
            index = currentIndex + 1;
        }
        else if (sortedSequence[currentIndex].compareTo(numberToFind) < 0){
            startBoundary = currentIndex;
            currentIndex = (currentIndex + endBoundary + 2 - 1) / 2;
            index = BinarySearch(sortedSequence,numberToFind, currentIndex, startBoundary, endBoundary);
        }
        else{
            endBoundary = currentIndex;
            currentIndex = (currentIndex + startBoundary) / 2;
            index = BinarySearch(sortedSequence,numberToFind, currentIndex, startBoundary, endBoundary);
        }

        return index;
    }
}
