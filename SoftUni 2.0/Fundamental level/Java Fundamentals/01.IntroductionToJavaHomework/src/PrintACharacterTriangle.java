import java.util.Scanner;

public class PrintACharacterTriangle {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Integer inputNumber = scanner.nextInt();

        for (int row = 1; row <= inputNumber; row++) {

            for (int col = 0; col < row; col++){
                System.out.print((char)('a' + col) + " ");
            }

            System.out.println();
        }

        for (int row = inputNumber - 1; row > 0; row--) {

            for (int col = row; col > 0; col--){
                System.out.print((char)('a' + row - col) + " ");
            }

            System.out.println();
        }
    }
}
