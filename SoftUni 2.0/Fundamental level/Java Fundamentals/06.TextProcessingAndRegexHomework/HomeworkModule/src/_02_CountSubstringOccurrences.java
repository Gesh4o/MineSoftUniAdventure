import java.util.Scanner;

public class _02_CountSubstringOccurrences {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String inputText = scanner.nextLine().toLowerCase();
        String substringToFind = scanner.nextLine().toLowerCase();

        int matchesCount = 0;
        for (int i = 0; i < inputText.length() - substringToFind.length() + 1; i++) {
            String currentString = inputText.substring(i, i + substringToFind.length());

            if(currentString.equals(substringToFind)){
                boolean isStartOfString = false;
                boolean isMiddleOfString = false;
                boolean isEndOfString = false;

                // Checks if the current char is start of the input text or previous char is not letter(start of a word)
                // Then checks the char after the current substring if it is letter.
                if ((i == 0 || !Character.isLetter(inputText.charAt(i - 1))) &&
                        Character.isLetter(inputText.charAt(i + substringToFind.length()))){
                    isStartOfString = true;
                }
                // Checks if the current char is not the first from the text input and it is not
                // last possible start of new subsequence(aka end of the text input).
                // Then checks the previous and the next char of the substring if it is letter.
                else if ((i > 0 && i < inputText.length() - substringToFind.length()) &&
                        Character.isLetter(inputText.charAt(i - 1)) &&
                        Character.isLetter(inputText.charAt(i + substringToFind.length()))) {
                    isMiddleOfString = true;
                }

                // Checks if this is the last possible match or the next char is not letter
                // Then checks if previous char is letter.
                else if (((i == inputText.length() - substringToFind.length())||
                        !Character.isLetter(inputText.charAt(i + substringToFind.length()))) &&
                        (i > 0 && Character.isLetter(inputText.charAt(i - 1)))){
                    isEndOfString = true;
                }

                if (isStartOfString || isMiddleOfString || isEndOfString){
                    matchesCount++;
                }
            }
        }

        System.out.println(matchesCount);
    }
}
