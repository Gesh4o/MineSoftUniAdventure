import java.util.*;

public class _08_ExtractAllUniqueWords {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String text = scanner.nextLine();

        String[] wordsInText = text.split("\\W+");

        for (int i = 0; i < wordsInText.length; i++) {
            wordsInText[i] = wordsInText[i].toLowerCase();
        }

        HashSet<String> uniqueCharacters = new HashSet<>(Arrays.asList(wordsInText));

        wordsInText = Arrays.stream(uniqueCharacters.toArray()).toArray(String[]::new);

        ArrayList<String> uniqueCharactersAsList = new ArrayList<>(Arrays.asList(wordsInText));
        Collections.sort(uniqueCharactersAsList);

        PrintList(uniqueCharactersAsList);
    }

    private static void PrintList(ArrayList<String> resultArray) {
        for (int i = 0; i < resultArray.size(); i++) {
            String element = resultArray.get(i);
            System.out.print(element + " ");
        }

        System.out.println();
    }
}
