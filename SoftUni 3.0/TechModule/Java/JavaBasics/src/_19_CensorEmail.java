import java.util.Scanner;

public class _19_CensorEmail {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String emailToCensor = scanner.nextLine();
        int atIndex = emailToCensor.indexOf('@');
        String replacement = generateString('*', atIndex);
        replacement = replacement + emailToCensor.substring(atIndex);

        String text = scanner.nextLine();

        text = text.replace(emailToCensor, replacement);
        System.out.println(text);
    }

    private static String generateString(char c, int count) {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < count; i++) {
            sb.append(c);
        }

        return sb.toString();
    }
}
