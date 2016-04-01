import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _03_BasicMarkupLeague {
    private static Integer counter = 1;
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String inputData = scanner.nextLine();

        while (!inputData.equals("<stop/>")){
            String commandName;
            String content;
            Matcher matcher = Pattern.compile("<(\\s)*(repeat|reverse|inverse)([\\s]+(.*?))content(\\s)*=(\\s)*\"(.+?)\"").matcher(inputData);
            if (matcher.find()){
                commandName = matcher.group(2);
                content = matcher.group(7);

                switch (commandName){
                    case "repeat":
                        Matcher valueMatcher = Pattern.compile("value[\\s]*=[\\s]*\"([0-9]+)\"").matcher(inputData);
                        if (valueMatcher.find()){
                            Integer count = Integer.parseInt(valueMatcher.group(1));
                            
                            printCountTimesContent(content, count);
                        }
                        break;
                    case "reverse":
                        char[] reversedCharArray = reverseCharArray(content.toCharArray());
                        content = new String(reversedCharArray);
                        printCountTimesContent(content,1);
                        break;
                    case "inverse":
                        char[] inversedCharArray = inverseCharArray(content.toCharArray());
                        content = new String(inversedCharArray);
                        printCountTimesContent(content,1);
                        break;
                    default:
                        break;
                }
            }

            inputData = scanner.nextLine();
        }
    }

    private static char[] inverseCharArray(char[] chars) {
        for (int i = 0; i < chars.length; i++) {
            if (Character.isLowerCase(chars[i])){
                chars[i] = (char)(chars[i] - 32);
            }else if (Character.isUpperCase(chars[i])){
                chars[i] = (char)(chars[i] + 32);
            }
        }

        return chars;
    }

    private static char[] reverseCharArray(char[] chars) {
        for (int i = 0; i < chars.length / 2; i++) {
            char oldValue = chars[i];
            chars[i] = chars[chars.length - 1 - i];
            chars[chars.length - 1 - i] = oldValue;
        }

        return chars;
    }

    private static void printCountTimesContent(String content, Integer count) {
        for (int i = 0; i < count; i++) {
            System.out.printf("%d. %s%n", counter, content);
            counter++;
        }
    }

}
