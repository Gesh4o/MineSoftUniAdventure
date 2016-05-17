import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _02_PyramidWin {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String input = scanner.nextLine();
        Pattern pattern = Pattern.compile("\\|(.*?)\\|");
        Matcher matcher = pattern.matcher(input);
        while (matcher.find()){
            char[] charSequence = matcher.group(1).toCharArray();

            int bombRange = getBombRange(charSequence);
            int firstBorderIndex = input.indexOf('|');
            int secondBorderIndex = input.indexOf('|', firstBorderIndex + 1);

            StringBuilder result = new StringBuilder();
            for (int currentIndex = 0; currentIndex < input.length(); currentIndex++) {
                char c;
                if (isCurrentIndexInRange(bombRange, firstBorderIndex,secondBorderIndex, currentIndex)){
                    c = '.';
                }else{
                    c = input.charAt(currentIndex);
                }

                result.append(c);
            }

            input = result.toString();
        }

        System.out.println(input);
    }

    private static boolean isCurrentIndexInRange(int bombRange, int firstBorderIndex, int secondBorderIndex, int currentIndex) {
        if (currentIndex < firstBorderIndex - bombRange || currentIndex > secondBorderIndex + bombRange){
            return false;
        }

        return true;
    }

    private static int getBombRange(char[] charSequence) {
        int charSum = 0;
        for (char c : charSequence) {
            charSum += c;
        }

        return charSum % 10;
    }
}
