import java.util.Map;
import java.util.Objects;
import java.util.Scanner;
import java.util.TreeMap;

public class _23_PhoneBookUpgrade {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Map<String, String> phoneBook = new TreeMap<>();
        String command = scanner.nextLine();
        while (!Objects.equals(command, "END")) {
            String[] commandInfo = command.split("\\s+");
            String commandName = commandInfo[0];

            String contactName;
            switch (commandName) {
                case "A":
                    contactName = commandInfo[1];
                    String contactNumber = commandInfo[2];
                    if (phoneBook.containsKey(contactName)) {
                        phoneBook.remove(contactName);
                    }

                    phoneBook.put(contactName, contactNumber);

                    break;
                case "S":
                    contactName = commandInfo[1];
                    if (phoneBook.containsKey(contactName)) {
                        System.out.printf("%s -> %s%n", contactName, phoneBook.get(contactName));
                    } else {
                        System.out.printf("Contact %s does not exist.%n", contactName);
                    }
                    break;
                case "ListAll":
                    for (String phoneNumberKey : phoneBook.keySet()) {
                        System.out.printf("%s -> %s%n", phoneNumberKey, phoneBook.get(phoneNumberKey));
                    }
                    break;
            }

            command = scanner.nextLine();
        }
    }
}
