import java.math.BigDecimal;
import java.text.DecimalFormat;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _15_SimpleExpression {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        BigDecimal sum = new BigDecimal("0.0");

        Matcher matcher = Pattern.compile("(([\\+-])?(\\s+)*([\\d]+[.\\d]*))").matcher(scanner.nextLine());

        while (matcher.find()){
            Double number = Double.parseDouble(String.join("",matcher.group(1).toString().split("\\s+")));
            sum = sum.add(new BigDecimal(number.toString()));
        }

        DecimalFormat format = new DecimalFormat("#.#######");

        System.out.printf(format.format(sum));
    }
}
