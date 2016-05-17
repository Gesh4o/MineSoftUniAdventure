import java.util.*;
import java.util.stream.Collectors;

public class _09_MostFrequentWord {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String text = scanner.nextLine();

        ArrayList<String> wordsInText = new ArrayList<>(Arrays.asList(text.split("\\W+")));
        String[] wordsInTextAsArray = wordsInText.stream().map(String::toLowerCase).toArray(String[]::new);

        Map<String,Integer> wordsByRepetitions = new HashMap<>();

        for (String word : wordsInTextAsArray) {
            if (wordsByRepetitions.containsKey(word)) {
                wordsByRepetitions.put(word, wordsByRepetitions.get(word) + 1);
            } else {
                wordsByRepetitions.put(word, 1);
            }
        }

        int maxRepetitionsCount = getMaxValue(wordsByRepetitions);

        ArrayList<String> mostFrequentWordsByRepetitions = getMostFrequentWords(wordsByRepetitions, maxRepetitionsCount);


        for (int i = 0; i < mostFrequentWordsByRepetitions.size(); i++) {
            String word = mostFrequentWordsByRepetitions.get(i);
            System.out.printf("%s -> %d times%n",word, maxRepetitionsCount);
        }

    }

    private static ArrayList<String> getMostFrequentWords(Map<String, Integer> wordsByRepetitions, Integer maxValue) {
        ArrayList<String> mostFrequentWords = wordsByRepetitions.keySet()
                .stream()
                .filter(key -> Objects.equals(wordsByRepetitions.get(key), maxValue))
                .collect(Collectors.toCollection(ArrayList::new));

        return mostFrequentWords;
    }

    private static int getMaxValue(Map<String, Integer> wordsByRepetitions) {
        int maxValue = Integer.MIN_VALUE;

        for (Integer repetitionCount : wordsByRepetitions.values()) {
            if (repetitionCount > maxValue){
                maxValue = repetitionCount;
            }
        }

        return  maxValue;
    }
}
