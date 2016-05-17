import java.util.Arrays;
import java.util.Scanner;

public class _01_Timespan {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Integer[] startTimeInfo = Arrays.stream(scanner.nextLine().split(":+")).map(Integer::parseInt).toArray(Integer[]::new);
        Integer[] endTimeInfo = Arrays.stream(scanner.nextLine().split(":+")).map(Integer::parseInt).toArray(Integer[]::new);

        Integer minutesDifferenceFromSeconds = 0;
        Integer seconds = startTimeInfo[2] - endTimeInfo[2];
        if (seconds < 0){
            seconds = 60 + seconds;
            minutesDifferenceFromSeconds--;
        }

        Integer hoursDifferenceFromMinutes = 0;
        Integer minutes = (startTimeInfo[1] - endTimeInfo[1]) + minutesDifferenceFromSeconds;
        if (minutes < 0){
            minutes = 60 + minutes;
            hoursDifferenceFromMinutes--;
        }

        Integer hours = (startTimeInfo[0] - endTimeInfo[0]) + hoursDifferenceFromMinutes;

        System.out.printf("%d:%02d:%02d%n", hours,minutes,seconds);
    }
}
