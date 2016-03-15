import java.util.Scanner;

public class CharacterMultiplier {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String[] inputInfo = scanner.nextLine().split("\\s+");

        Integer result = getCharacterMultiplyResult(inputInfo[0], inputInfo[1]);

        System.out.println(result);
    }

    private static Integer getCharacterMultiplyResult(String firstString, String secondString) {
        Integer result = 0;
        char[] firstCharArray = firstString.toCharArray();
        char[] secondCharArray = secondString.toCharArray();

        for (int i = 0; i < firstString.length(); i++) {
            result += firstCharArray[i] * secondCharArray[i];
        }

        if (firstCharArray.length > secondCharArray.length){
            for (int i = secondCharArray.length; i < firstCharArray.length; i++) {
                result += firstCharArray[i];
            }
        }
        else if (secondCharArray.length > firstCharArray.length){
            for (int i = firstCharArray.length; i < secondCharArray.length; i++) {
                result += secondCharArray[i];
            }
        }

        return result;
    }
}
