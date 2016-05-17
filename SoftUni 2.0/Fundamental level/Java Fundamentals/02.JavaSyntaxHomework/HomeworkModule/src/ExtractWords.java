import java.util.Scanner;

public class ExtractWords {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();
        String pattern = "([^a-zA-Z]+)";

        String result =  input.replaceAll(pattern, " ");

        System.out.println(result);
    }
}
