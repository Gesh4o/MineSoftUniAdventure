import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

public class _07_MagicExchangeableWords {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String[] inputArgs = scanner.nextLine().split("\\s+");

        String firstString = inputArgs[0];
        String secondString = inputArgs[1];

        // Dictionary will contains every char from first strings as key and its char representation in the second string.
        Map<Character,Character> exchangeableWords = new HashMap<Character, Character>();

        Boolean isExchangeable = true;
        for (int i = 0; i < inputArgs[0].length(); i++) {

            // If the char is not added yet, add it with value- the char at (same)index i from the second string.
            if (!exchangeableWords.containsKey(firstString.charAt(i))){
                exchangeableWords.put(firstString.charAt(i),secondString.charAt(i));
            }

            // If the char is added checks if its value is equal to current representation from the second string.
            // If the words are not exchangeable(aka current value in dictionary is not equal to current char from second string)
            // we exit from the loop.
            else if (exchangeableWords.containsKey(firstString.charAt(i))) {if (!exchangeableWords.get(firstString.charAt(i)).equals(secondString.charAt(i))){
                    isExchangeable = false;
                    break;
                }
            }
        }

        System.out.println(isExchangeable);
    }
}
