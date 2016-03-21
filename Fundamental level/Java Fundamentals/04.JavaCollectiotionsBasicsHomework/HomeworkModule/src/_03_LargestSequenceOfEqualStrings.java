import java.util.HashSet;
import java.util.Objects;
import java.util.Scanner;

public class _03_LargestSequenceOfEqualStrings {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] stringsInput = scanner.nextLine().split("\\s+");
        HashSet<Integer> visitedIndexes = new HashSet<>(stringsInput.length);

        int maxRepetitionsCount = 1;
        int maxRepetitionStringIndex = 0;
        int currentIndex = 0;
        while(currentIndex < stringsInput.length){
            if (visitedIndexes.contains(currentIndex)){
                currentIndex++;
                continue;
            }
            visitedIndexes.add(currentIndex);

            int currentMaxRepetitionsCount = 1;
            for (int nextIndex = currentIndex + 1; nextIndex < stringsInput.length; nextIndex++) {
                if (Objects.equals(stringsInput[nextIndex], stringsInput[currentIndex])){
                    visitedIndexes.add(nextIndex);
                    currentMaxRepetitionsCount++;
                }
            }

            if (currentMaxRepetitionsCount > maxRepetitionsCount){
                maxRepetitionsCount = currentMaxRepetitionsCount;
                maxRepetitionStringIndex = currentIndex;
            }

            currentIndex++;
        }

        for (int i = 0; i < maxRepetitionsCount; i++) {
            System.out.print(stringsInput[maxRepetitionStringIndex] + " ");
        }

        System.out.println();
    }
}
