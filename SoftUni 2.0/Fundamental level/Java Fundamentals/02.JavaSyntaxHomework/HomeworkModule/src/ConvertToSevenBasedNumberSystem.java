import java.util.Locale;
import java.util.Scanner;

public class ConvertToSevenBasedNumberSystem {
    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);
        Scanner scanner = new Scanner(System.in);

        Integer number = scanner.nextInt();

        Integer numberInSevenBaseSystem;
        numberInSevenBaseSystem = getSevenBasedNumberSystem(number);

        // numberInSevenBaseSystem = Integer.parseInt(Integer.toString(number, 7));
        System.out.print(numberInSevenBaseSystem);

    }

    private static Integer getSevenBasedNumberSystem(Integer number) {
        // If you have not used StringBuilder visit this : http://www.dotnetperls.com/stringbuilder.
        // It is for C# but at this point we probably know much more about C# than Java. :)
        StringBuilder stringBuilder = new StringBuilder();
        while (number > 0){
            Integer leftOver = number % 7;
            stringBuilder.append(leftOver);
            number /= 7;
        }

        Integer result = Integer.parseInt(stringBuilder.reverse().toString());

        return result;
    }
}
