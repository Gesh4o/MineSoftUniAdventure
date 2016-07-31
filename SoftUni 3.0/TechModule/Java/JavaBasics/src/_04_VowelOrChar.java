import java.util.Scanner;

public class _04_VowelOrChar {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String firstChar = scanner.nextLine().trim();
        if (
                firstChar.charAt(0) == 'a' || firstChar.charAt(0) == 'e' ||
                firstChar.charAt(0) == 'o' || firstChar.charAt(0) == 'u' ||
                firstChar.charAt(0) == 'y' ||firstChar.charAt(0) == 'i'){
            System.out.println("vowel");

        } else if (Character.isDigit(firstChar.charAt(0))){
            System.out.println("digit");
        }else {
            System.out.println("other");
        }
    }
}
