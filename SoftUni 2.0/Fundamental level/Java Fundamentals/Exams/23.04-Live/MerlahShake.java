import java.util.Scanner;

public class MerlahShake {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String line = scanner.nextLine();
        StringBuilder regex = new StringBuilder(scanner.nextLine());
        boolean isOver = false;


        while (!isOver) {
            StringBuffer text = new StringBuffer(line);

            int firstIndex = text.indexOf(regex.toString());

            if (firstIndex >= 0) {
                text.replace(firstIndex, firstIndex + regex.length(), "");
            }

            text.trimToSize();
            text = new StringBuffer(revertString(text.toString()));
            int lastIndex = text.indexOf(revertString(regex.toString())); // might be -1


            if (lastIndex >= 0) {
                text.replace(lastIndex, lastIndex + regex.length(), "");
            }
            text = new StringBuffer(revertString(text.toString()));
            text.trimToSize();

                if (lastIndex >= 0 && firstIndex >= 0 && regex.length() > 0) {
                    System.out.println("Shaked it.");
                    line = text.toString();
                }else {
                    System.out.println("No shake.");
                    isOver = true;
                }
            try {
                regex.deleteCharAt(regex.length() / 2);
            }catch (Exception e) {
                continue;
            }
        }

        System.out.println(line.trim());
    }

    public static String revertString(String s) {
        String newString = new String();
        for (int i = s.length() - 1; i >= 0; i--) {
            newString += s.charAt(i);
        }

        return newString;
    }
}
