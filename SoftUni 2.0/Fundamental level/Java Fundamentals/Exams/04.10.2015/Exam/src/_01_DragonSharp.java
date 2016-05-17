import java.util.ArrayList;
import java.util.HashSet;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _01_DragonSharp {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Integer inputLinesCount = Integer.parseInt(scanner.nextLine());

        StringBuilder text = new StringBuilder();
        for (int i = 0; i < inputLinesCount; i++) {
            text.append(scanner.nextLine()).append("\n");
        }


        Pattern pattern = Pattern.compile(
                "if[\\s]+\\(([0-9]+)(==|<|>)([0-9]+)\\)[\\s]+(loop[\\s]+([0-9]+)[\\s+])?out[\\s]+\"(.*?)\";" +
                        "|else[\\s]+(loop[\\s+]?([0-9]+)[\\s]+)?out[\\s]+\"(.*?)\";");

        String[] textIntoLines = text.toString().split("\\n+");

        Matcher initialMatcher;
        ArrayList<Boolean> isValid = new ArrayList<>(textIntoLines.length);
        for (int i = 0; i < textIntoLines.length; i++) {
            initialMatcher = pattern.matcher(textIntoLines[i]);
            boolean result = initialMatcher.find();
            isValid.add(result);
        }

        if (isValid.contains(false)) {
            System.out.printf("Compile time error @ line %d%n", isValid.indexOf(false) + 1);
            return;
        }

        HashSet<Integer> passedLines = new HashSet<>();
        for (int lineCounter = 0; lineCounter < textIntoLines.length; lineCounter++) {
            if (passedLines.contains(lineCounter)) {
                continue;
            }

            passedLines.add(lineCounter);

            Matcher matcher = pattern.matcher(textIntoLines[lineCounter]);

            if (matcher.find()) {
                Integer firstNumber = Integer.parseInt(matcher.group(1));
                String operator = matcher.group(2);
                Integer secondNumber = Integer.parseInt(matcher.group(3));

                Integer repetitionsCount = 1;
                String plausibleRepetitionsCount = matcher.group(5);
                if (plausibleRepetitionsCount != null && plausibleRepetitionsCount.length() > 0) {
                    repetitionsCount = Integer.parseInt(plausibleRepetitionsCount);
                }

                String valueToRepeat = matcher.group(6);

                Boolean conditionResult = false;
                switch (operator) {
                    case "==":
                        if (firstNumber.compareTo(secondNumber) == 0) {
                            conditionResult = true;
                        }
                        break;
                    case ">":
                        if (firstNumber.compareTo(secondNumber) > 0) {
                            conditionResult = true;
                        }
                        break;
                    case "<":
                        if (firstNumber.compareTo(secondNumber) < 0) {
                            conditionResult = true;
                        }
                        break;
                }

                if (lineCounter < textIntoLines.length - 1 && textIntoLines[lineCounter + 1].startsWith("else")) {
                    Matcher elseMatcher = pattern.matcher(textIntoLines[lineCounter + 1]);
                    if (elseMatcher.find()) {
                        if (conditionResult) {
                            passedLines.add(lineCounter + 1);
                        } else {
                            Integer repetitionsCounter = 1;

                            String plausibleRepetitionsCounter = elseMatcher.group(8);
                            if (plausibleRepetitionsCounter != null && plausibleRepetitionsCounter.length() > 0) {
                                repetitionsCounter = Integer.parseInt(plausibleRepetitionsCounter);
                            }

                            String valueToPrint = elseMatcher.group(9);
                            for (int i = 0; i < repetitionsCounter; i++) {
                                System.out.println(valueToPrint);
                            }

                            passedLines.add(lineCounter + 1);
                        }
                    }
                }

                if (conditionResult) {
                    for (int i = 0; i < repetitionsCount; i++) {
                        System.out.println(valueToRepeat);
                    }
                }
            }
        }
    }
}

