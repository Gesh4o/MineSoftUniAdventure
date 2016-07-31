import java.util.Scanner;

public class _18_PadRight {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();


        if (input.length() < 20) {
            System.out.println(padRight(input, 20, '*'));
        } else {
            System.out.println(input.substring(0, 20));
        }
    }

    private static String padRight(String text, int count, char charr) {
        char[] charArr = text.toCharArray();
        if (charArr.length >= count) {
            return text;
        } else {
            int charCount = charArr.length;
            while (charCount < count){
                text += charr;
                charCount++;
            }

            return text;
        }

    }
}
