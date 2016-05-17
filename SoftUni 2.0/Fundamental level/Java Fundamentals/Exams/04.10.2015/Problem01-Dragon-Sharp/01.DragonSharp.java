import java.util.ArrayList;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class DragonSharp {
    private static ArrayList<String> outputList;
    private static String[] matchTokens;

    public static void main(String[] args) {
        outputList = new ArrayList<>();
        Scanner scn = new Scanner(System.in);
        int n = Integer.parseInt(scn.nextLine());
        String pattern = "(.+?)\"(.+?)\";";

        Pattern pat = Pattern.compile(pattern);

        Boolean expectsElse = false;
        Boolean isCompileError = false;
        int errorLine = 0;

        for (int i = 1; i <= n && !isCompileError; i++) {
            String line = scn.nextLine();
            Matcher match = pat.matcher(line);

            if (match.find()) {
                matchTokens = match.group(1).trim().split("\\s+");
                String output = match.group(2);

                if (matchTokens[0].equals("if")) {
                    if (evaluateCondition(matchTokens[1])) {
                        processCommand(output, false);
                        expectsElse = false;
                    } else {
                        expectsElse = true;
                    }
                } else if (matchTokens[0].equals("else") && expectsElse) {
                    processCommand(output, true);
                }
            } else {
                isCompileError = true;
                errorLine = i;
            }
        }

        if (isCompileError) {
            System.out.println("Compile time error @ line " + errorLine);
        } else {
            for (String line : outputList) {
                System.out.println(line);
            }
        }
    }

    private static boolean evaluateCondition(String condition) {
        condition = condition.substring(1, condition.length() - 1);
        String[] conditionDigits = condition.split("[><=]+");

        int left = Integer.parseInt(conditionDigits[0]);
        int right = Integer.parseInt(conditionDigits[1]);
        String operator = condition.replaceAll("\\d+", "");

        boolean result;
        switch (operator) {
            case "==": result = left == right; break;
            case ">": result = left > right; break;
            case "<": result = left < right; break;
            default: result = false;
        }

        return result;
    }

    private static void processCommand(String output, boolean isElse) {
        int loopIndex = isElse ? 1 : 2;
        boolean isLoop = matchTokens[loopIndex].equals("loop");
        int repetitions = isLoop ? Integer.parseInt(matchTokens[loopIndex + 1]) : 1;

        for (int i = 1; i <= repetitions; i++) {
            outputList.add(output);
        }
    }
}
