import java.util.*;

public class GhettoNumeralSystem {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Integer messageAsDigits = scanner.nextInt();
        String[] messages = new String[messageAsDigits.toString().length()];

        String result;
        result = getMessageWithSwitchCase(messageAsDigits, messages);

        // result = getMessageWithDictionary(messageAsDigits, messages);

        System.out.println(result);
    }

    private static String getMessageWithDictionary(Integer messageAsDigits, String[] messages) {
        Map<Integer, String> dictionary = new HashMap<>();
        dictionary.put(0, "Gee");
        dictionary.put(1, "Bro");
        dictionary.put(2, "Zuz");
        dictionary.put(3, "Ma");
        dictionary.put(4, "Duh");
        dictionary.put(5, "Yo");
        dictionary.put(6, "Dis");
        dictionary.put(7, "Hood");
        dictionary.put(8, "Jam");
        dictionary.put(9, "Mack");
        Integer index = 0;
        while (messageAsDigits > 0){

            Integer currentDigit = messageAsDigits % 10;
            messages[index] = dictionary.get(currentDigit);
            messageAsDigits /= 10;
            index++;
        }

        reverseArray(messages);

        String message = String.join("",messages);

        return message;
    }

    private static String getMessageWithSwitchCase(Integer messageAsDigits, String[] messages) {
        int messagePos = 0;
        while (messageAsDigits > 0){
            String message = "";
            switch (messageAsDigits % 10){
                case 0:
                    message = "Gee";
                    break;
                case 1:
                    message = "Bro";
                    break;
                case 2:
                    message = "Zuz";
                    break;
                case 3:
                    message = "Ma";
                    break;
                case 4:
                    message = "Duh";
                    break;
                case 5:
                    message = "Yo";
                    break;
                case 6:
                    message = "Dis";
                    break;
                case 7:
                    message = "Hood";
                    break;
                case 8:
                    message = "Jam";
                    break;
                case 9:
                    message = "Mack";
                    break;
            }

            messageAsDigits /= 10;
            messages[messagePos] = message;
            messagePos++;
        }

        reverseArray(messages);

        String message = String.join("", messages);

        return message;
    }

    private static void reverseArray(String[] messages) {
        for (int i = 0; i < messages.length / 2; i++) {
            String tempValue = messages[i];
            messages[i] = messages[messages.length - 1 - i];
            messages[messages.length - 1 - i] = tempValue;
        }
    }
}