import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _02_WeirdScript {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Integer keyNumber = Integer.parseInt(scanner.nextLine());

        keyNumber -= 1;

        String key;
        if ((keyNumber / 26) % 2 == 1 ){
            keyNumber %= 26;
            key = Character.toString((char)(65 + keyNumber));
        }else{
            keyNumber %= 26;
            key = Character.toString((char)(97 + keyNumber));
        }

        key +=key;
        Pattern pattern = Pattern.compile(String.format("%s(.*?)%s", key,key));

        String input = scanner.nextLine();
        StringBuilder stringBuilder = new StringBuilder();
        while (!input.equals("End")){
            stringBuilder.append(input);
            input = scanner.nextLine();
        }

        Matcher matcher = pattern.matcher(stringBuilder.toString());
        while (matcher.find()){
            System.out.println(matcher.group(1));
        }
    }
}
