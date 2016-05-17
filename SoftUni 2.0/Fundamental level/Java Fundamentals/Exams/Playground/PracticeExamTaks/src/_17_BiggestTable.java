import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;
import java.util.Locale;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _17_BiggestTable {
    private static Scanner scanner = new Scanner(System.in);

    private static List<String> maxValues = new ArrayList<>();

    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);
        BigDecimal maxSum = new BigDecimal("-100000001");

        String input = scanner.nextLine();

        Pattern pattern = Pattern.compile(
                "^<tr><td>.*?<\\/td><td>([0-9\\.|\\-]+)<\\/td><td>([0-9\\.\\-]+|\\-)<\\/td><td>([0-9\\.|\\-]+)<\\/td><\\/tr>$");
        Matcher matcher;
        while (!input.equals("</table>")){
            matcher = pattern.matcher(input);

            if (matcher.find()) {
                String firstStore = matcher.group(1);
                String secondStore = matcher.group(2);
                String thirdStore = matcher.group(3);

                int properValues = 0;

                BigDecimal firstStoreValue = BigDecimal.ZERO;
                BigDecimal secondStoreValue = BigDecimal.ZERO;
                BigDecimal thirdStoreValue = BigDecimal.ZERO;

                if (!firstStore.equals("-")) {
                    firstStoreValue = new BigDecimal(firstStore);
                    properValues++;
                }

                if (!secondStore.equals("-")) {
                    secondStoreValue = new BigDecimal(secondStore);
                    properValues++;
                }

                if (!thirdStore.equals("-")) {
                    thirdStoreValue = new BigDecimal(thirdStore);
                    properValues++;
                }

                BigDecimal currentSum = (firstStoreValue.add(secondStoreValue)).add(thirdStoreValue);

                if (properValues != 0){
                    if (currentSum.compareTo(maxSum) > 0) {
                        maxSum = currentSum;
                        maxValues.clear();
                        if (!firstStore.equals("-")) {
                            maxValues.add(firstStore);
                        }

                        if (!secondStore.equals("-")) {
                            maxValues.add(secondStore);
                        }

                        if (!thirdStore.equals("-")) {
                            maxValues.add(thirdStore);
                        }
                    }
                }
            }
            input = scanner.nextLine();
        }

        if (maxSum.compareTo(new BigDecimal("-100000001")) != 0){
            String maxSumString = maxSum.toString();
            maxSumString = maxSumString.indexOf(".") < 0 ? maxSumString : maxSumString.replaceAll("0*$", "").replaceAll("\\.$", "");
            System.out.printf("%s = %s", maxSumString, String.join(" + ", maxValues));
        }else {
            System.out.println("no data");
        }
    }
}
