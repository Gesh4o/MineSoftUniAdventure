import java.util.Scanner;

public class _05_IntegerToHexAndBinary {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Integer number = scanner.nextInt();
        scanner.nextLine();

        System.out.println(Integer.toHexString(number).toUpperCase());
        System.out.println(Integer.toBinaryString(number));
    }
}
