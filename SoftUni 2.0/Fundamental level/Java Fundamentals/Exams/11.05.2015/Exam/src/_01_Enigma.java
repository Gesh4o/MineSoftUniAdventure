import java.util.Scanner;

public class _01_Enigma {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Integer n = Integer.parseInt(scanner.nextLine());

        for (int i = 0; i < n; i++) {
            String message = scanner.nextLine();
            String parsedMessage = message.replaceAll("[0-9\\s]+", "");
            Integer m = parsedMessage.length() / 2;

            for (int charIndex = 0; charIndex < message.length(); charIndex++) {
                if (!(Character.isDigit(message.charAt(charIndex)) || Character.isWhitespace(message.charAt(charIndex)))){
                    System.out.print(Character.toString((char)((int)message.charAt(charIndex) + m)));
                }else{
                    System.out.print(Character.toString(message.charAt(charIndex)));
                }
            }
            System.out.println();
        }
    }
}
