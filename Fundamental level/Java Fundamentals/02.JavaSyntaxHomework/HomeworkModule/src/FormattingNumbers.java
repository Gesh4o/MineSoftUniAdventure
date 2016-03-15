import java.util.Locale;
import java.util.Scanner;

public class FormattingNumbers {
    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);
        Scanner scanner = new Scanner(System.in);
        Integer a = scanner.nextInt();
        Double b = scanner.nextDouble();
        Double c = scanner.nextDouble();

        /**
         * System.out.format("%d%n", n);      //  -->  "461012"
         System.out.format("%08d%n", n);    //  -->  "00461012"
         System.out.format("%+8d%n", n);    //  -->  " +461012"
         System.out.format("%,8d%n", n);    // -->  " 461,012"
         System.out.format("%+,8d%n%n", n); //  -->  "+461,012"

         double pi = Math.PI;

         System.out.format("%f%n", pi);       // -->  "3.141593"
         System.out.format("%.3f%n", pi);     // -->  "3.142"
         System.out.format("%10.3f%n", pi);   // -->  "     3.142"
         System.out.format("%-10.3f%n", pi);  // -->  "3.142"
         System.out.format(Locale.FRANCE,
         "%-10.4f%n%n", pi); // -->  "3,1416"

         */

        String formattedString = String.format(
                "|%-10s|%010d|%10.2f|%-10.3f|",
                Integer.toHexString(a).toUpperCase(),
                Integer.parseInt(Integer.toBinaryString(a)),
                b,
                c);
        System.out.println(formattedString);
    }
}
