import java.util.ArrayList;
import java.util.Collections;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _04_LogParser {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        ArrayList<Report> reports = new ArrayList<>();
        String input = scanner.nextLine();
        while (!input.equals("END")){
            String[] parsedInformation = new String[3];
            boolean isInfoValid = parseLogInformation(input, parsedInformation);
            if (isInfoValid){
                String projectName = parsedInformation[0];
                String errorType = parsedInformation[1];
                String errorMessage = parsedInformation[2];

                Report currentReport;
                if (!reports.stream().anyMatch(r -> r.projectName.equals(projectName))){
                    currentReport = new Report(projectName);
                    reports.add(currentReport);
                }

                currentReport = reports.stream().filter(r -> r.projectName.equals(projectName)).findFirst().get();

                if (errorType.equals("Warning")){
                    currentReport.warningErrors.add(new Error(errorType, errorMessage));
                }else{
                    currentReport.criticalErrors.add(new Error(errorType, errorMessage));
                }
            }

            input = scanner.nextLine();
        }

        Collections.sort(reports);
        String[] reportsAsString = reports.stream().map(Report::toString).toArray(String[]::new);

        System.out.println(String.join("\n\n",reportsAsString));
    }

    private static boolean parseLogInformation(String input, String[] parsedInformation) {
        Pattern pattern = Pattern.compile("\"Project\".*?\\[\"(.*?)\"].*?\"Type\".*?\\[\"(.*?)\"].*?\"Message\".*?\\[\"(.*?)\"]");
        Matcher matcher = pattern.matcher(input);
        boolean isMatchFound = matcher.find();

        if (isMatchFound){
            parsedInformation[0] = matcher.group(1);
            parsedInformation[1] = matcher.group(2);
            parsedInformation[2] = matcher.group(3);
        }

        return isMatchFound;
    }
}

class Report implements Comparable<Report> {
    public Report(String projectName) {
        this.projectName = projectName;
        this.warningErrors = new ArrayList<>();
        this.criticalErrors = new ArrayList<>();
    }

    public String projectName;

    public ArrayList<Error> warningErrors;

    public ArrayList<Error> criticalErrors;

    public Integer getAllReportsCount(){
        Integer result = this.criticalErrors.size() + this.warningErrors.size();
        return result;
    }

    @Override
    public String toString() {
        Collections.sort(this.criticalErrors);
        Collections.sort(this.warningErrors);
        StringBuilder stringView = new StringBuilder();
        stringView.append(String.format("%s:\n",this.projectName));
        stringView.append(String.format("Total Errors: %d%n",this.getAllReportsCount()));
        stringView.append(String.format("Critical: %d%n",this.criticalErrors.size()));
        stringView.append(String.format("Warnings: %d%n",this.warningErrors.size()));
        stringView.append("Critical Messages:\n");

        if (this.criticalErrors.size() == 0){
            stringView.append("--->").append("None").append("\n");
        } else {
            for (Error criticalError : this.criticalErrors) {
                stringView.append("--->").append(criticalError.toString()).append("\n");
            }
        }
        stringView.append("Warning Messages:\n");
        if (this.warningErrors.size() == 0){
            stringView.append("--->").append("None").append("\n");
        }else {
            for (Error warningError : this.warningErrors) {
                stringView.append("--->").append(warningError.toString()).append("\n");
            }
        }

        return stringView.toString().trim();
    }

    @Override
    public int compareTo(Report other) {
        int compareResult = other.getAllReportsCount().compareTo(this.getAllReportsCount());

        if (compareResult == 0){
            compareResult = this.projectName.compareTo(other.projectName);
        }

        return compareResult;
    }
}

class Error implements Comparable<Error> {
    public Error(String errorType, String errorMessage) {
        this.errorType = errorType;
        this.errorMessage = errorMessage;
    }

    public String errorType;

    public String errorMessage;

    @Override
    public String toString() {
        return this.errorMessage;
    }

    @Override
    public int compareTo(Error other) {
        int compareResult = new Integer(this.errorMessage.length()).compareTo(other.errorMessage.length());

        if (compareResult == 0){
            compareResult = this.errorMessage.compareTo(other.errorMessage);
        }

        return compareResult;
    }
}