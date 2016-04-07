import java.util.ArrayList;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _03_ValidUsernames {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String input = scanner.nextLine();
        Pattern pattern = Pattern.compile("\\b([a-zA-Z_][\\w]{2,24})\\b");

        String coupleWithMaxLength = null;
        Integer maxLength = 0;
        Matcher matcher = pattern.matcher(input);

        ArrayList<String> matchCollection = new ArrayList<>();
        while (matcher.find()){
            String username= matcher.group(1);
            matchCollection.add(username);
        }

        for (int i = 0; i < matchCollection.size() - 1; i++) {
            if (matchCollection.get(i).length() + matchCollection.get(i + 1).length() > maxLength){
                maxLength = matchCollection.get(i).length() + matchCollection.get(i + 1).length();
                coupleWithMaxLength = matchCollection.get(i) + "\n" + matchCollection.get(i + 1);
            }
        }

        System.out.println(coupleWithMaxLength);
    }
}
