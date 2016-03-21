import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashSet;
import java.util.Scanner;

public class _04_LargestIncreasingSequence {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        Integer[] sequence = Arrays
                .stream(scanner.nextLine().split("\\s+"))
                .map(Integer::parseInt)
                .toArray(Integer[]::new);

        HashSet<Integer> visitedIndexes = new HashSet<>(sequence.length);

        int longestSequenceIndex = -1;
        int currentLongestSeqquenceLength = 0;

        ArrayList<ArrayList<Integer>> allIncreasingSequences = new ArrayList<>();

        int currentIndex = 0;
        while (currentIndex < sequence.length){
            if (visitedIndexes.contains(currentIndex)){
                currentIndex++;
                continue;
            }

            ArrayList<Integer> currentSequence = new ArrayList<>();
            currentSequence.add(sequence[currentIndex]);

            for (int nextIndex = currentIndex + 1; nextIndex < sequence.length; nextIndex++) {
                if (sequence[currentIndex].compareTo(sequence[nextIndex]) < 0){
                    currentSequence.add(sequence[nextIndex]);
                    visitedIndexes.add(nextIndex);
                    currentIndex = nextIndex;
                }
                else{
                    break;
                }
            }

            if (currentSequence.size() > currentLongestSeqquenceLength){
                currentLongestSeqquenceLength = currentSequence.size();
                longestSequenceIndex = allIncreasingSequences.size();
            }

            allIncreasingSequences.add(currentSequence);

            currentIndex++;
        }

        for (int sequences = 0; sequences < allIncreasingSequences.size(); sequences++) {
            for (int i = 0; i < allIncreasingSequences.get(sequences).size(); i++) {
                Integer integer = allIncreasingSequences.get(sequences).get(i);
                System.out.print(integer.toString() + " ");
            }

            System.out.println();
        }

        System.out.print("Longest: ");

        for (int i = 0; i < allIncreasingSequences.get(longestSequenceIndex).size(); i++) {
            Integer integer = allIncreasingSequences.get(longestSequenceIndex).get(i);
            System.out.print(integer.toString() + " ");
        }

        System.out.println();



    }
}
