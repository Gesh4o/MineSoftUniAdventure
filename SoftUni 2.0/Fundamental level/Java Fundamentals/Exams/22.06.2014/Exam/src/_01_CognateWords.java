import java.util.ArrayList;
import java.util.HashSet;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _01_CognateWords {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        ArrayList<String> words = new ArrayList<>();
        Pattern pattern = Pattern.compile("[a-zA-Z]+");
        String input = scanner.nextLine();
        Matcher matcher = pattern.matcher(input);
        while (matcher.find()){
            words.add(matcher.group());
        }

        HashSet<String> cognateWords = new HashSet<>();
        boolean isFound = false;
        for (int a = 0; a < words.size(); a++) {
            for (int b = 0; b < words.size(); b++) {
                String cognateWord = words.get(a) + words.get(b);
                for (int c = 0; c < words.size(); c++) {
                    if (a == b || a == c || b == c){
                        continue;
                    }
                    if (cognateWord.equals(words.get(c)) && !cognateWords.contains(cognateWord)){
                        cognateWords.add(cognateWord);
                        isFound = true;
                        System.out.printf("%s|%s=%s%n", words.get(a), words.get(b), words.get(c));
                    }
                }
            }
        }

        if (!isFound){
            System.out.println("No");
        }
    }
}
