import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.Scanner;
import java.util.Set;
import java.util.TreeSet;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _19_ChatLogger {
    private static Scanner scanner = new Scanner(System.in);

    public static void main(String[] args) {
        String currentDateTimeString = scanner.nextLine();
        DateTimeFormatter formatter = DateTimeFormatter.ofPattern("dd-MM-yyyy HH:mm:ss");
        LocalDateTime currentDateTime = LocalDateTime.from(formatter.parse(currentDateTimeString));
        String input = scanner.nextLine();
        Pattern pattern = Pattern.compile("(.*?) / ([0-9]{2}-[0-9]{2}-[0-9]{4} [0-9]{2}:[0-9]{2}:[0-9]{2})");
        Matcher matcher;
        Set<Message> messages = new TreeSet<>();
        while (!input.equals("END")){
            matcher = pattern.matcher(input);

            if (matcher.find()){
                LocalDateTime dateTime = LocalDateTime.from(formatter.parse(matcher.group(2)));
                String messageText = matcher.group(1);

                Message message = new Message(messageText, dateTime);
                messages.add(message);
            }

            input = scanner.nextLine();
        }

        String[] messagesAsStrings = messages.stream().map(Message::toString).toArray(String[]::new);

        System.out.println(String.join("\r\n", messagesAsStrings));

        LocalDateTime lastDateTime = messages.stream().sorted( (m1,m2) -> m2.compareTo(m1)).findFirst().get().getDateTime();

        String activity;

        if (currentDateTime.getYear() == lastDateTime.getYear()){
            if (currentDateTime.getMonth() == lastDateTime.getMonth()){
                if (currentDateTime.getDayOfMonth() == lastDateTime.getDayOfMonth()){
                    if (currentDateTime.getHour() == lastDateTime.getHour()){
                        if (currentDateTime.getMinute() - lastDateTime.getMinute() >= 1) {
                            if (currentDateTime.getMinute() - lastDateTime.getMinute() == 1 &&
                                    currentDateTime.getSecond() < lastDateTime.getSecond()) {
                                    activity = "a few moments ago";
                            } else {
                                if (lastDateTime.getSecond() > currentDateTime.getSecond()) {
                                    activity = String.format("%s minute(s) ago", Integer.toString(currentDateTime.getMinute() - lastDateTime.getMinute() - 1));
                                } else {
                                    activity = String.format("%s minute(s) ago", Integer.toString(currentDateTime.getMinute() - lastDateTime.getMinute()));
                                }
                            }
                        }
                        else {
                            activity = "a few moments ago";
                        }
                    }
                    else {
                        activity = String.format("%s hour(s) ago", Integer.toString(currentDateTime.getHour() - lastDateTime.getHour()));
                    }
                } else {
                    if (currentDateTime.getDayOfMonth() - 1 == lastDateTime.getDayOfMonth()){
                        activity = "yesterday";
                    }else{
                        activity = getLastDateString(lastDateTime);
                    }
                }
            }
            else  {
                activity = getLastDateString(lastDateTime);
            }
        }else{
            activity = getLastDateString(lastDateTime);
        }

        System.out.printf("<p>Last active: <time>%s</time></p>%n", activity);
    }

    private static String getLastDateString(LocalDateTime lastDateTime) {
        return String.format("%02d", Integer.parseInt(Integer.toString(lastDateTime.getDayOfMonth()))) +
                "-" + String.format("%02d", Integer.parseInt(Integer.toString(lastDateTime.getMonthValue()))) +
                "-" + Integer.toString(lastDateTime.getYear());
    }
}

class Message implements Comparable<Message>{
    private String text;

    private LocalDateTime dateTime;

    public LocalDateTime getDateTime() {
        return dateTime;
    }

    public Message(String message, LocalDateTime dateTime) {
        this.text = escapeHTML(message);
        this.dateTime = dateTime;
    }

    @Override
    public String toString() {
        String stringView = String.format("<div>%s</div>", this.text);
        return stringView;
    }

    @Override
    public int compareTo(Message other) {
        return this.dateTime.compareTo(other.dateTime);
    }

    private static String escapeHTML(String s) {
        StringBuilder out = new StringBuilder(Math.max(16, s.length()));
        for (int i = 0; i < s.length(); i++) {
//            < to &lt;
//            > to &gt;
//            " to &quot;
//            ' to &apos;
//                    & to &amp;
            char c = s.charAt(i);
            switch (c){
                case '>':
                    out.append("&lt;");
                    break;
                case '<':
                    out.append("&gt;");
                    break;
                case '\"':
                    out.append("&quot;");
                    break;
                case '\'':
                    out.append("&apos;");
                    break;
                case '&':
                    out.append("&amp;");
                    break;
                default:
                    out.append(c);
            }
        }
        return out.toString();
    }
}
