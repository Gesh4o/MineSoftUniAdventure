import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _03_WeirdStrings {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        List<String> words = new ArrayList<>();
        String inputInfo = scanner.nextLine().replaceAll("[/()\\|\\s]+", "");
        Pattern pattern = Pattern.compile("[a-zA-Z]+");
        Matcher matcher = pattern.matcher(inputInfo);
        while (matcher.find()){
            words.add(matcher.group());
        }

        int biggestSum = Integer.MIN_VALUE;
        int biggestSumIndex = -1;
        for (int i = 0; i < words.size() - 1; i++) {
            int firstWordWeight = 0;
            for (char c : words.get(i).toLowerCase().toCharArray()) {
                firstWordWeight += c - 96;
            }

            int secondWordWeight = 0;
            for (char c : words.get(i + 1).toLowerCase().toCharArray()) {
                secondWordWeight += c - 96;
            }

            if (firstWordWeight + secondWordWeight >= biggestSum){
                biggestSum = firstWordWeight + secondWordWeight;
                biggestSumIndex = i;
            }
        }

        if (biggestSumIndex != -1){
            System.out.println(words.get(biggestSumIndex));
            System.out.println(words.get(biggestSumIndex + 1));
        }
    }
}
