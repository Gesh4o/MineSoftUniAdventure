import java.util.Scanner;

public class _17_ReverseString {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();

        for (int i = input.length() - 1; i >= 0; i--) {
            System.out.print(input.charAt(i));
        }

        System.out.println();
    }
    public static String padRight(String s, int n) {
        return String.format("%1$-" + n + "s", s);
    }
}
