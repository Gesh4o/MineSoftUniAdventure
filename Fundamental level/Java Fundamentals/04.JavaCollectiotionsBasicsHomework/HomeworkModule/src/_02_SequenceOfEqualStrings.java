import java.util.HashSet;
import java.util.Objects;
import java.util.Scanner;

public class _02_SequenceOfEqualStrings {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] stringsInput = scanner.nextLine().split("\\s+");

        // HashSet contains only unique values.
        HashSet<Integer> visitedIndexes = new HashSet<>(stringsInput.length);

        int currentIndex = 0;

        while(currentIndex < stringsInput.length){
            if (visitedIndexes.contains(currentIndex)){
                currentIndex++;
                continue;
            }

            int currentRepetitionsCount = 1;
            for (int nextIndex = currentIndex + 1; nextIndex < stringsInput.length; nextIndex++) {
                if (stringsInput[currentIndex].equals(stringsInput[nextIndex])){
                    visitedIndexes.add(nextIndex);
                    currentRepetitionsCount++;
                }
            }

            for (int count = 0; count < currentRepetitionsCount; count++) {
                System.out.print(stringsInput[currentIndex] + " ");
            }
            System.out.println();

            currentIndex++;
        }
    }
}
