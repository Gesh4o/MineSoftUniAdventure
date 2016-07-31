import java.util.Scanner;

public class _01_VarInHex {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Integer number = Integer.parseInt(scanner.nextLine(), 16);

        System.out.println(number);
    }
}
