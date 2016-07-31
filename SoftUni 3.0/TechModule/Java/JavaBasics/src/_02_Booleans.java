import java.util.Scanner;

public class _02_Booleans {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Boolean number = Boolean.parseBoolean(scanner.nextLine());

        if (number){
            System.out.println("Yes");
        } else {
            System.out.println("No");

        }
    }
}
