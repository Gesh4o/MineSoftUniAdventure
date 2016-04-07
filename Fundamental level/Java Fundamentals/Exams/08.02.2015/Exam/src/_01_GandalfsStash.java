import java.util.Scanner;

public class _01_GandalfsStash {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String currentMoodAsString  = null;
        Integer mood = Integer.parseInt(scanner.nextLine());

        String[] meals = scanner.nextLine().split("[\\W_]+");

        for (String meal : meals) {
            String lowerCaseMeal = meal.toLowerCase();
            switch (lowerCaseMeal){
                case "cram":
                    mood += 2;
                    break;
                case "lembas":
                    mood += 3;
                    break;
                case "apple":
                    mood += 1;
                    break;
                case "melon":
                    mood += 1;
                    break;
                case "honeycake":
                    mood += 5;
                    break;
                case "mushrooms":
                    mood -= 10;
                    break;
                default:
                    mood -= 1;
                    break;
            }
        }

        if (mood < -5) {
            currentMoodAsString = "Angry";
        } else if (mood >= -5 && mood <= 0){
            currentMoodAsString = "Sad";
        } else if (mood > 0 && mood <= 15) {
            currentMoodAsString = "Happy";
        } else if(mood > 15) {
            currentMoodAsString = "Special JavaScript mood";
        }

        System.out.println(mood);
        System.out.println(currentMoodAsString);
    }
}
