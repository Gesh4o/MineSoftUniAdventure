import java.util.*;

public class _01_ArrangeIntegers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Integer[] sequence = Arrays.stream(scanner.nextLine().split("[\\s,]+")).map(Integer::parseInt).toArray(Integer[]::new);

        CustomInteger[] customInts = Arrays.stream(sequence).map(CustomInteger::new).toArray(CustomInteger[]::new);

        Collections.sort(Arrays.asList(customInts));

        String[] integersAsString = Arrays.stream(customInts).map(CustomInteger::toString).toArray(String[]::new);

        System.out.println(String.join(", ", integersAsString));
    }
}

class CustomInteger implements Comparable<CustomInteger> {
    public Integer Value;
    public String StringRepresentation;

    public CustomInteger(int value) {
        this.Value = value;
        this.StringRepresentation = this.InitializeStringRepresentation(value);
    }

    private String InitializeStringRepresentation(Integer value) {
        int currentValue = value;
        StringBuilder result = new StringBuilder();
        while(currentValue >= 0){
            int currentDigit = currentValue % 10;
            switch (currentDigit){
                case 0:
                    result.append("zero");
                    break;
                case 1:
                    result.append("one");
                    break;
                case 2:
                    result.append("two");
                    break;
                case 3:
                    result.append("three");
                    break;
                case 4:
                    result.append("four");
                    break;
                case 5:
                    result.append("five");
                    break;
                case 6:
                    result.append("six");
                    break;
                case 7:
                    result.append("seven");
                    break;
                case 8:
                    result.append("eight");
                    break;
                case 9:
                    result.append("nine");
                    break;
                default:
                    break;
            }

            if (currentValue / 10 > 0){
                result.append("-");
            }else{
                break;
            }

            currentValue /= 10;
        }

        String[] reversedString = result.toString().split("-");
        Collections.reverse(Arrays.asList(reversedString));

        return String.join("-",reversedString);
    }

    @Override
    public String toString() {
        String result = Integer.toString(this.Value);
        return result;
    }

    @Override
    public int compareTo(CustomInteger other) {
        if (this.StringRepresentation.startsWith(other.StringRepresentation)){
            return this.Value.compareTo(other.Value);
        } else{
            return this.StringRepresentation.compareTo(other.StringRepresentation);
        }
    }
}

