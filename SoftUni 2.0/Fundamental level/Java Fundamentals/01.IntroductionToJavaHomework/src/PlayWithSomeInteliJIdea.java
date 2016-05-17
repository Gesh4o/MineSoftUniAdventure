import java.util.Scanner;

public class PlayWithSomeInteliJIdea {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();
        print(input);
        String newString = String.format("%s%s%d", "place ",  "holder ", 3);
        print(newString);
        System.out.println("Hello Java!{0}");

        Integer five = 5;
        Double fivePointFive = 5.5;
        print(five.toString());
        print(fivePointFive.toString());
    }

    public static void print(String input) {
        System.out.println(input);
    }
}
