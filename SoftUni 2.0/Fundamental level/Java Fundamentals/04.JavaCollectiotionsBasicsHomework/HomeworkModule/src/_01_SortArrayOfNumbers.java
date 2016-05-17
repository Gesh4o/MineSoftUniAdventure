import java.util.*;

public class _01_SortArrayOfNumbers {
    public static void main(String[] args) {
        // ToDo: Make generic.

        Locale.setDefault(Locale.ROOT);
        Scanner scanner = new Scanner(System.in);

        Integer[] sequence = Arrays
                .stream(scanner.nextLine().split("\\s+"))
                .map(Integer::parseInt)
                .toArray(Integer[]::new);

        InsertionSortSequence(sequence);

        for (int i = 0; i < sequence.length; i++) {
            Integer integer = sequence[i];
            System.out.print(integer + " ");
        }
    }

    private static void InsertionSortSequence(Integer[] sequence) {
        List<Integer> sequenceList = new ArrayList<>(Arrays.asList(sequence));
        for (int i = 0; i < sequenceList.size() - 1; i++) {
            int currentNextIndex = i + 1;
            int currentUnsortedIndex = i;
            int indexToInsertAt = i + 1;

            while(sequenceList.get(currentNextIndex).compareTo(sequenceList.get(currentUnsortedIndex)) < 0){
                indexToInsertAt = currentUnsortedIndex;

                if (currentUnsortedIndex <= 0){
                    break;
                }

                currentUnsortedIndex--;
            }

            if (indexToInsertAt != i + 1 ){
                sequenceList.add(indexToInsertAt, sequence[currentNextIndex]);
                sequenceList.remove(currentNextIndex + 1);
            }
        }

        for (int i = 0; i < sequence.length; i++) {
            sequence[i] = sequenceList.get(i);
        }
    }
}
