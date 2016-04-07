import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

public class _01_MirrorNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Integer n = Integer.parseInt(scanner.nextLine());

        String[] inputInfo = scanner.nextLine().split("\\s+");
        Map<Integer, Integer> pairs = new HashMap<>();
        boolean isResultFound = false;
        for (int currentIndex = 0; currentIndex < n; currentIndex++) {
            String currentValue = inputInfo[currentIndex];
            for (int comparingIndex = 0; comparingIndex < n; comparingIndex++) {
                if (currentIndex == comparingIndex) {
                    continue;
                }

                String comparingValue = inputInfo[comparingIndex];
                String reversedComparingValue = getReversedStringValue(comparingValue);

                if (currentValue.equals(reversedComparingValue)) {
                    Integer currentNumber = Integer.parseInt(currentValue);
                    Integer comparingNumber = Integer.parseInt(comparingValue);
                    if (!currentNumber.equals(comparingNumber) && !pairs.containsKey(comparingNumber)) {
                        isResultFound = true;
                        System.out.printf("%s<!>%s%n", currentValue, comparingValue);
                        pairs.put(currentNumber,comparingNumber);
                    }
                }
            }
        }

        if (!isResultFound){
            System.out.println("No");
        }
    }

    private static String getReversedStringValue(String comparingValue) {
        StringBuilder reversedStringBuilder = new StringBuilder(comparingValue);

        return  reversedStringBuilder.reverse().toString();
    }
}
