import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class _07_CombineListsOfLetters {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String[] firstSequenceOfLetters = scanner.nextLine().split("\\s+");
        String[] secondSequenceOfLetters = scanner.nextLine().split("\\s+");

        ArrayList<String> resultList =  new ArrayList<>(Arrays.asList(firstSequenceOfLetters));
        for (String letter : secondSequenceOfLetters) {
            if(!resultList.contains(letter)){
                resultList.add(letter);
            }
        }

        PrintList(resultList);
    }

    private static void PrintList(ArrayList<String> resultArray) {
        for (int i = 0; i < resultArray.size(); i++) {
            String element = resultArray.get(i);
            System.out.print(element + " ");
        }

        System.out.println();
    }
}
