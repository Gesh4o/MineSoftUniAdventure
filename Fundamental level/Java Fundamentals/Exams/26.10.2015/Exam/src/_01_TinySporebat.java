import java.util.Scanner;

public class _01_TinySporebat {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int health = 5800;
        int glowcaps = 0;
        String input = scanner.nextLine();

        while (!input.equals("Sporeggar") && health > 0){
            for (int c = 0; c < input.length(); c++) {
                char currentChar = input.charAt(c);
                if (currentChar == 'L'){
                    health += 200;
                }else if(c == input.length() - 1){
                    glowcaps += Integer.parseInt(Character.toString(input.charAt(c)));
                } else{
                    health -= currentChar;
                    if (health <= 0){
                        break;
                    }
                }
            }

            input = scanner.nextLine();
        }

        if (health > 0){
            System.out.printf("Health left: %d%n",health);

            if (glowcaps >= 30){
                System.out.printf("Bought the sporebat. Glowcaps left: %d%n", glowcaps - 30);
            } else{
                System.out.printf("Safe in Sporeggar, but another %d Glowcaps needed.%n", 30 - glowcaps);
            }
        }else{
            System.out.printf("Died. Glowcaps: %d%n",glowcaps);
        }
    }
}
