import java.util.Scanner;

public class _10_IndexOfLetters {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String input = scanner.nextLine();

        for(int letter : input.chars().toArray())
        {
            if (Character.isLetter((char)letter))
            {
                char smallLetter = Character.toString((char)letter).toLowerCase().charAt(0);
                System.out.printf("%s -> %d%n", Character.toString(smallLetter), (letter - 97));
            }
        }
    }
}
